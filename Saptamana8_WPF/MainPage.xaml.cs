using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
using Microsoft.IdentityModel.Tokens;
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
            new Operations.TelOperationsWindow(close).Show();

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



                new Operations.TelOperationsWindow(id, firma, model, baterie, releaseDate, price, close).Show();
            }


        }

        public void close() { RefreshData(); }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {

                DataRowView row = (DataRowView)dataGrid.SelectedItem;

                string model = row["Model"].ToString();

                DataBase.TelController.Delete(model);


                RefreshData();

                MessageBox.Show("Deleted succesfully!", "Sql Delete", MessageBoxButton.OK, MessageBoxImage.Information);
            }


        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            decimal maxPrice = -1;

            string connectionString = GlobalVars.CONNECTION_STRING;
            StringBuilder queryBuilder = new StringBuilder("SELECT * FROM " + DataBase.TelController.TABLE_NAME);
            List<SqlParameter> parameters = new List<SqlParameter>();


            queryBuilder.Append(" WHERE 1=1"); // ca sa pot sa continui cu "AND" fara sa verific daca exista where sau nu

            // parse modelSearchBox
            if (!modelSearchBox.Text.IsNullOrEmpty())
            {
                queryBuilder.Append(" AND Model LIKE @MODEL");
                parameters.Add(new SqlParameter("@MODEL", "%" + modelSearchBox.Text + "%"));
            }

            // parse pricesearchbox
            if (!priceSearchBox.Text.IsNullOrEmpty())
            {

                decimal.TryParse(priceSearchBox.Text, out maxPrice);

                if (maxPrice <= 0)
                {
                    ShowError("Invalid Input", "Price must be a valid decimal number > 0");
                    return;
                }
                else
                {
                    queryBuilder.Append(" AND Price <= @PRICE");
                    parameters.Add(new SqlParameter("@PRICE", maxPrice));
                }

            }
            else if (!string.IsNullOrWhiteSpace(priceSearchBox.Text))
            {
                ShowError("Invalid Input", "Price must be a valid decimal number");
                return;
            }


            // try updating info
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(queryBuilder.ToString(), conn))
                {
                    cmd.Parameters.AddRange(parameters.ToArray());

                    conn.Open();

                    if (DataBase.TableExists(conn, DataBase.TelController.TABLE_NAME))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dataGrid.ItemsSource = dt.DefaultView;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                ShowError("Database error", "Sql error at filtering Telefoane: " + ex.Message);
            }
        }

        private void refreshButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshData();
        }


        private void DropPanel_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);


                var filepath = files.First();
                //foreach (string file in files)
                //{
                //    // Process the file
                //    MessageBox.Show("File dropped: " + file);
                //}

                //MessageBox.Show("File dropped: " + files.First());

                using (StreamReader reader = new StreamReader(filepath))
                {
                    string line = "";
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 5)
                        {
                            try
                            {
                                string firma = parts[0];
                                string model = parts[1];
                                int baterie = int.Parse(parts[2]);

                                DateTime? releaseDate;
                                if (parts[3]!= "null")
                                {
                                    releaseDate = DateTime.Parse(parts[3]);
                                }
                                else
                                {
                                    releaseDate = null;
                                }
                                
                                
                                
                                decimal price = decimal.Parse(parts[4]);
                                try
                                {
                                    DataBase.TelController.Insert(firma, model, baterie, releaseDate, price);
                                }
                                catch (SqlException ex)
                                {
                                    ShowError("Database error", "Sql error at inserting Telefoane: " + ex.Message);
                                }
                            }
                            catch (FormatException ex)
                            {
                                ShowError("Invalid Input", "Invalid format in file: " + ex.Message);
                            }
                            catch (SqlException ex)
                            {
                                ShowError("Database error", "Sql error at inserting Telefoane: " + ex.Message);
                            }
                        }
                    }


                }
            }
            RefreshData();
        }

        private void DropPanel_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.Copy;
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }
        }























        public void RefreshData()
        {
            string connectionString = GlobalVars.CONNECTION_STRING;
            string query = "SELECT * FROM " + DataBase.TelController.TABLE_NAME;


            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                if (DataBase.TableExists(conn, DataBase.TelController.TABLE_NAME))
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

        public static void ShowError(string title, string message)
        {
            MessageBox.Show($"{title}: {message}", "Eroare",
                          MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
