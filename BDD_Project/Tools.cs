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

        public static List<string> Requete(MySqlConnection connection, string selection, string table)
        {
            List<string> liste = new List<string>();
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
                    currentRowAsString += valueAsString + ";";
                }
                liste.Add(currentRowAsString);
                //Console.WriteLine(currentRowAsString);
            }
            reader.Close();
            return liste;
            
        }
    }
}
