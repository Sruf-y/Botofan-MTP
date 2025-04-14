using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Saptamana8_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        private string connectionString = "Server=DESKTOP-CN4O9AS\\SQLEXPRESS;Database=Botofan_Database;Trusted_Connection=True;TrustServerCertificate = True;";     
        public MainWindow()
        {
            InitializeComponent();
            AfisareUtilizatori();
        }
        private void AfisareUtilizatori()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT Nume FROM Utilizatori".ToUpper(), conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    { 
                        UserComboBox.Items.Add(reader["Nume".ToUpper()].ToString());
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Eroare la conectarea bazei de date: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare necunoscuta: " + ex.Message);
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string? utilizatorSelectat = UserComboBox.SelectedItem?.ToString();
                string parolaIntrodusa = PasswordBox.Password;
                if (string.IsNullOrEmpty(utilizatorSelectat) ||
        string.IsNullOrEmpty(parolaIntrodusa))
                {
                    MessageBox.Show("Introduceti utilizatorul si parola.");
                    return;
                }
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT PAROLA FROM Utilizatori WHERE NUME = @username", conn); 
        
                    cmd.Parameters.AddWithValue("@username", utilizatorSelectat);
                    object result = cmd.ExecuteScalar();
                    
        

            if (result != null && result.ToString() == parolaIntrodusa)
                    {
                        MessageBox.Show("Autentificare reusita!");
                        new Window1().Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Utilizator sau parola incorecta.");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Eroare la conectarea bazei de date: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare necunoscuta: " + ex.Message);
            }
        }
    }
    }
