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

    public partial class Ruk : Window
    {
        public int gru = 1;
        DataSet1 dataSet1 = new DataSet1();
        StudentTableAdapter STA = new StudentTableAdapter();
        P50_2_19TableAdapter _2STA = new P50_2_19TableAdapter();
        P50_3_19TableAdapter _3STA = new P50_3_19TableAdapter();
        P50_4_19TableAdapter _4STA = new P50_4_19TableAdapter();
        P50_5_19TableAdapter _5STA = new P50_5_19TableAdapter();
        P50_6_19TableAdapter _6STA = new P50_6_19TableAdapter();

        ВД50_1_19TableAdapter STA1 = new ВД50_1_19TableAdapter();
        ВД50_2_19TableAdapter _2STA1 = new ВД50_2_19TableAdapter();
        ВД50_3_19TableAdapter _3STA1 = new ВД50_3_19TableAdapter();
        ВД50_1_20TableAdapter _4STA1 = new ВД50_1_20TableAdapter();
        ВД50_2_20TableAdapter _5STA1 = new ВД50_2_20TableAdapter();
        ВД50_3_20TableAdapter _6STA1 = new ВД50_3_20TableAdapter();

        public Ruk()
        {
            InitializeComponent();
            data.ItemsSource = dataSet1.Student.DefaultView;
            STA.Fill(dataSet1.Student);
            _2STA.Fill(dataSet1.P50_2_19);
            _3STA.Fill(dataSet1.P50_3_19);
            _4STA.Fill(dataSet1.P50_4_19);
            _5STA.Fill(dataSet1.P50_5_19);
            _6STA.Fill(dataSet1.P50_6_19);
            STA1.Fill(dataSet1._ВД50_1_19);
            _2STA1.Fill(dataSet1._ВД50_2_19);
            _3STA1.Fill(dataSet1._ВД50_3_19);
            _4STA1.Fill(dataSet1._ВД50_1_20);
            _5STA1.Fill(dataSet1._ВД50_2_20);
            _6STA1.Fill(dataSet1._ВД50_3_20);
        }

        private void EXIT_2(object sender, RoutedEventArgs e)
        {
            MainWindow back = new MainWindow();
            back.Show();
            this.Close();
        }

        private void П50_1_19(object sender, RoutedEventArgs e)
        {
            data.ItemsSource = dataSet1.Student.DefaultView;
        }

        private void П50_2_19(object sender, RoutedEventArgs e)
        {
            data.ItemsSource = dataSet1.P50_2_19.DefaultView;
        }

        private void П50_3_19(object sender, RoutedEventArgs e)
        {
            data.ItemsSource = dataSet1.P50_3_19.DefaultView;
        }

        private void П50_4_19(object sender, RoutedEventArgs e)
        {
            data.ItemsSource = dataSet1.P50_4_19.DefaultView;
        }

        private void П50_5_19(object sender, RoutedEventArgs e)
        {
            data.ItemsSource = dataSet1.P50_5_19.DefaultView;
        }

        private void П50_6_19(object sender, RoutedEventArgs e)
        {
            data.ItemsSource = dataSet1.P50_6_19.DefaultView;
        }

        private void ВД50_1_19(object sender, RoutedEventArgs e)
        {
            data.ItemsSource = dataSet1._ВД50_1_19.DefaultView;
        }

        private void ВД50_2_19(object sender, RoutedEventArgs e)
        {
            data.ItemsSource = dataSet1._ВД50_2_19.DefaultView;
        }

        private void ВД50_3_19(object sender, RoutedEventArgs e)
        {
            data.ItemsSource = dataSet1._ВД50_3_19.DefaultView;
        }

        private void ВД50_1_20(object sender, RoutedEventArgs e)
        {
            data.ItemsSource = dataSet1._ВД50_1_20.DefaultView;
        }

        private void ВД50_2_20(object sender, RoutedEventArgs e)
        {
            data.ItemsSource = dataSet1._ВД50_2_20.DefaultView;
        }

        private void ВД50_3_20(object sender, RoutedEventArgs e)
        {
            data.ItemsSource = dataSet1._ВД50_3_20.DefaultView;
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
