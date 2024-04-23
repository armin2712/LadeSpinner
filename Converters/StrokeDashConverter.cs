using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace LadeSpinner.Converters
{
    /// <summary>
    /// Ein Konverter, der die Dash-Eigenschaft für 
    /// einen Strich berechnet basierend auf dem Durchmesser 
    /// und der Stärke eines Ellipsen-Elements.
    /// </summary>
    public class StrokeDashConverter : IMultiValueConverter
    {
        /// <summary>
        /// Konvertiert Eingabewerte in ein Array von Double-Werten, 
        /// das die Linien- und Lückenlängen für die Dash-Eigenschaft eines Strichs darstellt.
        /// </summary>
        /// <param name="values">Die Eingabewerte, die den Durchmesser 
        /// und die Stärke des Ellipsen-Elements repräsentieren.</param>
        /// <param name="targetType">Der Typ, in den konvertiert werden soll (nicht verwendet).</param>
        /// <param name="parameter">Ein optionaler Parameter (nicht verwendet).</param>
        /// <param name="culture">Die Kulturinformationen für die Konvertierung (nicht verwendet).</param>
        /// <returns>Ein DoubleCollection-Objekt, das die Linien- und Lückenlängen f
        /// ür die Dash-Eigenschaft eines Strichs enthält.</returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 2 || !double.TryParse(values[0].ToString(), 
                out double Durchmesser) || !double.TryParse(values[1].ToString(), 
                out double Stärke))
            {
                return 0;
            }

            double Umfang = Math.PI * Durchmesser;

            double LinienLänge = Umfang *0.75;
            double LückenLänge = Umfang - LinienLänge;

            return new DoubleCollection(new[] { LinienLänge / Stärke, LückenLänge / Stärke });
        }

        /// <summary>
        /// Konvertiert einen Wert oder ein Array von Werten
        /// zurück zu einem einzelnen Wert (nicht implementiert).
        /// </summary>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException(); //Den ConvertBack brauchen wir nicht
        }
    }
}
