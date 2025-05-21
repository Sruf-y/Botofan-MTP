using Microsoft.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Saptamana8_WPF
{
    public partial class MainWindow : Window
    {
        private readonly string connectionString = GlobalVars.CONNECTION_STRING;

        public MainWindow()
        {
            InitializeComponent();

            // in caz ca trebuie initializate tabelele
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                if (!DataBase.TableExists(conn, DataBase.UserController.TABLE_NAME) || GlobalVars.DATABASE_RECREATE_ON_STARTUP)
                {
                    DataBase.UserController.CreateTable(conn);
                    DataBase.UserController.Insert("Admin", "Password");
                }
                if (!DataBase.TableExists(conn, DataBase.TelController.TABLE_NAME) || GlobalVars.DATABASE_RECREATE_ON_STARTUP)
                {
                    DataBase.TelController.CreateTable(conn);
                }
            }
            
            AfisareUtilizatori();
            PasswordBox.KeyDown += PasswordBox_KeyDown;
        }

        private void AfisareUtilizatori()
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                  

                    var cmd = new SqlCommand("SELECT Nume FROM Utilizatori", conn);
                    using (var reader = cmd.ExecuteReader())
                    {
                        UserComboBox.Items.Clear();
                        while (reader.Read())
                        {
                            UserComboBox.Items.Add(reader["Nume"].ToString());
                        }
                    }
                    if (UserComboBox.Items.Count > 0)
                    {
                        UserComboBox.SelectedIndex = 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                ShowError("Eroare la conectarea bazei de date", ex.Message);
            }
            catch (Exception ex)
            {
                ShowError("Eroare necunoscută", ex.Message);
            }
        }

        private void PasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AttemptLogin();
            }
        }

        

        private void AttemptLogin()
        {
            if (string.IsNullOrWhiteSpace(UserComboBox.Text) ||
                string.IsNullOrWhiteSpace(PasswordBox.Password))
            {
                MessageBox.Show("Introduceți utilizatorul și parola.", "Date lipsă",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Consider using password hashing in production
                    var cmd = new SqlCommand(
                        "SELECT Id FROM Utilizatori WHERE Nume = @username AND Parola = @password",
                        conn);

                    cmd.Parameters.AddWithValue("@username", UserComboBox.Text);
                    cmd.Parameters.AddWithValue("@password", PasswordBox.Password);

                    var result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        MessageBox.Show("Autentificare reușită!", "Succes",
                                      MessageBoxButton.OK, MessageBoxImage.Information);

                        var mainWindow = new MainPage();
                        mainWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Utilizator sau parolă incorectă.", "Eroare",
                                      MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (SqlException ex)
            {
                ShowError("Eroare la conectarea bazei de date", ex.Message);
            }
            catch (Exception ex)
            {
                ShowError("Eroare necunoscută", ex.Message);
            }
        }

        private void ShowError(string title, string message)
        {
            MessageBox.Show($"{title}: {message}", "Eroare",
                          MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            AfisareUtilizatori();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            AttemptLogin();
        }

        private void signInButton_Click(object sender, RoutedEventArgs e)
        {
            new CreateUserWindow().Show();

        }
    }
}