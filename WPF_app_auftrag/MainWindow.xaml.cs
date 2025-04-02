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
        List<Label> LabelList = new List<Label>();
        List<Button> ButtonList = new List<Button>();
        public MainWindow()
        {
            InitializeComponent();
            LabelList.Add(StartLabel);
            ButtonList.Add(textbutton);
            ButtonList.Add(colorbutton);
            ButtonList.Add(layoutbutton);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (Label label in LabelList)
            {
                label.Content = GenerateRandomtext();
            }
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
            //Random random = new Random();
            //SolidColorBrush startTextColor = new SolidColorBrush(GetRandomColor(random));
            //SolidColorBrush textButtonColor = new SolidColorBrush(GetRandomColor(random));
            //SolidColorBrush colorButtonColor = new SolidColorBrush(GetRandomColor(random));
            //SolidColorBrush layoutButtonColor = new SolidColorBrush(GetRandomColor(random));

            //StartLabel.Background = startTextColor;
            //textbutton.Background = textButtonColor;
            //colorbutton.Background = colorButtonColor;
            //layoutbutton.Background = layoutButtonColor;
            Random random = new Random();
            foreach (Button button in ButtonList)
            {
                //System.Threading.Thread.Sleep(2000);
                button.Background = new SolidColorBrush(GetRandomColor(random));
            }
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
            Label newLabel = new Label
            {
                Content = "Start Text",
                FontSize = 30,
                Width = 400,
                Height = 225,
                Margin = new Thickness(20),
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            Grid.SetRow(newLabel, 0);
            Grid.SetColumn(newLabel, 1);
            basicGrid.Children.Add(newLabel);
            LabelList.Add(newLabel);

            Button textbutton = new Button
            {
                Content = "Change text",
                Width = 400,
                Height = 50
            };
            textbutton.Click += Button_Click;
            Grid.SetRow(textbutton, 1);
            Grid.SetColumn(textbutton, 1);
            basicGrid.Children.Add(textbutton);
            ButtonList.Add(textbutton);

            Button colorbutton = new Button
            {
                Content = "Change color",
                Width = 400,
                Height = 50
            };
            colorbutton.Click += Button_Click_1;
            Grid.SetRow(colorbutton, 2);
            Grid.SetColumn(colorbutton, 1);
            basicGrid.Children.Add(colorbutton);
            ButtonList.Add(colorbutton);


            Button layoutbutton = new Button
            {
                Content = "Change layout",
                Width = 400,
                Height = 50
            };
            layoutbutton.Click += Layoutbutton_Click;
            Grid.SetRow(layoutbutton, 3);
            Grid.SetColumn(layoutbutton, 1);
            basicGrid.Children.Add(layoutbutton);
            ButtonList.Add(layoutbutton);

        }
    }
}
