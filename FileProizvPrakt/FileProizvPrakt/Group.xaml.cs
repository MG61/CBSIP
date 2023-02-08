using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using FileProizvPrakt.DataSet1TableAdapters;

namespace FileProizvPrakt
{
    public partial class Group : Window
    {   
        DataSet1 dataSet1 = new DataSet1();
        Group1TableAdapter GTA = new Group1TableAdapter();

        public Group()
        {
            InitializeComponent();
            data.ItemsSource = dataSet1.Group1.DefaultView;
            GTA.Fill(dataSet1.Group1);
        }

        private void DOB_sotr_Login(object sender, RoutedEventArgs e)
        {
            try
            {
                GTA.InsertQuery(group1.Text);
                GTA.Fill(dataSet1.Group1);


                    string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=FileProizvPrakt;Integrated Security=True;";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.OpenAsync();

                        SqlCommand command = new SqlCommand();
                        command.CommandText = "CREATE TABLE Users (Id INT PRIMARY KEY IDENTITY, Age INT NOT NULL, Name NVARCHAR(100) NOT NULL)";
                        command.Connection = connection;
                        command.ExecuteNonQueryAsync();

                        Console.WriteLine("Таблица Users создана");
                    }
                    Console.Read();
                
            }

            catch
            {
                MessageBox.Show("Названия не должны повторяться!");
            }
        }


        private void UPDATE_sotr_Login(object sender, RoutedEventArgs e)
        {
            try
            {
                if (data.SelectedItem != null)
                {
                    DataRowView preobraz = (DataRowView)data.SelectedItem;
                    int id = (int)preobraz["Номер группы"];
                    GTA.UpdateQuery(group1.Text, id);
                    GTA.Fill(dataSet1.Group1);
                }
            }
            catch
            {
                MessageBox.Show("Названия не должны повторяться!");
            }
        }

        private void DELETE_sotr_Login(object sender, RoutedEventArgs e)
        {
            if (data.SelectedItem != null)
            {
                DataRowView preobraz = (DataRowView)data.SelectedItem;
                int id = (int)preobraz["Номер группы"];
                GTA.DeleteQuery(id);
                GTA.Fill(dataSet1.Group1);
            }
            else { MessageBox.Show("Нельзя удалить пустое поле"); }
        }

        private void EXIT_2(object sender, RoutedEventArgs e)
        {
            AllMCK back = new AllMCK();
            back.Show();
            this.Close();
        }

        //public static async Task dob(string[] args)
        //{
        //    string connectionString = "Server=(localdb)\\mssqllocaldb;Database=adonetdb;Trusted_Connection=True;";
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        await connection.OpenAsync();

        //        SqlCommand command = new SqlCommand();
        //        command.CommandText = "CREATE TABLE Users (Id INT PRIMARY KEY IDENTITY, Age INT NOT NULL, Name NVARCHAR(100) NOT NULL)";
        //        command.Connection = connection;
        //        await command.ExecuteNonQueryAsync();

        //        Console.WriteLine("Таблица Users создана");
        //    }
        //    Console.Read();
        //}

    }
}
