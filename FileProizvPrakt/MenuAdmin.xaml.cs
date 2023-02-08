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
    public partial class MenuAdmin : Window
    {
        public MenuAdmin()
        {
            InitializeComponent();
        }

        private void EXIT_2(object sender, RoutedEventArgs e)
        {
            MainWindow back = new MainWindow();
            back.Show();
            this.Close();
        }

        private void Medication(object sender, RoutedEventArgs e)
        {
            MCK go = new MCK();
            go.Show();
            this.Close();
        }

        private void Order(object sender, RoutedEventArgs e)
        {
            Admin go = new Admin();
            go.Show();
            this.Close();
        }

        private void group1(object sender, RoutedEventArgs e)
        {
            Group go = new Group();
            go.Show();
            this.Close();
        }

        private void VD(object sender, RoutedEventArgs e)
        {
            MCK2Group go = new MCK2Group();
            go.Show();
            this.Close();
        }
    }
}
