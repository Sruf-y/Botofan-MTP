using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Data.SqlClient;

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
                    ("CREATE TABLE "+TABLE_NAME+" (".ToUpper() +
                    "Id INT IDENTITY(1,1) PRIMARY KEY, " +
                    "Nume NVARCHAR(100) NOT NULL, " +
                    "Parola NVARCHAR(100) NOT NULL)"),
                    connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }

            public static void Insert(String nume, String parola)
            {
                SqlConnection connection = new SqlConnection(GlobalVars.CONNECTION_STRING);
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
                //Cream obiectul SqlCommand si interogarea sql 
                SqlCommand command = new SqlCommand("INSERT into "+TABLE_NAME+" (NUME, PAROLA) values" + "(@NUME,@PAROLA)", connection);

                command.Parameters.AddWithValue("@NUME", nume);
                command.Parameters.AddWithValue("@PAROLA", parola);
                command.ExecuteNonQuery();
            }
        }
    }
}
