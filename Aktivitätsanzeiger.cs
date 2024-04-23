using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace LadeSpinner
{
    /// <summary>
    /// Ein benutzerdefinierter Steuerelement für einen Ladespinner.
    /// </summary>
    public class Aktivitätsanzeiger : Control
    {

        /// <summary>
        /// Statische Initialisierung des Aktivitätsanzeiger objekts
        /// </summary>
        static Aktivitätsanzeiger()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Aktivitätsanzeiger),
                new FrameworkPropertyMetadata(typeof(Aktivitätsanzeiger)));

        }

        /// <summary>
        /// Initialisiert eine neue Instanz des Aktivitätsanzeiger objekts.
        /// </summary>
        public Aktivitätsanzeiger()
        {
            this.Loaded += Aktivitätsanzeiger_Loaded;
        }


        #region IstBeschäftigt-Abhängigkeitseigenschaft

        /// <summary>
        /// Abhängigkeitseigenschaft, die angibt, ob der Spinner aktiv ist oder nicht.
        /// </summary>
        public static readonly DependencyProperty IstBeschäftigtProperty =
            DependencyProperty.Register("IstBeschäftigt",
                typeof(bool), typeof(Aktivitätsanzeiger),
                new PropertyMetadata(false, OnIstBeschäftigtChanged));

        /// <summary>
        /// Ruft den Wert der IstBeschäftigtProperty Abhängigkeitseigenschaft
        /// ab oder legt diesen fest.
        /// </summary>
        public bool IstBeschäftigt
        {
            get => (bool)GetValue(IstBeschäftigtProperty);
            set => SetValue(IstBeschäftigtProperty, value);
        }

        #region Rotation logik


        /// <summary>
        /// Stellt einen RotateTransform bereit, 
        /// der für die Rotation des Spinners verwendet wird.
        /// </summary>
        private RotateTransform rotationTransform { get; set; } = null!;

        /// <summary>
        /// Stellt einen CancellationTokenSource bereit, 
        /// der zur Steuerung der Rotation des Spinners verwendet wird.
        /// </summary>
        private CancellationTokenSource rotationCancellationTokenSource { get; set; } = null!;


        /// <summary>
        /// Wird aufgerufen, wenn sich der Wert der IstBeschäftigtProperty Abhängigkeitseigenschaft ändert.
        /// </summary>
        private static void OnIstBeschäftigtChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (Aktivitätsanzeiger)d;

            if ((bool)e.NewValue)
            {
                control.StartRotation();
            }
            else
            {
                control.StopRotation();
            }
        }

        /// <summary>
        /// Startet die Rotation des Spinners.
        /// </summary>
        private void StartRotation()
        {
            if (rotationCancellationTokenSource == null 
                || rotationCancellationTokenSource.IsCancellationRequested)
            {
                rotationCancellationTokenSource = new CancellationTokenSource();
                InitializeRotation();
            }
        }

        /// <summary>
        /// Stoppt die Rotation des Spinners.
        /// </summary>
        private void StopRotation()
        {
            rotationCancellationTokenSource?.Cancel();
        }

        /// <summary>
        /// Initialisiert die Rotation des Spinners.
        /// </summary>
        private async void InitializeRotation()
        {
            var ellipse = this.Template.FindName("SpinnerEllipse", this) as Ellipse;

            if (ellipse != null)
            {
                rotationTransform = new RotateTransform();
                ellipse.RenderTransform = rotationTransform;

                while (true)
                {
                    try
                    {
                        await Task.Delay(35, rotationCancellationTokenSource.Token);

                        if (IstBeschäftigt)
                        {
                            rotationTransform.Angle += 10;
                        }
                        else
                        {

                            break;
                        }
                    }
                    catch (TaskCanceledException)
                    {

                        break;
                    }
                }
            }
        }
        #endregion Rotation logik

        #endregion IstBeschäftigt-Abhängigkeitseigenschaft

        #region Farben-Abhängigkeitseigenschaften

        /// <summary>
        /// Abhängigkeitseigenschaft für die statische Farbe des Spinners.
        /// </summary>
        public static readonly DependencyProperty StatischeFarbeProperty =
            DependencyProperty.Register("StatischeFarbe",
                typeof(Color), typeof(Aktivitätsanzeiger),
                new PropertyMetadata(Color.FromRgb(0, 0, 0)));

        /// <summary>
        /// Ruft den Wert der StatischeFarbeProperty Abhängigkeitseigenschaft 
        /// ab oder legt diesen fest.
        /// </summary>
        public Color StatischeFarbe
        {
            get => (Color)GetValue(StatischeFarbeProperty);
            set => SetValue(StatischeFarbeProperty, value);
        }

        /// <summary>
        /// Abhängigkeitseigenschaft für die rotierende Farbe des Spinners.
        /// </summary>
        public static readonly DependencyProperty RotationsfarbeProperty =
       DependencyProperty.Register("Rotationsfarbe",
           typeof(Color), typeof(Aktivitätsanzeiger),
           new PropertyMetadata(Color.FromRgb(250, 250, 250)));

        /// <summary>
        /// Ruft den Wert derRotationsfarbeProperty Abhängigkeitseigenschaft 
        /// ab oder legt diesen fest.
        /// </summary>
        public Color Rotationsfarbe
        {
            get => (Color)GetValue(RotationsfarbeProperty);
            set => SetValue(RotationsfarbeProperty, value);
        }

        #region Farben logik

        /// <summary>
        /// Aktualisiert die Farben des linearen Verlaufs des Spinners.
        /// </summary>
        private void UpdateGradientBrushColors()
        {
            var ellipse = this.Template.FindName("SpinnerEllipse", this) as Ellipse;
            if (ellipse != null)
            {
                var gradientBrush = new LinearGradientBrush
                {
                    StartPoint = new Point(0, 0),
                    EndPoint = new Point(1, 0)
                };

                gradientBrush.GradientStops.Add(new GradientStop(StatischeFarbe, 0.6));
                gradientBrush.GradientStops.Add(new GradientStop(Rotationsfarbe, 0.9));

                ellipse.Stroke = gradientBrush;
            }
        }

        /// <summary>
        /// Wird aufgerufen, wenn das Steuerelement geladen wird.
        /// </summary>
        private void Aktivitätsanzeiger_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateGradientBrushColors(); //Damit die Farben der Ellipse geladen werden
        }


        #endregion Farben logik

        #endregion Farben-Abhängigkeitseigenschaften

        #region Stärke und Durchmesser-Abhängigkeitseigenschaften

        /// <summary>
        /// Abhängigkeitseigenschaft für die Stärke des Spinners.
        /// </summary>
        public static readonly DependencyProperty StärkeProperty =
            DependencyProperty.Register("Stärke",
                typeof(double), typeof(Aktivitätsanzeiger),
                new PropertyMetadata(1.0));

        /// <summary>
        /// Ruft den Wert der StärkeProperty Abhängigkeitseigenschaft 
        /// ab oder legt diesen fest.
        /// </summary>
        public double Stärke
        {
            get => (double)GetValue(StärkeProperty);
            set => SetValue(StärkeProperty, value);
        }

        /// <summary>
        /// Abhängigkeitseigenschaft für den Durchmesser des Spinners.
        /// </summary>
        public static readonly DependencyProperty DurchmesserProperty =
       DependencyProperty.Register("Durchmesser",
           typeof(double), typeof(Aktivitätsanzeiger),
           new PropertyMetadata(25.0));

        /// <summary>
        /// Ruft den Wert der DurchmesserProperty Abhängigkeitseigenschaft 
        /// ab oder legt diesen fest.
        /// </summary>
        public double Durchmesser
        {
            get => (double)GetValue(DurchmesserProperty);
            set => SetValue(DurchmesserProperty, value);
        }

        #endregion

    }
}
