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
using System.Xml.Serialization;
using Microsoft.Data.SqlClient;
using static Saptamana8_WPF.DataBase.TelController;



namespace Saptamana8_WPF
{


    public partial class MainPage : Window
    {

        public MainPage()
        {

            InitializeComponent();

            RefreshData();


        }

        private void insertButton_Click(object sender, RoutedEventArgs e)
        {
            new Operations.TelOperationsWindow().Show();

        }

        private void modifyButton_Click(object sender, RoutedEventArgs e)
        {

            if (dataGrid.SelectedItem != null)
            {
                // Since we're binding to DataView, SelectedItem is a DataRowView
                DataRowView row = (DataRowView)dataGrid.SelectedItem;

                // Access column values
                int id = Convert.ToInt32(row["Id"]);
                string firma = row["Firma"].ToString();
                string model = row["Model"].ToString();
                int baterie = Convert.ToInt32(row["Baterie"]);
                DateTime releaseDate = Convert.ToDateTime(row["Release_Date"]);
                decimal price = Convert.ToDecimal(row["Price"]);



                new Operations.TelOperationsWindow(id, model, firma, baterie, releaseDate, price).Show();
            }


        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {

                DataRowView row = (DataRowView)dataGrid.SelectedItem;

                string model = row["Model"].ToString();

                DataBase.TelController.Delete(model);
                RefreshData();
            }


        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void refreshButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshData();
        }






        public void RefreshData()
        {
            string connectionString = GlobalVars.CONNECTION_STRING;
            string query = "SELECT * FROM " + DataBase.TelController.TABLE_NAME;


            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                if (DataBase.TableExists(conn, "Telefoane"))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGrid.ItemsSource = dt.DefaultView;
                    }
                }
            }

        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (dataGrid.SelectedItem != null)
            {
                // Since we're binding to DataView, SelectedItem is a DataRowView
                DataRowView row = (DataRowView)dataGrid.SelectedItem;

                // Access column values
                int id = Convert.ToInt32(row["Id"]);
                string firma = row["Firma"].ToString();
                string model = row["Model"].ToString();
                int baterie = Convert.ToInt32(row["Baterie"]);
                DateTime releaseDate = Convert.ToDateTime(row["Release_Date"]);
                decimal price = Convert.ToDecimal(row["Price"]);

            }
        }
    }
}
