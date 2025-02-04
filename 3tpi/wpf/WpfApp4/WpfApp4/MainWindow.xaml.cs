using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApp4
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public ObservableCollection<string> Images { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Images = new ObservableCollection<string>
            {
                "images/zdj1.jpg",
                "images/zdj2.jpg",
                "images/zdj3.jpg",
                "images/zdj4.jpg"
            };
            DataContext = this;
        }

        private void lbChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                string selectedIMG = e.AddedItems[0] as string;
                if (!string.IsNullOrEmpty(selectedIMG))
                {
                    new Image2(selectedIMG).Show();
                }
            }
        }
    }
}
