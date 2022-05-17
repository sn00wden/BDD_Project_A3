using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;

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

        public static List<string[]> Requete(MySqlConnection connection, string selection, string table)
        {
            List<string[]> liste = new List<string[]>();
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
                liste.Add(currentRowAsString.Split(';'));
                //Console.WriteLine(currentRowAsString);
            }
            reader.Close();
            return liste;
            
        }

        public static void Delete_Request(MySqlConnection connection, string table, string condition)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM " + table + " WHERE " + condition + ";";
            command.ExecuteNonQuery();
        }


        public static List<string[]> Requete(MySqlConnection connection, string requete)
        {
            List<string[]> liste = new List<string[]>();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = requete;
            MySqlDataReader reader;
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                string currentRowAsString = "";
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    string valueAsString = reader.GetValue(i).ToString();
                    Console.WriteLine(valueAsString);
                    currentRowAsString += valueAsString + ";";
                }
                liste.Add(currentRowAsString.Split(';'));
                //Console.WriteLine(currentRowAsString);
            }
            reader.Close();
            return liste;

        }

        //Get last id of a table
        public static int GetLastID(MySqlConnection connection, string table,string id_name)
        {
            MySqlCommand command = connection.CreateCommand();
            //select max first column
            
            command.CommandText = "SELECT MAX("+id_name+") FROM " + table + ";";
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            reader.Read();
            int id = reader.GetInt32(0);
            reader.Close();
            return id;
        }

        public static List<string> Get_Header(MySqlConnection connection, string table)
        {
            List<string> liste = new List<string>();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM " + table + ";";
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            reader.Read();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                string valueAsString = reader.GetName(i);
                liste.Add(valueAsString);
            }
            reader.Close();
            return liste;
        }

        public static DataTable Create_Datatable(MySqlConnection connection, string table)
        {
            DataTable dt = new DataTable();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM " + table + ";";
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                dt.Columns.Add(reader.GetName(i));
            }
            while (reader.Read())
            {
                DataRow dr = dt.NewRow();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    //Check if reader value is a strin
                    dr[i] = reader.GetValue(i).ToString().Replace(',', '.');
                }
                dt.Rows.Add(dr);
            }
            reader.Close();
            return dt;
        }

        public static DataTable Create_Datatable(MySqlConnection connection, string table,string request)
        {
            DataTable dt = new DataTable();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = request;
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                dt.Columns.Add(reader.GetName(i));
            }
            while (reader.Read())
            {
                DataRow dr = dt.NewRow();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    //Check if reader value is a strin
                    dr[i] = reader.GetValue(i).ToString().Replace(',', '.');
                }
                dt.Rows.Add(dr);
            }
            reader.Close();
            return dt;
        }

        public static List<string> Get_Data(MySqlConnection connection, string selection, string table)
        {
            List<string> liste = new List<string>();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT " + selection + " FROM " + table + ";";
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                string currentRowAsString = "";
                for (int i = 0; i < reader.FieldCount-1; i++)
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

        //adding a new row to a table
        public static void Add_Row(MySqlConnection connection, string request)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = request;
            
            command.ExecuteNonQuery();
        }

        public static string Json(MySqlConnection connection,string table_name, List<string> header,string path)
        {
            MySqlCommand command = connection.CreateCommand();
            //command.CommandText = "SELECT JSON_OBJECT('ID_Client_Individuel', ID_Client_Individuel, 'Nom_Client_Individuel', Nom_Client_Individuel, 'Prenom', Prenom, 'Adresse', Adresse,'Telephone', Telephone, 'Courriel', Courriel,'Numero_Programme', Numero_Programme, 'Date_Adhesion', Date_Adhesion) as ogust FROM Client_Individuel;";
            command.CommandText = "Select JSON_OBJECT(";
            for (int i = 0; i < header.Count; i++)
            {
                command.CommandText += "'"+header[i] + "', " + header[i] + ",";
            }
            command.CommandText = command.CommandText.Remove(command.CommandText.Length-1);
            command.CommandText += ") as ogust from "+ table_name +";";
            MySqlDataReader reader;
            reader = command.ExecuteReader();

            string jason = "";

            while (reader.Read())
            {
                jason += reader.GetValue(0).ToString() +";";
            }
            jason = jason.Remove(jason.Length - 1);

            reader.Close();
            //Write into a json file
            File.WriteAllText(path, jason);


            return command.CommandText;


        }
    }
}
