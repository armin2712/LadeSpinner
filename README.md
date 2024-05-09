# Lade-Spinner-Benutzersteuerelement

## Beschreibung:
Das Lade-Spinner-Benutzersteuerelement ist ein benutzerdefiniertes Steuerelement für WPF (Windows Presentation Foundation), das eine optisch ansprechende Spinner-Animation zur Anzeige von Lade- oder Verarbeitungszuständen bereitstellt. Dieser Benutzersteuerelement ist auf Deutsch verfügbar und verfügt über eine speichereffiziente Animationsmethode, die Aufgaben anstelle von Storyboards verwendet.

## Eigenschaften:
- **Anpassung**: Benutzer können das Erscheinungsbild des Spinners anpassen, indem sie die statische Farbe und die Rotationsfarbe festlegen.
- **Anpassbare Größe**: Der Durchmesser und die Dicke des Spinners können angepasst werden, um verschiedene UI-Designs und Layouts zu unterstützen.
- **Speichereffiziente Animation**: Die Spinner-Animation ist so konzipiert, dass sie speichereffizient ist, indem sie keine Storyboards verwendet und nur erscheint, wenn sie benötigt wird. Die Animation wird über eine Abhängigkeitseigenschaft namens IstBeschäftigt ausgelöst, die an boolesche Werte gebunden werden kann. Wenn IstBeschäftigt auf true gesetzt wird, startet die Animation und dreht die innere Ellipse. Wenn IstBeschäftigt auf false gesetzt wird, stoppt die Animation und verschwindet.

## Verwendung:
1. Fügen Sie das Lade-Spinner-Benutzersteuerelement Ihrem WPF-Projekt hinzu.
2. Integrieren Sie das Benutzersteuerelement in Ihr XAML-Markup oder instanziieren Sie es programmgesteuert.
3. Passen Sie das Erscheinungsbild des Spinners an, indem Sie Eigenschaften für die statische Farbe, die Rotationsfarbe, den Durchmesser und die Dicke festlegen.
4. Binden Sie die Abhängigkeitseigenschaft IstBeschäftigt an boolesche Werte in Ihrem ViewModel oder Ihrer Code-Behind-Datei. Wenn IstBeschäftigt auf true gesetzt wird, startet die Animation automatisch. Wenn IstBeschäftigt auf false gesetzt wird, stoppt die Animation und verschwindet.

## Eigenschaften:
- **StatischeFarbe**: Legt die Farbe des statischen Teils des Spinners fest.
- **Rotationsfarbe**: Legt die Farbe des rotierenden Teils des Spinners fest.
- **Durchmesser**: Legt den Durchmesser des Spinners fest.
- **Starke**: Legt die Dicke des Spinners fest.
- **IstBeschäftigt**: Bindbare Abhängigkeitseigenschaft, die den Zustand der Spinner-Animation steuert. Wenn true, startet die Animation. Wenn false, stoppt die Animation und verschwindet.

## Beitrag:
Sie können das Lade-Spinner-Benutzersteuerelement in Ihren WPF-Projekten ohne Nennung des Erstellers verwenden. Beiträge, Feedback und Verbesserungen sind willkommen. Sie können zum Projekt beitragen, indem Sie Pull-Anfragen einreichen, Probleme melden oder neue Funktionen vorschlagen.

## Technologien:
- WPF (Windows Presentation Foundation): Entwickelt mit dem WPF-Framework zur Erstellung moderner Desktopanwendungen in Windows.

---

I hope this meets your requirements! Let me know if you need any further adjustments.

# Loading Spinner User Control

## Description:
The Loading Spinner user control is a custom control for WPF (Windows Presentation Foundation) that provides visually appealing spinner animation for displaying loading or processing states. This user control is available in German and features a memory-efficient animation method that utilizes tasks instead of storyboards.

## Features:
- **Customization**: Users can customize the appearance of the spinner by setting the static color and rotation color.
- **Adjustable Size**: The diameter and thickness of the spinner can be adjusted to support various UI designs and layouts.
- **Memory-Efficient Animation**: The spinner animation is designed to be memory-efficient by not using storyboards and only appearing when needed. The animation is triggered through a dependency property called IsBusy, which can be bound to boolean values. When IsBusy is set to true, the animation starts and rotates the inner ellipse. When IsBusy is set to false, the animation stops and disappears.

## Usage:
1. Add the Loading Spinner user control to your WPF project.
2. Integrate the user control into your XAML markup or instantiate it programmatically.
3. Customize the appearance of the spinner by setting properties for the static color, rotation color, diameter, and thickness.
4. Bind the IsBusy dependency property to boolean values in your ViewModel or code-behind file. When IsBusy is set to true, the animation starts automatically. When IsBusy is set to false, the animation stops and disappears.

## Properties:
- **StatischeFarbe**: Sets the color of the static part of the spinner.
- **Rotationsfarbe**: Sets the color of the rotating part of the spinner.
- **Durchmesser**: Sets the diameter of the spinner.
- **Starke**: Sets the thickness of the spinner.
- **IstBeschäftigt**: Bindable dependency property that controls the state of the spinner animation. When true, the animation starts. When false, the animation stops and disappears.

## Contribution:
You can use the Loading Spinner user control in your WPF projects without mentioning the creator. Contributions, feedback, and improvements are welcome. You can contribute to the project by submitting pull requests, reporting issues, or suggesting new features.

## Technologies:
- WPF (Windows Presentation Foundation): Developed using the WPF framework to create modern desktop applications on Windows.

---
I hope this meets your requirements! Let me know if you need any further adjustments.
