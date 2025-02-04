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

namespace WpfApp3
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void okno3_click(object sender, RoutedEventArgs e)
        {
            var odp = MessageBox.Show("wybierz 1 z 3", "Wybor", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

            if (odp == MessageBoxResult.Yes)
            {
                MessageBox.Show("Wybrano yes", "odp", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (odp == MessageBoxResult.No)
            {
                MessageBox.Show("Wybrano No", "odp", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Wybrano Cancel", "odp", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
