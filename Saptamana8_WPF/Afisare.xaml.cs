using Microsoft.Data.SqlClient;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Saptamana8_WPF
{
    /// <summary>
    /// Interaction logic for Afisare.xaml
    /// </summary>
    public partial class Afisare : Window
    {
        private void AfisareCuDataSet()
        {
            string connectionString = "Server=DESKTOP-CN4O9AS\\SQLEXPRESS;Database=Botofan_Database;Trusted_Connection=True;TrustServerCertificate = True;";
            string query = "SELECT * FROM Angajat";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Angajat");
                if (ds.Tables["Angajat"] != null)
                {
                    AngajatiGrid.ItemsSource = ds.Tables["Angajat"]?.DefaultView;
                }
            }
        }
        public Afisare()
        {
            InitializeComponent();
            AfisareCuDataSet();
        }

        private void Iesire_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
