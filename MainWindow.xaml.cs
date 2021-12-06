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
//using Logic;


namespace t3tr1s
{
    
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly static int nextAndHoldGridSize = 4;
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
            NewGame();
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
                    Thickness ts = new Thickness(1);
                    // rectangle.Margin = new Thickness(1);
                    rectangle.Margin = ts;
                    rectangle.Fill = new SolidColorBrush(Colors.Black);
                    Grid.SetColumn(rectangle, j);
                    Grid.SetRow(rectangle, i);
                    mainGrid.Children.Add(rectangle);
                    rectangles[i].Add(rectangle);
                }
            }
            /*
             * ЭТО НУЖНО ЗАСУНУТЬ С НЕКСТ И В ХОЛД 
             * 
             * 
            for (int i = 0; i < 4; i++)
            {
                nextRectangles.Add(new List<Rectangle>());
                for (int j = 0; j <4; j++)
                {
                    rectangle = new Rectangle
                    {                                                               // Размер содержимого изменяется, чтобы заполнить размеры назначения.
                        Stretch = Stretch.Fill                                      // Соотношение сторон не сохраняется.
                    };
                    Thickness ts = new Thickness(4);
                    // rectangle.Margin = new Thickness(1);
                    rectangle.Margin = ts;
                    rectangle.Fill = new SolidColorBrush(Colors.Black);
                    Grid.SetColumn(rectangle, j);
                    Grid.SetRow(rectangle, i);
                    mainGrid.Children.Add(rectangle);
                    nextRectangles[i].Add(rectangle);
                }

            }
            */
        }

        private void NewGame()
        {
            game = null;
            game = new Game();
            DrawingTheGame();

        }







        
        private void DrawingTheGame()
        {
            rectangles.ForEach(row => row.ForEach(col => col.Fill = new SolidColorBrush(Colors.Blue)));
            //nextRectangles.ForEach(row => row.ForEach(col => col.Fill = new SolidColorBrush(Colors.Blue)));
        }
       












        /*===========================================================================================*/
        private void vkButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://vk.com/bestpointguard");
        }

        private void gitHubButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://vk.com/bestpointguard");
        }

        private void tgButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://t.me/bestpointguard");
        }


        
    }
}
