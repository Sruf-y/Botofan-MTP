using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;

namespace Saptamana8_WPF
{
    public class DataBase
    {
        public static bool TableExists(SqlConnection connection, string tableName)
        {
            using (SqlCommand cmd = new SqlCommand(
                "SELECT CASE WHEN EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = @TableName) THEN 1 ELSE 0 END",
                connection))
            {
                cmd.Parameters.AddWithValue("@TableName", tableName.ToUpper());
                return (int)cmd.ExecuteScalar() == 1;
            }
        }





        public class TelController
        {
            public static String TABLE_NAME = "TELEFOANE";

            public class Telefon
            {

                public int index;
                public string firma;
                public string model;
                public int baterie;
                public DateTime releaseDate;
                public decimal price;

                public Telefon() { }
                public Telefon(int index,string firma, string model, int baterie, DateTime releaseDate, decimal price)
                {
                    this.index = index;
                    this.firma = firma;
                    this.model = model;
                    this.baterie = baterie;
                    this.releaseDate = releaseDate;
                    this.price = price;
                }
            }



            public static void CreateTable(SqlConnection connection)
            {
                using (SqlCommand cmd = new SqlCommand(
                    "DROP TABLE IF EXISTS " + TABLE_NAME,
                    connection))
                {
                    cmd.ExecuteNonQuery();
                }

                using (SqlCommand cmd = new SqlCommand(
                    "CREATE TABLE " + TABLE_NAME + " (" +
                    "Id INT IDENTITY(1,1) PRIMARY KEY, " +
                    "Firma NVARCHAR(100) , " +
                    "Model NVARCHAR(100) UNIQUE NOT NULL, " +
                    "Baterie INT, " +
                    "Release_Date DATETIME  NOT NULL DEFAULT SYSDATETIME(), " +
                    "Price DECIMAL(10,2) NOT NULL)",
                    connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }


            public static int TableSize()
            {
                SqlConnection connection = new SqlConnection(GlobalVars.CONNECTION_STRING);
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }

                string query = $@"SELECT COUNT(*) FROM [{TABLE_NAME}]";

                int a = 0;

                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    a= (int)command.ExecuteScalar();
                }
                catch(SqlException ex)
                {
                    MessageBox.Show("SqlEsception at counting Telefoane: "+ex.Message);
                }

                return a;
            }


            public static bool Insert(string firma, string model, int? baterie, DateTime? releaseDate, decimal price)
            {
                SqlConnection connection = new SqlConnection(GlobalVars.CONNECTION_STRING);
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }

                
                string query = $@"INSERT INTO [{TABLE_NAME}] (Firma, Model, Baterie, Release_Date, Price) 
                   VALUES (@FIRMA, @MODEL, @BATERIE, @RELEASE, @PRICE)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FIRMA", (firma!=null && firma.Length>0)?firma:"NULL");
                    command.Parameters.AddWithValue("@MODEL", model);
                    command.Parameters.AddWithValue("@BATERIE", (baterie != null && baterie>0) ? baterie : 0);
                    command.Parameters.AddWithValue("@RELEASE", (releaseDate!=null)?releaseDate:DateTime.Now);
                    command.Parameters.AddWithValue("@PRICE", (price != null && price > 0) ? price : 0);

                    try
                    {
                        command.ExecuteNonQuery();
                        return true;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Sql exception at inserting a Telefon: " + ex.Message);
                    }
                    return false;
                }
            }

            public static void Delete(string model)
            {
                SqlConnection connection = new SqlConnection(GlobalVars.CONNECTION_STRING);
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }

                string query = $@"DELETE FROM [{TABLE_NAME}] WHERE Model = @Model";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Model", model);


                try
                {
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Sql exception at inserting a Telefon: " + ex.Message);
                }
            }

            public static bool Update(int id, string firma, string model, int? baterie, DateTime? releaseDate, decimal? price)
            {
                if(model.IsNullOrEmpty())
                {
                    MessageBox.Show("Model cannot be empty!", "Update Telefon", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }

                SqlConnection connection = new SqlConnection(GlobalVars.CONNECTION_STRING);
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }

                List<string> arons = new List<string>();
                List<SqlParameter> parameters = new List<SqlParameter>();

                if (!string.IsNullOrWhiteSpace(firma))
                {
                    arons.Add("Firma = @Firma");
                    parameters.Add(new SqlParameter("@Firma", firma));
                }

                if (!string.IsNullOrWhiteSpace(model))
                {
                    arons.Add("Model = @Model");
                    parameters.Add(new SqlParameter("@Model", model));
                }

                if (baterie!=null)
                {
                    arons.Add("Baterie = @Baterie");
                    parameters.Add(new SqlParameter("@Baterie", baterie.Value));
                }

                if (releaseDate!=null)
                {
                    arons.Add("Release_Date = @ReleaseDate");
                    parameters.Add(new SqlParameter("@ReleaseDate", releaseDate));
                }

                if (price != null)
                {
                    arons.Add("Price = @Price");
                    parameters.Add(new SqlParameter("@Price", (price > 0) ? price : 0));
                }


                if (arons.Count > 0)
                {
                    string query = $@"UPDATE [{TABLE_NAME}] SET {string.Join(", ",arons)} WHERE Id = @id";

                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddRange(parameters.ToArray());
                    command.Parameters.AddWithValue("@Id", id);

                    try
                    {
                        command.ExecuteNonQuery();
                        return true;
                    }
                    catch (SqlException ex)
                    {

                        //ShowError("Sql exception", "Sql exception at modifying a Telefon:\n\n " + ex.Message);

                        ShowError("Sql exception", "Sql exception at modifying a Telefon:\n\n " + "Model acesta exista deja!");
                    }
                    catch(Exception ex)
                    {
                        ShowError("Exception", "Exception at modifying a Telefon:\n\n " + ex.Message);
                    }
                }
                return false;



            }

        }


        public class UserController
        {
            public static String TABLE_NAME = "UTILIZATORI";



            public static void CreateTable(SqlConnection connection)
            {
                using (SqlCommand cmd = new SqlCommand(
                    "DROP TABLE IF EXISTS " + TABLE_NAME,
                    connection))
                {
                    cmd.ExecuteNonQuery();
                }



                using (SqlCommand cmd = new SqlCommand(
                    ("CREATE TABLE " + TABLE_NAME + " (" +
                    "Id INT IDENTITY(1,1) PRIMARY KEY, " +
                    "Nume NVARCHAR(100) UNIQUE NOT NULL, " +
                    "Parola NVARCHAR(100) NOT NULL)"),
                    connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }

            public static bool Insert(string nume, string parola)
            {
                SqlConnection connection = new SqlConnection(GlobalVars.CONNECTION_STRING);
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
                //Cream obiectul SqlCommand si interogarea sql 
                SqlCommand command = new SqlCommand("INSERT into " + TABLE_NAME + " (NUME, PAROLA) values" + "(@NUME,@PAROLA)", connection);

                command.Parameters.AddWithValue("@NUME", nume);
                command.Parameters.AddWithValue("@PAROLA", parola);
                try
                {
                    return (command.ExecuteNonQuery() > 0);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("User " + nume + " already exists!");
                    return false;
                }
                
            }


        }

        public static void ShowError(string title, string message)
        {
            MessageBox.Show($"{title}: {message}", "Eroare",
                          MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }


}
