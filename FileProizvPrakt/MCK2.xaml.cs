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
using Excel = Microsoft.Office.Interop.Excel;

namespace FileProizvPrakt
{

    public partial class MCK2 : Window
    {
        public int gru = 1;
        DataSet1 dataSet1 = new DataSet1();
        StudentTableAdapter STA = new StudentTableAdapter();
        P50_2_19TableAdapter _2STA = new P50_2_19TableAdapter();
        P50_3_19TableAdapter _3STA = new P50_3_19TableAdapter();
        P50_4_19TableAdapter _4STA = new P50_4_19TableAdapter();
        P50_5_19TableAdapter _5STA = new P50_5_19TableAdapter();
        P50_6_19TableAdapter _6STA = new P50_6_19TableAdapter();

        public MCK2()
        {
            InitializeComponent();
            data.ItemsSource = dataSet1.Student.DefaultView;
            STA.Fill(dataSet1.Student);
            _2STA.Fill(dataSet1.P50_2_19);
            _3STA.Fill(dataSet1.P50_3_19);
            _4STA.Fill(dataSet1.P50_4_19);
            _5STA.Fill(dataSet1.P50_5_19);
            _6STA.Fill(dataSet1.P50_6_19);
            group.Items.Add("П50-1-19");
            group.Items.Add("П50-11/1-20");
            nam.IsEnabled = false;
            fio.IsEnabled = false;
            group.IsEnabled = false;
            rukorg.IsEnabled = false;
        }


        private void UPDATE_sotr_Login(object sender, RoutedEventArgs e)
        {
            try
            {
                if (data.SelectedItem != null)
                {
                    switch (gru)
                    {
                        case 1:
                            DataRowView preobraz = (DataRowView)data.SelectedItem;
                            int id = (int)preobraz["Номер студента"];
                            STA.UpdateQuery(nam.Text, fio.Text, group.Text, ruktech.Text, rukorg.Text, id);
                            STA.Fill(dataSet1.Student);
                            break;
                        case 2:
                            DataRowView preobraz1 = (DataRowView)data.SelectedItem;
                            int id1 = (int)preobraz1["Номер студента"];
                            _2STA.UpdateQuery(nam.Text, fio.Text, group.Text, ruktech.Text, rukorg.Text, id1);
                            _2STA.Fill(dataSet1.P50_2_19);
                            break;
                        case 3:
                            DataRowView preobraz2 = (DataRowView)data.SelectedItem;
                            int id2 = (int)preobraz2["Номер студента"];
                            _3STA.UpdateQuery(nam.Text, fio.Text, group.Text, ruktech.Text, rukorg.Text, id2);
                            _3STA.Fill(dataSet1.P50_3_19);
                            break;
                        case 4:
                            DataRowView preobraz3 = (DataRowView)data.SelectedItem;
                            int id3 = (int)preobraz3["Номер студента"];
                            _4STA.UpdateQuery(nam.Text, fio.Text, group.Text, ruktech.Text, rukorg.Text, id3);
                            _4STA.Fill(dataSet1.P50_4_19);
                            break;
                        case 5:
                            DataRowView preobraz4 = (DataRowView)data.SelectedItem;
                            int id4 = (int)preobraz4["Номер студента"];
                            _5STA.UpdateQuery(nam.Text, fio.Text, group.Text, ruktech.Text, rukorg.Text, id4);
                            _5STA.Fill(dataSet1.P50_5_19);
                            break;
                        case 6:
                            DataRowView preobraz5 = (DataRowView)data.SelectedItem;
                            int id5 = (int)preobraz5["Номер студента"];
                            _6STA.UpdateQuery(nam.Text, fio.Text, group.Text, ruktech.Text, rukorg.Text, id5);
                            _6STA.Fill(dataSet1.P50_6_19);
                            break;
                    }

                }
            }
            catch
            {
                MessageBox.Show("Названия не должны повторяться!");
            }
        }

        private void EXIT_2(object sender, RoutedEventArgs e)
        {
            MainWindow back = new MainWindow();
            back.Show();
            this.Close();
        }

        private void nam_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "йцукёенгшщзхъэждлорпавыфячсмитьбю.ЙЦУКЕНГШЩЗХЪЭЖДЛОРПАВЫФЯЧСМИТЬБЮЁ".IndexOf(e.Text) < 0;
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

        private void data_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (data.SelectedItem != null)
            {
                DataRowView drv = (DataRowView)data.SelectedItem;
                if (data.SelectedItem != null)
                {
                    nam.Text = (String)drv["Название организации"];
                    fio.Text = (String)drv["ФИО студента"];
                    group.Text = (String)drv["Группа"];
                    ruktech.Text = (String)drv["Руководитель от техникума"];
                    rukorg.Text = (String)drv["Руководитель от организации"];
                   
                }
            }
        }
        public static DataTable DataViewAsDataTable(DataView dv)
        {
            DataTable dt = dv.Table.Clone();
            foreach (DataRowView drv in dv)
                dt.ImportRow(drv.Row);
            return dt;
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

            Excel.Application excel = null;
            Excel.Workbook wb = null;

            object missing = Type.Missing;
            Excel.Worksheet ws = null;
            Excel.Range rng = null;

            excel = new Microsoft.Office.Interop.Excel.Application();
            wb = excel.Workbooks.Add();
            ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.ActiveSheet;

            DataView view = (DataView)data.ItemsSource;
            DataTable dt = DataViewAsDataTable(view);

            for (int Idx = 0; Idx < dt.Columns.Count; Idx++)
            {
                ws.Range["A1"].Offset[0, Idx].Value = dt.Columns[Idx].ColumnName;
            }

            for (int Idx = 0; Idx < dt.Rows.Count; Idx++)
            {
                ws.Range["A2"].Offset[Idx].Resize[1, dt.Columns.Count].Value = dt.Rows[Idx].ItemArray;
            }

            excel.Visible = true;
            wb.Activate();

        }
    }
}
