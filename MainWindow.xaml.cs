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
using System.Windows.Threading;
using System.IO;

namespace t3tr1s
{
    public partial class MainWindow : Window
    {
        const int nextGridSize = 4;
        private Game game;
        private Rectangle rectangle = new Rectangle();
        private List<List<Rectangle>> rectangles = new List<List<Rectangle>>(Game.Columns);
        private List<List<Rectangle>> nextRectangles = new List<List<Rectangle>>(nextGridSize);
        public static string statTime;
        Stopwatch Timer = new Stopwatch();
        private static string[] allStatLines;
        public string[] GetAllStatLines { get { return allStatLines; } }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GridCreate();
            GetStat();
        }

        private void GridCreate()
        {
            for (int i = 0; i < Game.Columns; i++)
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

            for (int i = 0; i < nextGridSize; i++)
            {
                nextRectangles.Add(new List<Rectangle>());
                for (int j = 0; j < nextGridSize; j++)
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
        }

        private void NewGame()
        {
            GetStat();
            score.Text = "0";
            level.Text = "0";
            game = null;
            game = new Game();
            game.StartTheGame();
            DrawingTheGame();
            game.ThreadMoveDown += gameThread;
            Timer.Restart();
            StopWatchTimer();
        }

        private void gameThread()
        {
            Dispatcher.Invoke(() =>
            {
                KeyDownMethod(Key.Down);
                StopWatchTimer();
            });
        }

        private void DrawingTheGame()
        {
            rectangles.ForEach(row => row.ForEach(col => col.Fill = new SolidColorBrush(Colors.White)));
            nextRectangles.ForEach(row => row.ForEach(col => col.Fill = new SolidColorBrush(Colors.White)));
            game.GetAllEllements().ForEach(el => { DrawOne(el.x, el.y, el.color); });
            if (!game.isEndGame)
            {
                game.GetFigure.Elements.ForEach(el => { DrawOne(el.x, el.y, el.color); });
            }
            DrawNext();
        }
       
        private void DrawOne(int x, int y, Color color)
        {
            try
            {
                rectangles[y][x].Fill = new SolidColorBrush(color);
            }
            catch (ArgumentOutOfRangeException)
            { }
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
                case Key.Up:
                    {
                        game.Rotate();
                        break;
                    }
            }
            score.Text = game.Score.ToString();
            DrawingTheGame();
            level.Text = game.Lvl.ToString();
            
        }

        private void DrawNext()
        {
            List<FieldElement> next = game.GetNextFigure.Elements;
            int minX = next.Min(p => p.x);
            int minY = next.Min(p => p.y);
            int maxX = next.Max(p => p.x);
            int maxY = next.Max(p => p.y);
            int coefX = minX;
            int coefY = 0;
            if ((maxX - minX) < 3) coefX -= 1;
            if ((maxY - minY) < 3) coefY += 1;
            foreach (FieldElement el in next)
            {
                    nextRectangles[el.y + coefY][el.x - coefX].Fill = new SolidColorBrush(el.color);
            }
        }

        private void StopWatchTimer()
        {
            TimeSpan ts = Timer.Elapsed;
            timer.Text = ts.Minutes.ToString() + ":" + ts.Seconds.ToString();
            statTime = timer.Text;
        }

        public void GetStat()
        {
            if (!File.Exists(Game.path))
            {
                File.Create(Game.path);
            }
            else
            {
                allStatLines = File.ReadAllLines(Game.path);
                results.Text = String.Empty;
                for (int i = allStatLines.Length - 1; i > 0; i--)
                {
                    results.Text += allStatLines[i] + "\n";
                }
            }
        }
/*===========================================================================================*/
        private void StartTheGame_Click(object sender, RoutedEventArgs e)
        {
            if (game != null) game.EndGame();
            NewGame();
        }
        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            //maybe focus
            if (game.isPause)
            {
                game.isPause = false;
                Timer.Start();
            }
            else
            {
                game.isPause = true;
                Timer.Stop();
            }
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
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (game != null) 
            game.EndGame();
            
        }
    }
}
