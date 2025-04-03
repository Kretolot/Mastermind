using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace mastermind2
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Color[] pinColors =
        {
            Colors.Red, Colors.Green, Colors.Blue, Colors.Orange, Colors.Yellow, Colors.Gray, Colors.Purple, Colors.Pink
        };

        private Color[] secretPins;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void nowa(object sender, RoutedEventArgs e)
        {
            var jakaGra = MessageBox.Show("Chcesz losować piny z powtórzeniami?", "Wybór", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (jakaGra == MessageBoxResult.Yes)
            {
                secretPinsGenerator1();
            }
            else
            {
                secretPinsGenerator2();
            }
            newBoard();
        }

        private void newBoard()
        {

        }

        private void secretPinsGenerator1()
        {
            Random random = new Random();
            secretPins = Enumerable.Range(0, 4).Select(_ => pinColors[random.Next(pinColors.Length)]).ToArray();
            MessageBox.Show("Wylosowane: " + string.Join(" ", secretPins));
        }

        private void secretPinsGenerator2()
        {
            Random random = new Random();
            secretPins = pinColors.OrderBy(x => random.Next()).Take(4).ToArray();
            MessageBox.Show("Wylosowane: " + string.Join(" ", secretPins));
        }

        // kończenie po kliknięciu na krzyżyk
        protected override void OnClosing(CancelEventArgs e)
        {
            var odp = MessageBox.Show("Czy chcesz zakończyć?", "Koniec gry", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (odp != MessageBoxResult.Yes)
            {
                e.Cancel = true;
            }
            base.OnClosing(e);
        }

        // kończenie z poziomu menu
        private void konczenie(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void checkGame_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
