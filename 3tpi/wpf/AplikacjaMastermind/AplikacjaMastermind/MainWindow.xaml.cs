using System;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AplikacjaMastermind
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //Deklaracja tablicy kolorów
        private readonly Color[] pinColors =
        {
            Colors.Red,
            Colors.Green,
            Colors.Blue,
            Colors.Orange,
            Colors.Indigo,
            Colors.Yellow,
            Colors.Purple
        };

        //Zmienna przechowująca ukryte i wylosowane kolory
        private Color[] secretPins;

        private int currentRow = 0;



        //MAIN
        public MainWindow()
        {
            InitializeComponent();
        }

        //Sprawdzanie pinów
        private void CheckGame_Click(object sender, RoutedEventArgs e)
        {
            if (currentRow > 9) return;
            StackPanel currentPanel = MainBoard.Children[currentRow] as StackPanel;
            StackPanel mainCiclePanel = currentPanel.Children[0] as StackPanel;
            Grid feedbackGrid = currentPanel.Children[1] as Grid;

            //pobieranie kolorów z mainCircle
            Color[] quess = new Color[4];
            for (int i = 0; i < 4; i++)
            {
                if (mainCiclePanel.Children[i] is Ellipse circle)
                {
                    Color chosen = ((SolidColorBrush)circle.Fill).Color;
                    quess[i] = chosen;
                }

                MessageBox.Show("wybrane: " + string.Join(", ", quess));
            }

        }

        //Nowa gra
        private void MenuNew(object sender, RoutedEventArgs e)
        {
            var PinSelect = MessageBox.Show("Chcesz losować piny z powtórzeniami?", "Wybór", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (PinSelect == MessageBoxResult.Yes)
            {
                secretPinsGenerator();
            }
            else
            {
                secretPinsGenerator2();
            }
            newBoard();
        }

        //Nowa plansza do gry
        private void newBoard()
        {
            for (int i = 0; i < 10; i++)
            {
                StackPanel rowPanel = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    Margin = new Thickness(5),
                };
                rowPanel.Tag = i;

                StackPanel mainCirclePanel = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                };
                if (i != 9)
                {

                    //Pętla do 4 pinów w szeregu
                    for (int j = 0; j < 4; j++)
                    {
                        mainCirclePanel.Children.Add(createCircle(30, false, true));
                    }
                }
                else
                {
                    //Pętla do 4 pinów w szeregu
                    for (int j = 0; j < 4; j++)
                    {
                        mainCirclePanel.Children.Add(createCircle(30, true, true));
                    }
                    currentRow = 9;
                }

                //Grid na piny z odpowiedzią
                Grid FeedbackGrid = new Grid
                {
                    Width = 60,
                    Height = 60,
                    Margin = new Thickness(10, 0, 0, 0)
                };
                FeedbackGrid.RowDefinitions.Add(new RowDefinition());
                FeedbackGrid.RowDefinitions.Add(new RowDefinition());
                FeedbackGrid.ColumnDefinitions.Add(new ColumnDefinition());
                FeedbackGrid.ColumnDefinitions.Add(new ColumnDefinition());

                for (int x = 0; x < 2; x++)
                {
                    for (int y = 0; y < 2; y++)
                    {
                        Ellipse FeedbackCircle = createCircle(20, true, false);
                        Grid.SetRow(FeedbackCircle, x);
                        Grid.SetColumn(FeedbackCircle, y);
                        FeedbackGrid.Children.Add(FeedbackCircle);
                    }
                }

                //Dodanie do MainBoard
                rowPanel.Children.Add(mainCirclePanel);
                rowPanel.Children.Add(FeedbackGrid);
                MainBoard.Children.Add(rowPanel);
            }
        }

        //Wybór kolorów pinów
        private void openColorPicker(Ellipse circle, Color[] openColors)
        {
            if (!circle.IsEnabled || circle == null) return;

            ContextMenu colorMenu = new ContextMenu();
            foreach (Color color in openColors)
            {
                MenuItem item = new MenuItem
                {
                    Header = color.ToString(),
                    Background = new SolidColorBrush(color)
                };
                //nasłuch na klikniecie z wyborem koloru i zmianą koloru
                item.Click += (s, e) => circle.Fill = new SolidColorBrush(color);
                colorMenu.Items.Add(item);
            }

            circle.ContextMenu = colorMenu;
            colorMenu.IsOpen = true;

        }

        //Tworzenie pinów
        private Ellipse createCircle(int size, bool isVisible, bool isMainCircle)
        {
            Ellipse circle = new Ellipse
            {
                Width = size,
                Height = size,
                Fill = new SolidColorBrush(Colors.LightGray),
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Margin = new Thickness(5),
                IsEnabled = isVisible
            };

            //Wywołanie click na mysz by dodać kolor
            if (isMainCircle)
            {
                circle.MouseLeftButtonDown += (s, e) => openColorPicker(s as Ellipse, pinColors);
            }
            else
            {
                circle.MouseLeftButtonDown += (s, e) => openColorPicker(s as Ellipse, new Color[] { Colors.White, Colors.Black });
            }
            return circle;
        }

        //Metoda generująca piny z powtórzeniami
        private void secretPinsGenerator()
        {
            Random random = new Random();
            secretPins = Enumerable.Range(0, 4).Select(_ => pinColors[random.Next(pinColors.Length)]).ToArray();
            kolorki.Text = ("W: " + string.Join(" ", secretPins));
        }

        //Metoda generująca piny bez powtórzeń
        private void secretPinsGenerator2()
        {
            Random random = new Random();
            secretPins = pinColors.OrderBy(_ => random.Next()).Take(4).ToArray();
            kolorki.Text = ("W: " + string.Join(" ", secretPins));
        }
        //Zakończenie programu poprzez X
        protected override void OnClosing(CancelEventArgs e)
        {
            var odp = MessageBox.Show("Czy chcesz zakończyć grę?", "Zakończ", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (odp != MessageBoxResult.Yes)
            {
                e.Cancel = true;
            }
            base.OnClosing(e);
        }

        //Zakończenie programu poprzez menu wywołując nadpisaną metodę OnClosing ^^
        private void MenuEnd(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}