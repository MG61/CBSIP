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
using System.Windows.Shapes;

namespace FileProizvPrakt
{
    /// <summary>
    /// Логика взаимодействия для MenuAdmin.xaml
    /// </summary>
    public partial class MenuMCK : Window
    {
        public MenuMCK()
        {
            InitializeComponent();
        }

        private void EXIT_2(object sender, RoutedEventArgs e)
        {
            MainWindow back = new MainWindow();
            back.Show();
            this.Close();
        }

        private void P(object sender, RoutedEventArgs e)
        {
            MCK2 go = new MCK2();
            go.Show();
            this.Close();
        }

        private void VD(object sender, RoutedEventArgs e)
        {
            MCK22 go = new MCK22();
            go.Show();
            this.Close();
        }
    }
}
