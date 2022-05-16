using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BDD_Project
{
    
    
  
    
    internal class Tools
    {
        private static MySqlConnection connection;

        static public MySqlConnection Connection
        {
            get { return connection; }
            set { connection = value; }
        }

        static void Requete(MySqlConnection connection, string selection, string table)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT " + selection + " FROM " + table + ";";

            MySqlDataReader reader;
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                string currentRowAsString = "";
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    string valueAsString = reader.GetValue(i).ToString();
                    currentRowAsString += valueAsString + ", ";
                }
                //Console.WriteLine(currentRowAsString);
            }
            reader.Close();
            
        }
    }
}
