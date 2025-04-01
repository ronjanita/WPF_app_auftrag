using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_app_auftrag
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> labelList = new List<string>();
        List<SolidColorBrush> buttonList = new List<SolidColorBrush>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string randomText = GenerateRandomtext();
            StartLabel.Content = randomText;
            labelList.Add(StartLabel.Content.ToString());   
        }
        private string GenerateRandomtext()
        {
            Random random = new Random();
            string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            string randomText = "";

            for (int i = 0; i < 50; i++)
            {
                randomText += characters[random.Next(characters.Length)];  //macht einen zufälligen index von 0-de rlöänge der zeichenkette und der char teil wählt ein zufälliges zeichen bassieren auf dem index aus.
            }
            return randomText;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            SolidColorBrush startTextColor = new SolidColorBrush(GetRandomColor(random));
            SolidColorBrush textButtonColor = new SolidColorBrush(GetRandomColor(random));
            SolidColorBrush colorButtonColor = new SolidColorBrush(GetRandomColor(random));
            SolidColorBrush layoutButtonColor = new SolidColorBrush(GetRandomColor(random));

            StartLabel.Background = startTextColor;
            textbutton.Background = textButtonColor;
            colorbutton.Background = colorButtonColor;
            layoutbutton.Background = layoutButtonColor;

            buttonList.Add(startTextColor);
            buttonList.Add(textButtonColor);
            buttonList.Add(colorButtonColor);
            buttonList.Add(layoutButtonColor);
        }
        private Color GetRandomColor(Random random)
        {
            byte r = (byte)random.Next(256);  // Rot
            byte g = (byte)random.Next(256);  // Grün
            byte b = (byte)random.Next(256);  // Blau
            Color randomColor = Color.FromRgb(r, g, b);   //Color.FromRgb ist eine methode wleche eine neue farbe rgb farbe aus den drei werten die vporer deklariert wurden anzeigt
            return randomColor;
        }

        private void Layoutbutton_Click(object sender, RoutedEventArgs e)
        {
            textbutton2.Click += Button_Click;
            {
                labelList.Add(StartLabel2.Content.ToString());
            }
            colorbutton2.Click += Button_Click_1;
            layoutbutton2.Click += Layoutbutton_Click;
        }
    }
}
