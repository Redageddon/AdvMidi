using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace AdvMidi.Modes
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            
            int[] cases = { 88,87,86,85,84,83,82,81,78,77,76,75,74,73,72,71,68,67,66,65,64,63,62,61,58,57,56,55,54,53,52,51,48,47,46,45,44,43,42,41,38,37,36,35,34,33,32,31,28,27,26,25,24,23,22,21,18,17,16,15,14,13,12,11};
            
            Style buttonStyle = new Style(typeof(Button));
            buttonStyle.Setters.Add(new Setter(BackgroundProperty, new SolidColorBrush(Colors.White)));
            buttonStyle.Setters.Add(new Setter(HeightProperty, 50d));
            buttonStyle.Setters.Add(new Setter(WidthProperty, 50d));
            buttonStyle.Setters.Add(new Setter(BorderBrushProperty, new SolidColorBrush(Colors.Black)));
            buttonStyle.Setters.Add(new Setter(MarginProperty, new Thickness(10)));
            
            for (var i = 0; i < 8; i++)
            {
                for (var e = 7; e >= 0; e--) 
                { 
                    var button = new Button {Style = buttonStyle, Content = cases[ e + i * 8]};
                    button.Click += ButtonClicked;
                    LayoutRoot.Children.Add(button);
                } 
            }
        }
        
            
        private void ButtonClicked(object sender, RoutedEventArgs e)
        {
            /*Button test = (Button) sender;
            var key = Console.ReadKey();
            Console.WriteLine("\n here: " + key.Key);
            test.Content = "new";*/
            
            
            EventManager.RegisterClassHandler(typeof(Window), Keyboard.KeyUpEvent,new KeyEventHandler(keyUp), true);
            void keyUp(object keySender, KeyEventArgs k)
            {
                Button test = (Button) sender;
                Console.WriteLine();
                Console.WriteLine(k.Key);
            }
        }
    }
}