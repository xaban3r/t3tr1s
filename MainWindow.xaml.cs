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

        public MainWindow()
        {
            InitializeComponent();
        }


        
    }
}
