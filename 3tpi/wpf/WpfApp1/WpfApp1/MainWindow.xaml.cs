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

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool x = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (x != true)
            {
                var odp = MessageBox.Show("Czy chcesz zamknąć aplikację?", "Zamykanie aplikacji", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

                if (odp != MessageBoxResult.Yes)
                {
                    e.Cancel = true;
                }
                base.OnClosing(e);
            }
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {

        }
        private void kopiuj(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txt.SelectedText))
            {
                Clipboard.SetText(txt.SelectedText);
            }
        }
        private void wklej(object sender, RoutedEventArgs e)
        {
            if (Clipboard.ContainsText(txt.SelectedText)
            {
                Clipboard.GetText();
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var odp = MessageBox.Show("Czy chcesz zamknąć aplikację?", "Zamykanie aplikacji", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);


            if (odp == MessageBoxResult.Yes)
            {
                x = true;
                Application.Current.Shutdown();
            }
        }
    }
}
