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
using System.Diagnostics;


namespace t3tr1s
{
    
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       // readonly static int nextAndHoldGridSize = 4;
        const int nextAndHoldGridSize = 4;
        private Game game = new Game();
        private Rectangle rectangle = new Rectangle();
        private List<List<Rectangle>> rectangles = new List<List<Rectangle>>(Game.Columns);
        private List<List<Rectangle>> nextRectangles = new List<List<Rectangle>>(nextAndHoldGridSize);
        private List<List<Rectangle>> holdRectangles = new List<List<Rectangle>>(nextAndHoldGridSize);


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GridCreate();
            //NewGame();
        }

   


       
        private void GridCreate()
        {
            for (int i = 0; i<Game.Columns; i++)
            {
                mainGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int i = 0; i < Game.Rows; i++)
            {
                mainGrid.RowDefinitions.Add(new RowDefinition());
            }

            for (int i = 0; i < Game.Rows; i++)
            {
                rectangles.Add(new List<Rectangle>());
                for (int j = 0; j < Game.Columns; j++)
                {
                    rectangle = new Rectangle
                    {                                                               // Размер содержимого изменяется, чтобы заполнить размеры назначения.
                        Stretch = Stretch.Fill                                      // Соотношение сторон не сохраняется.
                    };
                    rectangle.Margin = new Thickness(1);
                    rectangle.Fill = new SolidColorBrush(Colors.White);
                    Grid.SetColumn(rectangle, j);
                    Grid.SetRow(rectangle, i);
                    mainGrid.Children.Add(rectangle);
                    rectangles[i].Add(rectangle);
                }
            }

            for (int i = 0; i < nextAndHoldGridSize; i++)
            {
                nextRectangles.Add(new List<Rectangle>());
                for (int j = 0; j < nextAndHoldGridSize; j++)
                {
                    rectangle = new Rectangle
                    {                                                               // Размер содержимого изменяется, чтобы заполнить размеры назначения.
                        Stretch = Stretch.Fill                                      // Соотношение сторон не сохраняется.
                    };
                    rectangle.Margin = new Thickness(1);
                    rectangle.Fill = new SolidColorBrush(Colors.White);
                    Grid.SetColumn(rectangle, j);
                    Grid.SetRow(rectangle, i);
                    gridNext.Children.Add(rectangle);
                    nextRectangles[i].Add(rectangle);
                }
            }

            for (int i = 0; i < nextAndHoldGridSize; i++)
            {
                holdRectangles.Add(new List<Rectangle>());
                for (int j = 0; j < nextAndHoldGridSize; j++)
                {
                    rectangle = new Rectangle
                    {                                                               // Размер содержимого изменяется, чтобы заполнить размеры назначения.
                        Stretch = Stretch.Fill                                      // Соотношение сторон не сохраняется.
                    };
                    rectangle.Margin = new Thickness(1);
                    rectangle.Fill = new SolidColorBrush(Colors.White);
                    Grid.SetColumn(rectangle, j);
                    Grid.SetRow(rectangle, i);
                    gridHold.Children.Add(rectangle);
                    holdRectangles[i].Add(rectangle);
                }
            }
        }

        private void NewGame()
        {
            game = null;
            game = new Game();
            //DrawingTheGame();
            game.StartTheGame();
            DrawingTheGame();
            game.ThreadMoveDown += gameThread;
        }

        void gameThread()
        {
            Dispatcher.Invoke(() =>
            {
                KeyDownMethod(Key.Down);
            });
        }

        

        private void DrawingTheGame()
        {
            rectangles.ForEach(row => row.ForEach(col => col.Fill = new SolidColorBrush(Colors.White)));
            nextRectangles.ForEach(row => row.ForEach(col => col.Fill = new SolidColorBrush(Colors.White)));
            holdRectangles.ForEach(row => row.ForEach(col => col.Fill = new SolidColorBrush(Colors.White)));
            game.GetAllEllements().ForEach(el => { DrawOne(el.x, el.y, el.color); });
            if (!game.isEndGame)
            {
                game.GetFigure.Elements.ForEach(el => { DrawOne(el.x, el.y, el.color); });
            }
            //draw next();
        }
       
        private void DrawOne(int x, int y, Color color)
        {
            rectangles[y][x].Fill = new SolidColorBrush(color);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            KeyDownMethod(e.Key);
        }

        private void KeyDownMethod(Key key)
        {
            if (game.isEndGame)
            {
                return;
            }
            switch (key)
            {

                case Key.Left:
                    {
                        game.LeftMove();
                        break;
                    }
                case Key.Right:
                    {
                        game.RightMove();
                        break;
                    }
                case Key.Down:
                    {
                        game.DownMove();
                        break;
                    }
                    /* case Key.Up:
                         {
                             game.Rotate();
                             break;
                         }*/
            }
            DrawingTheGame();
        }
        
        /*===========================================================================================*/
        private void StartTheGame_Click(object sender, RoutedEventArgs e)
        {
            NewGame();
        }
        private void vkButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://vk.com/bestpointguard");
        }

        private void gitHubButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://github.com/xaban3r/t3tr1s");
        }

        private void tgButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://t.me/bestpointguard");
        }

        
    }
}
