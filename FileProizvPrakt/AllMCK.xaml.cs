using System;
using System.Collections.Generic;
using System.Data;
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
    /// <summary>
    /// Логика взаимодействия для AllMCK.xaml
    /// </summary>
    public partial class AllMCK : Window
    {

        public int gru = 1;
        DataSet1 dataSet1 = new DataSet1();
        StudentTableAdapter STA = new StudentTableAdapter();
        Group1TableAdapter GTA = new Group1TableAdapter();
        P50_2_19TableAdapter _2STA = new P50_2_19TableAdapter();


        public AllMCK()
        {
            InitializeComponent();
            data.ItemsSource = dataSet1.Student.DefaultView;
            STA.Fill(dataSet1.Student);
            GTA.Fill(dataSet1.Group1);
            group.DisplayMemberPath = "Название группы";
            group.ItemsSource = dataSet1.Group1.AsDataView();
            group.SelectedIndex = -1;
        }


        private void DOB_sotr_Login(object sender, RoutedEventArgs e)
        {
            try
            {
                if (nam.Text == "Название организации" && fio.Text == "Название организации" || nam.Text == "ФИО студента" || fio.Text == "ФИО студента")
                { MessageBox.Show("Добавьте данные!"); }
                else
                {
                   STA.InsertQuery(nam.Text, fio.Text, group.Text, ruktech.Text, rukorg.Text);
                   STA.Fill(dataSet1.Student);
                }
                nam.Text = "Название организации";
                fio.Text = "ФИО студента";
                ruktech.Text = "Руководитель от техникума";
                rukorg.Text = "Руководитель от компании";
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
                    int id = (int)preobraz["Номер студента"];
                    STA.UpdateQuery(nam.Text, fio.Text, group.Text, ruktech.Text, rukorg.Text, id);
                    STA.Fill(dataSet1.Student);
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
                int id = (int)preobraz["Номер студента"];
                STA.DeleteQuery(id);
                STA.Fill(dataSet1.Student);
            }
            else { MessageBox.Show("Нельзя удалить пустое поле"); }
        }

        private void EXIT_2(object sender, RoutedEventArgs e)
        {
            MainWindow back = new MainWindow();
            back.Show();
            this.Close();
        }

        private void nam_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //e.Handled = "йцукёенгшщзхъэждлорпавыфячсмитьбю.ЙЦУКЕНГШЩЗХЪЭЖДЛОРПАВЫФЯЧСМИТЬБЮЁ".IndexOf(e.Text) < 0;
        }

        private void adre_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "йцукёенгшщзхъэждлорпавыфячсмитьбю.ЙЦУКЕНГШЩЗХЪЭЖДЛОРПАВЫФЯЧСМИТЬБЮЁ".IndexOf(e.Text) < 0;
        }

        private void rukorg_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "йцукёенгшщзхъэждлорпавыфячсмитьбю.ЙЦУКЕНГШЩЗХЪЭЖДЛОРПАВЫФЯЧСМИТЬБЮЁ".IndexOf(e.Text) < 0;
        }

        private void ruktech_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "йцукёенгшщзхъэждлорпавыфячсмитьбю.ЙЦУКЕНГШЩЗХЪЭЖДЛОРПАВЫФЯЧСМИТЬБЮЁ".IndexOf(e.Text) < 0;
        }

        private void got1(object sender, RoutedEventArgs e)
        {
            if (nam.Text == "Название организации")
                nam.Clear();
        }

        private void los1(object sender, RoutedEventArgs e)
        {
            if (nam.Text == "")
                nam.Text = "Название организации";
        }

        private void got2(object sender, RoutedEventArgs e)
        {
            if (fio.Text == "ФИО студента")
                fio.Clear();
        }
        private void los2(object sender, RoutedEventArgs e)
        {
            if (fio.Text == "")
                fio.Text = "ФИО студента";
        }
        private void got3(object sender, RoutedEventArgs e)
        {
            if (ruktech.Text == "Руководитель от техникума")
                ruktech.Clear();
        }

        private void los3(object sender, RoutedEventArgs e)
        {
            if (ruktech.Text == "")
                ruktech.Text = "Руководитель от техникума";
        }

        private void got4(object sender, RoutedEventArgs e)
        {
            if (rukorg.Text == "Руководитель от компании")
                rukorg.Clear();
        }
        private void los4(object sender, RoutedEventArgs e)
        {
            if (rukorg.Text == "")
                rukorg.Text = "Руководитель от компании";
        }

        private void П50_1_19(object sender, RoutedEventArgs e)
        {
            data.ItemsSource = dataSet1.Student.DefaultView;
            gru = 1;
            group.Items.Clear();
            group.Items.Add("П50-1-19");
            group.Items.Add("П50-11/1-20");
        }

        private void П50_2_19(object sender, RoutedEventArgs e)
        {
            data.ItemsSource = dataSet1.P50_2_19.DefaultView;
            gru = 2;
            group.Items.Clear();
            group.Items.Add("П50-2-19");
        }

        private void П50_3_19(object sender, RoutedEventArgs e)
        {
            data.ItemsSource = dataSet1.P50_3_19.DefaultView;
            gru = 3;
            group.Items.Clear();
            group.Items.Add("П50-3-19");
            group.Items.Add("П50-11/3-20");
        }

        private void П50_4_19(object sender, RoutedEventArgs e)
        {
            data.ItemsSource = dataSet1.P50_4_19.DefaultView;
            gru = 4;
            group.Items.Clear();
            group.Items.Add("П50-4-19");
            group.Items.Add("П50-11/4-20");
        }

        private void П50_5_19(object sender, RoutedEventArgs e)
        {
            data.ItemsSource = dataSet1.P50_5_19.DefaultView;
            gru = 5;
            group.Items.Clear();
            group.Items.Add("П50-5-19");
            group.Items.Add("П50-11/5-20");
        }

        private void П50_6_19(object sender, RoutedEventArgs e)
        {
            data.ItemsSource = dataSet1.P50_6_19.DefaultView;
            gru = 6;
            group.Items.Clear();
            group.Items.Add("П50-6-19");
            group.Items.Add("П50-11/6-20");
        }

        private void Print(object sender, RoutedEventArgs e)
        {
            //PrintDialog p = new PrintDialog();
            //if (p.ShowDialog() == true)
            //{
            //    p.PrintVisual(data, "Студенты");
            //}
            //Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            //ExcelApp.Application.Workbooks.Add(Type.Missing);
            //ExcelApp.Columns.ColumnWidth = 15;

            //ExcelApp.Cells[1, 1] = "№п/п";
            //ExcelApp.Cells[1, 2] = "Число";
            //ExcelApp.Cells[1, 3] = "Название";
            //ExcelApp.Cells[1, 4] = "Количество";
            //ExcelApp.Cells[1, 5] = "Цена ОПТ";
            //ExcelApp.Cells[1, 6] = "Цена Розница";
            //ExcelApp.Cells[1, 7] = "Сумма";

            //for (int i = 0; i < dataSet1.ColumnCount; i++)
            //{
            //    for (int j = 0; j < dataSet1.RowCount; j++)
            //    {
            //        ExcelApp.Cells[j + 2, i + 1] = (dataSet1[i, j].Value).ToString();
            //    }
            //}
            //ExcelApp.Visible = true;
        }

        private void AddGroup(object sender, RoutedEventArgs e)
        {
            Group go = new Group();
            go.Show();
            this.Close();
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            string dwed = search.Text;
            for (int i = 0; i < dataSet1.Student.Rows.Count; i++)
            {
                if ((dataSet1.Student.Rows[i][4].ToString()).Contains(dwed))
                {
                    data.SelectedIndex = i;
                    return;
                }
            }
        }

        private void search_LostFocus(object sender, RoutedEventArgs e)
        {

            if (search.Text == "")
                search.Text = "Поиск";
        }

        private void search_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void search_GotFocus(object sender, RoutedEventArgs e)
        {
            if (search.Text == "Поиск")
                search.Clear();
        }
    }
}

