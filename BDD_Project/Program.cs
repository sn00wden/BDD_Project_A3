using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;



namespace BDD_Project
{
    internal class Program
    {
        

        static void LireTable(MySqlConnection connection, string table)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM " + table + ";";
            connection.Open();
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
                Console.WriteLine(currentRowAsString);
            }
            reader.Close();
            Console.ReadKey();
        }

        static void Gestion_pieces(MySqlConnection connection)
        {
            int i = 0;

            Console.Clear();
            Console.WriteLine("Gestion des pièces de rechange");
            Console.WriteLine("=================");

            Console.WriteLine("\nQue voulez-vous faire ? ");
            Console.WriteLine("1) Créer une pièce");
            Console.WriteLine("2) Supprimer une pièce");
            Console.WriteLine("3) Modifier une pièce existante");
            i = Convert.ToInt32(Console.ReadLine());
            switch (i)
            {
                case 1:
                    Console.WriteLine("Vous avez choisi Créer Pièce");
                    Console.ReadKey();

                    Console.WriteLine("Entrez ID de la pièce");
                    MySqlParameter id = new MySqlParameter("@id", MySqlDbType.Int32);
                    id.Value = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Entrez Description de la pièce");
                    MySqlParameter description = new MySqlParameter("@description", MySqlDbType.VarChar);
                    description.Value = (Console.ReadLine());
                    Console.WriteLine("Entrez Prix_Unitaire de la pièce");
                    MySqlParameter Prix_Unitaire = new MySqlParameter("@Prix_Unitaire", MySqlDbType.Int32);
                    Prix_Unitaire.Value = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Entrez Nom_Fournisseur de la pièce");
                    MySqlParameter Nom_Fournisseur = new MySqlParameter("@Nom_Fournisseur", MySqlDbType.VarChar);
                    Nom_Fournisseur.Value = (Console.ReadLine());
                    Console.WriteLine("Entrez Num_Prod_Fournisseur de la pièce");
                    MySqlParameter Num_Prod_Fournisseur = new MySqlParameter("@Num_Prod_Fournisseur", MySqlDbType.Int32);
                    Num_Prod_Fournisseur.Value = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Entrez Date_Intro_Marche de la pièce");
                    MySqlParameter Date_Intro_Marche = new MySqlParameter("@Date_Intro_Marche", MySqlDbType.Date);
                    Date_Intro_Marche.Value = (Console.ReadLine());
                    Console.WriteLine("Entrez Date_Discontinuation de la pièce");
                    MySqlParameter Date_Discontinuation = new MySqlParameter("@Date_Discontinuation", MySqlDbType.Date);
                    Date_Discontinuation.Value = (Console.ReadLine());
                    Console.WriteLine("Entrez Delai_Approvisionnement de la pièce");
                    MySqlParameter Delai_Approvisionnement = new MySqlParameter("@Delai_Approvisionnement", MySqlDbType.Int32);
                    Delai_Approvisionnement.Value = Convert.ToInt32(Console.ReadLine());

                    string insertLine = "INSERT INTO `VeloMax`.`Pieces` (`ID_Piece`, `Description`, `Prix_Unitaire`, `Nom_Fournisseur`, `Num_Prod_Fournisseur`, `Date_Intro_Marche`, `Date_Discontinuation`, `Delai_Approvisionnement`) VALUES (@id, @description, @Prix_Unitaire, @Nom_Fournisseur, @Num_Prod_Fournisseur,@Date_Intro_Marche,@Date_Discontinuation,@Delai_Approvisionnement);";
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = insertLine;
                    command.Parameters.Add(id);
                    command.Parameters.Add(description);
                    command.Parameters.Add(Prix_Unitaire);
                    command.Parameters.Add(Nom_Fournisseur);
                    command.Parameters.Add(Num_Prod_Fournisseur);
                    command.Parameters.Add(Date_Intro_Marche);
                    command.Parameters.Add(Date_Discontinuation);
                    command.Parameters.Add(Delai_Approvisionnement);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (MySqlException e)
                    {
                        Console.WriteLine(" ErreurConnexion : " + e.ToString());
                        Console.ReadLine();
                        return;
                    }


                    LireTable(connection, "Pieces");
                    break;

                case 2:
                    Console.WriteLine("Vous avez choisi Supprimer une pièce");
                    Console.ReadKey();
                    break;

                case 3:
                    Console.WriteLine("Vous avez choisi Modifier une pièce existante");
                    Console.ReadKey();
                    break;

                default:
                    Console.WriteLine("Veuillez entrer un chiffre valide.");
                    Console.ReadKey();
                    Gestion_pieces(connection);
                    break;
            }
        }
        
        



        private static void Main(string[] args)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost;PORT=3306;userid=VS_USER;password=VSCODEISBETTER;database=velomax");

            LireTable(connection, "*");


            #region     Request expample
            /*Console.WriteLine("SUPPRIMER LE VELO 104");
            MySqlParameter id = new MySqlParameter("@id", MySqlDbType.Int64);
            id.Value = "104";

            string requete5 = "DELETE FROM bicyclette WHERE ID_Bicyclette = @id;";
            MySqlCommand command5 = connection.CreateCommand();
            command5.CommandText = requete5;
            command5.Parameters.Add(id);

            reader = command5.ExecuteReader();

            while (reader.Read())                           // parcours ligne par ligne
            {
                string currentRowAsString = "";
                for (int i = 0; i < reader.FieldCount; i++)    // parcours cellule par cellule
                {
                    string valueAsString = reader.GetValue(i).ToString();  // recuperation de la valeur de chaque cellule sous forme d'une string (voir cependant les differentes methodes disponibles !!)
                    currentRowAsString += valueAsString + ", ";
                }
                Console.WriteLine(currentRowAsString);    // affichage de la ligne (sous forme d'une "grosse" string) sur la sortie standard
            }
            reader.Close();*/
            #endregion


            Console.ReadKey();
            
        }
    }
}
