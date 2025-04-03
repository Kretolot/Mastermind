using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace kolkaa
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            int liczbaKolek = int.Parse(txtIle.Text);
            Random random = new Random();

            Brush[] kolory = new Brush[]
            {
                Brushes.Red, Brushes.Green, Brushes.Blue, Brushes.Yellow, Brushes.Purple, Brushes.Cyan, Brushes.Magenta, Brushes.Cyan, Brushes.Pink, Brushes.Black, Brushes.Orange,
            };

            for (int i = 0; i < liczbaKolek; i++)
            {
                int rozmiar = random.Next(20, 101);
                Ellipse kolo = new Ellipse
                {
                    Width = rozmiar,
                    Height = rozmiar,
                    Fill = kolory[random.Next(kolory.Length)]
                };

                Canvas.SetLeft(kolo, random.Next((int)canvas.ActualWidth));
                Canvas.SetTop(kolo, random.Next((int)canvas.ActualHeight));
                canvas.Children.Add(kolo);
            }
        }
    }
}
