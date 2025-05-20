using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
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

namespace Saptamana8_WPF
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {


        private string connectionString = GlobalVars.CONNECTION_STRING;
        public Window1()
        {
            InitializeComponent();
        }
        private void Inregistrare()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            //Cream obiectul SqlCommand si interogarea sql 
            SqlCommand command = new SqlCommand("INSERT into Angajat (ID, NUME, DATAN, ADRESA, TARA, GEN) values" + "(@ID,@NUME,@DATAN,@ADRESA,@Tara,@GEN)", connection);
            var IdAng = Convert.ToInt32(txtAngID.Text);
            var dn = Convert.ToDateTime(dpDN.Text);
            var gen = rbMasculin.IsChecked.HasValue && rbMasculin.IsChecked.Value ? "Masculin" : "Feminin";
            command.Parameters.AddWithValue("@ID", IdAng);
            command.Parameters.AddWithValue("@NUME", txtNume.Text);
            command.Parameters.AddWithValue("@DATAN", dn);
            command.Parameters.AddWithValue("@ADRESA", txtAdresa.Text);
            command.Parameters.AddWithValue("@TARA", cbTara.SelectedItem);
            command.Parameters.AddWithValue("@GEN", gen);
            command.ExecuteNonQuery();
            MessageBox.Show("Salvat cu succes in baza de date!", "Salvare", MessageBoxButton.OK,
        MessageBoxImage.Information);

        }

        private void btnInregistrare_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNume.Text) || string.IsNullOrEmpty(txtAdresa.Text) ||
        string.IsNullOrEmpty(txtAngID.Text))
                {
                    MessageBox.Show("Completati toate campurile!");
                    return;
                }
                if (cbTara.SelectedItem == null)
                {
                    MessageBox.Show("Selectati tara!");
                    return;
                }
                if (dpDN.SelectedDate == null)
                {
                    MessageBox.Show("Selectati data nasterii!");
                    return;
                }
                if (!rbMasculin.IsChecked.HasValue && !rbFeminin.IsChecked.HasValue)




                {
                    MessageBox.Show("Selectati genul!");
                    return;
                }
                Inregistrare();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message);
            }
            finally
            {
                // Stergere campuri 
                txtNume.Clear();
                txtAdresa.Clear();
                txtAngID.Clear();
                cbTara.SelectedItem = null;
                dpDN.SelectedDate = null;
                rbMasculin.IsChecked = false;
                rbFeminin.IsChecked = false;
            }
        }

        private void btnActualizare_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
                
                SqlCommand command = new SqlCommand("UPDATE Angajat set ID=@ID,NUME=@NUME,"
        +
                    "DATAN=@DATAN,ADRESA=@ADRESA,TARA=@TARA,GEN=@GEN where ID=@ID",
        connection);
                var AngId = Convert.ToInt32(txtAngID.Text);
                var dn = Convert.ToDateTime(dpDN.Text);
                var gen = rbMasculin.IsChecked.HasValue && rbMasculin.IsChecked.Value ? "Masculin" :
        "Feminin";
                command.Parameters.AddWithValue("@ID", AngId);
                command.Parameters.AddWithValue("@NUME", txtNume.Text);
                command.Parameters.AddWithValue("@DATAN", dn);
                command.Parameters.AddWithValue("@ADRESA", txtAdresa.Text);
                command.Parameters.AddWithValue("@TARA", cbTara.SelectedItem);
                command.Parameters.AddWithValue("@GEN", gen);
                command.ExecuteNonQuery();
                MessageBox.Show("Actualizat cu succes", "Actualizare", MessageBoxButton.OK,
        MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message);
            }
            finally
            {
                // Stergere campuri 
                txtNume.Clear();
                txtAdresa.Clear();
                txtAngID.Clear();
                cbTara.SelectedItem = null;



                dpDN.SelectedDate = null;
                rbMasculin.IsChecked = false;
                rbFeminin.IsChecked = false;
            }
        }

        private void btnStergere_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand("DELETE from Angajat where ID=@ID",
        connection);
                var AngId = Convert.ToInt32(txtAngID.Text);
                command.Parameters.AddWithValue("@ID", AngId);
                command.ExecuteNonQuery();
                MessageBox.Show("Stergere cu succes!", "Stergere", MessageBoxButton.OK,
        MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message);
            }
            finally
            {
                // Stergere campuri 
                txtNume.Clear();
                txtAdresa.Clear();
                txtAngID.Clear();
                cbTara.SelectedItem = null;
                dpDN.SelectedDate = null;
                rbMasculin.IsChecked = false;
                rbFeminin.IsChecked = false;
            }
        }

        private void btnDetalii_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtAngID.Text))
                {
                    MessageBox.Show("Introduceti ID-ul angajatului!");
                    return;
                }
                SqlConnection connection = new SqlConnection(connectionString);
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand("SELECT * from Angajat where ID=@ID",
        connection);
                var AngId = Convert.ToInt32(txtAngID.Text);
                command.Parameters.AddWithValue("@ID", AngId);
                var reader = command.ExecuteReader();



                while (reader.Read())
                {
                    txtNume.Text = reader["Nume"].ToString();
                    dpDN.Text = reader["DATAN"].ToString();
                    txtAdresa.Text = reader["Adresa"].ToString();
                    var tara = reader["Tara"].ToString();
                    var gen = reader["Gen"].ToString();
                    cbTara.SelectedItem = tara;
                    if (gen == "Masculin")
                        rbMasculin.IsChecked = true;
                    else
                        rbFeminin.IsChecked = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message);
            }
        }
        private void btnAfisare_Click(object sender, RoutedEventArgs e)
        {
            Afisare afisareAngajati = new Afisare();
            afisareAngajati.Show();
        }
        private void btnIesire_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
