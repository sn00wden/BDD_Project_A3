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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.IO;

namespace BDD_Project
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=VeloMax;UID=root;PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Bicyclette;"; // exemple de requete bien-sur !

            MySqlDataReader reader;
            reader = command.ExecuteReader();

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
            reader.Close();
            Console.ReadKey();


            // INSERER LE DERNIER VELO DANS LA TABLE BICYCLETTE

            Console.WriteLine("INSERER LE DERNIER VELO DANS LA TABLE BICYCLETTE");
            string insertTable = "INSERT INTO `VeloMax`.`Bicyclette` (`ID_Bicyclette`, `Nom`, `Grandeur`, `Prix_Unitaire`, `Ligne_Produit`) VALUES ('115', 'Mud Zinger II', 'Adultes', 359, 'BMX');";
            MySqlCommand command2 = connection.CreateCommand();
            command2.CommandText = insertTable;
            try
            {
                command2.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                Console.ReadLine();
                return;
            }
            reader.Close();
            Console.ReadKey();


            // VOIR LA TABLE ACTUALISEE AVEC LE DERNIER VELO
            Console.WriteLine("VOIR LA TABLE ACTUALISEE AVEC LE DERNIER VELO");
            reader = command.ExecuteReader();
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
            reader.Close();
            Console.ReadKey();

            Console.WriteLine("VOIR LE VELO QUI A LE NOM KILIMANDJARO");
            MySqlParameter nom = new MySqlParameter("@nom", MySqlDbType.VarChar);
            nom.Value = "Kilimandjaro";


            string requete4 = "SELECT * FROM Bicyclette WHERE nom = @nom;";
            MySqlCommand command4 = connection.CreateCommand();
            command4.CommandText = requete4;
            command4.Parameters.Add(nom);

            reader = command4.ExecuteReader();

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
            reader.Close();
            Console.ReadKey();

            Console.WriteLine("SUPPRIMER LE VELO 104");
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
            reader.Close();
            Console.ReadKey();

            // VOIR LA TABLE ACTUALISEE SANS LE VELO 104
            Console.WriteLine("VOIR LA TABLE ACTUALISEE SANS LE VELO 104");
            reader = command.ExecuteReader();
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
            reader.Close();
            Console.ReadKey();


            Console.WriteLine("MODIFIER LE NOM DE ORLEAN");
            MySqlParameter velo = new MySqlParameter("@velo", MySqlDbType.VarChar);
            velo.Value = "Orléans";
            MySqlCommand command6 = connection.CreateCommand();
            command6.CommandText = "UPDATE Bicyclette SET Nom = 'Daniel' WHERE Nom = @velo;";
            command6.Parameters.Add(velo);

            reader = command6.ExecuteReader();

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
            reader.Close();
            Console.ReadKey();

            Console.WriteLine("VOIR LA TABLE ACTUALISEE AVEC ORLEANS");
            reader = command.ExecuteReader();
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
            reader.Close();
            Console.ReadKey();


            connection.Close();

            /*
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=loueur;UID=root;PASSWORD=:/HaHa7878:/;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            Console.WriteLine("fin des opérations");



            //Console.Clear();
            //Console.WriteLine("0 Lecture/ecriture de ficier csv");
            //Console.WriteLine("=================\n");
            //Exo0();
            //Console.WriteLine("\nappuyez sur une touche pour continuer");
            //Console.ReadKey();

            //connection.Open();
            Console.WriteLine("fin des opérations");

            Console.Clear();
            Console.WriteLine("1.1 Liste des marques");
            Console.WriteLine("=================");
            Exo1(connection);
            Console.WriteLine("\nappuyez sur une touche pour continuer");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("1.1 Liste des marques");
            Console.WriteLine("=================");
            Exo2(connection);
            Console.WriteLine("\nappuyez sur une touche pour continuer");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("1.1 Liste des marques");
            Console.WriteLine("=================");
            Exo3(connection);
            Console.WriteLine("\nappuyez sur une touche pour continuer");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("1.1 Liste des marques");
            Console.WriteLine("=================");
            Exo4(connection);
            Console.WriteLine("\nappuyez sur une touche pour continuer");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("1.1 Liste des marques");
            Console.WriteLine("=================");
            Exo5(connection);
            Console.WriteLine("\nappuyez sur une touche pour continuer");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("1.1 Liste des marques");
            Console.WriteLine("=================");
            Exo6(connection);
            Console.WriteLine("\nappuyez sur une touche pour continuer");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("1.1 Liste des marques");
            Console.WriteLine("=================");
            Exo7(connection);
            Console.WriteLine("\nappuyez sur une touche pour continuer");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("1.1 Liste des marques");
            Console.WriteLine("=================");
            Exo6_2(connection);
            Console.WriteLine("\nappuyez sur une touche pour continuer");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("1.1 Liste des marques");
            Console.WriteLine("=================");
            Exo9(connection);
            Console.WriteLine("\nappuyez sur une touche pour continuer");
            Console.ReadKey();

        }//main

        static void Exo0()
        {
            //lire le fichier clients.csv
            Console.WriteLine("Lecture du fichier clients.csv");
            Console.WriteLine("----------------------------");
            string nomFichier = "clients.csv";
            Lire(nomFichier);
            Console.WriteLine("----------------------------");
            Console.WriteLine("Appuyez sur une touche pour continuer...\n");
            Console.ReadKey();
            //
            // ecrire dans le fichier csv
            // le client supplémentaire
            Console.WriteLine("Ecriture dans le fichier clients.csv");
            Console.WriteLine("----------------------------");
            string nom = "Jouvet";
            string prenom = "Louis";
            int age = 80;
            string numPermis = "55555";
            string adresse = "rue du vent";
            string ville = "Paris";
            string newClient = nom + ";"
                + prenom + ";"
                + Convert.ToString(age) + ";"
                + numPermis + ";"
                + adresse + ";"
                + ville;
            bool append = true;
            Ecrire(newClient, nomFichier, append);

            //relire le fichier clients.csv
            Console.WriteLine("Relecture du fichier clients.csv");
            Console.WriteLine("----------------------------");
            Lire(nomFichier);
            Console.WriteLine("----------------------------\n");

        }
        static void Ecrire(string ligne, string fichier, bool append)
        {
            StreamWriter ecrire = new StreamWriter(fichier, true);
            ecrire.WriteLine(ligne);
            ecrire.Close();
        }
        static void Lire(string fichier)
        {
            string ligne = "";
            char[] sep = new char[1] { ';' };
            string[] datas = new string[6];

            StreamReader lecteur = new StreamReader(fichier);
            while (lecteur.Peek() > 0)
            {
                ligne = lecteur.ReadLine();
                Console.WriteLine("ligne lue " + ligne);
                datas = ligne.Split(sep);
            }
            lecteur.Close();
        }



        static void Exo1(MySqlConnection connection)
        //liste des marques
        {
            //connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText =
             " SELECT DISTINCT(marque) FROM voiture ;";

            MySqlDataReader reader;
            reader = command.ExecuteReader();

            string marque;
            while (reader.Read())// parcours ligne par ligne
            {
                // prix = Convert.ToInt32(Console.ReadLine());
                marque = reader.GetString(0);  // récupération de la 1ère colonne (il n'y en a qu'une dans la requête !)
                Console.WriteLine(marque);
            }
            reader.Close();
            //   connection.Close();
        }

        static void Exo2(MySqlConnection connection)
        //liste des véhicules/propriétaires
        {
            // connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = " SELECT DISTINCT marque, modele, immat, pseudo"
                                + " FROM voiture NATURAL JOIN proprietaire"
                                + " ORDER BY pseudo, marque, modele ;";

            MySqlDataReader reader;
            reader = command.ExecuteReader();

            string marque = "";
            string modele = "";
            string immat = "";
            string pseudo = "";

            while (reader.Read())   // parcours ligne par ligne
            {
                marque = reader.GetString(0); // récupération 1ère colonne (selon la requête !)
                modele = reader.GetString(1); // récupération 2ème colonne (selon la requête !)
                immat = reader.GetString(2);  // récupération 3ème colonne colonne (selon la requête !)
                pseudo = reader.GetString(3); // récupération 4ème colonne colonne (selon la requête !)

                Console.WriteLine(pseudo + " : " + marque + " , " + modele + " , " + immat);
            }

            connection.Close();
        }

        static void Exo3(MySqlConnection connection)
        //liste des véhicules/propriétaires
        {
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = " SELECT DISTINCT marque, modele, prixJ"
                                + " FROM voiture"
                                + " ORDER BY prixJ DESC;";

            MySqlDataReader reader;
            reader = command.ExecuteReader();

            string marque = "";
            string modele = "";
            string lettre1 = "";
            string fin = "";
            int prixJ = 0;
            string marqueLettre1Maj = "";

            while (reader.Read())   // parcours ligne par ligne
            {
                marque = reader.GetString(0); // récupération 1ère colonne (selon la requête !)
                modele = reader.GetString(1); // récupération 2ème colonne (selon la requête !)
                prixJ = reader.GetInt32(2);  // récupération 3ème colonne colonne (selon la requête !)

                lettre1 = marque.Substring(0, 1).ToUpper();
                fin = marque.Substring(1);  // <=> label.Substring(1, label.Length -1)
                marqueLettre1Maj = lettre1 + fin;

                Console.WriteLine(marqueLettre1Maj + " : " + modele + " => " + prixJ);
            }

            connection.Close();
        }

        static void Exo4(MySqlConnection connection)
        // moyenne de prix de journée
        {
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = " SELECT AVG(prixJ)"
                                + " FROM voiture";

            MySqlDataReader reader;
            reader = command.ExecuteReader();

            double moyenne = 0.00;
            while (reader.Read())                           // parcours ligne par ligne
            {
                moyenne = reader.GetDouble(0);  // récupération de la 1nde colonne (selon la requête !)
            }
            Console.WriteLine("La moyenne des prix de journée est de " + moyenne + " euros");

            connection.Close();
        }

        static void Exo5(MySqlConnection connection)
        // prix de journée min et max par modèle
        {
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = " SELECT marque, modele, min(prixJ), max(prixJ) " +
                                     "FROM voiture " +
                                     "GROUP BY marque, modele; ";

            MySqlDataReader reader;
            reader = command.ExecuteReader();

            string marque = "";
            string modele = "";
            int min = 0;
            int max = 0;

            while (reader.Read())                           // parcours ligne par ligne
            {
                marque = reader.GetString(0); // récupération 1ère colonne (selon la requête !)
                modele = reader.GetString(1); // récupération 2ème colonne (selon la requête !)
                min = reader.GetInt32(2);     // récupération 3ème colonne (selon la requête !)
                max = reader.GetInt32(3);     // récupération 4ème colonne (selon la requête !)

                Console.WriteLine(marque + "  " + modele
                + "   minimum =" + min + "  maximum =" + max);
            }

            connection.Close();
        }


        static void Exo6(MySqlConnection connection)
        //Le deuxième prix de journée minimum
        {
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = " SELECT DISTINCT prixJ"
                                + " FROM voiture"
                                + " ORDER BY prixJ ASC ;";

            MySqlDataReader reader;
            reader = command.ExecuteReader();

            if (reader.Read()) // on passe le 1er élément (noter le if VERSUS while)
            {
                if (reader.Read()) // on arrive au 2nd élément
                {
                    int prix = reader.GetInt32(0);  // récupération de la 1ère colonne (il n'y en a qu'une dans la requête !)
                    Console.WriteLine("le deuxième prix de journée est : " + prix);
                }
            }

            connection.Close();
        }


        static void Exo6_2(MySqlConnection connection)
        //Le deuxième prix de journée minimum
        // Deuxième version
        {
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = " SELECT DISTINCT prixJ"
                                + " FROM voiture"
                                + " ORDER BY prixJ ASC ;";

            MySqlDataReader reader;
            reader = command.ExecuteReader();

            int numeroLigne = 0;
            int prix = 0;

            while (reader.Read()) // parcours ligne par ligne
            {
                numeroLigne++;   // vaut donc 1 au 1er tour de boucle
                if (numeroLigne == 2)
                {
                    prix = reader.GetInt32(0);  // récupération de la 1ère colonne (il n'y en a qu'une dans la requête !)
                    Console.WriteLine("le deuxième prix de journée est : " + prix);
                    break; // optimisation
                }
            }

            connection.Close();
        }

        static void Exo7(MySqlConnection connection)
        //Km compteur médian (50% de voitures au-dessus, 50% de voitures au-dessous)
        {
            connection.Open();

            // Etape 1
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = " SELECT COUNT(compteur)"
                                + " FROM voiture ;";

            MySqlDataReader reader;
            reader = command.ExecuteReader();

            int nbVoiture = 0;
            if (reader.Read())  // noter le if VERSUS while
            {
                nbVoiture = reader.GetInt32(0);
            }

            reader.Close(); // Ne pas oublier, pour se resservir de la même variable ;-)
                            //----------------------------

            // Etape 2 (si nbProduits > 0)
            command.CommandText = " SELECT DISTINCT compteur"
                                + " FROM voiture"
                                + " ORDER BY compteur ASC;";

            reader = command.ExecuteReader();

            int numeroLigne = 0;
            int indexMilieu = nbVoiture / 2 - 1;  // division entière (le "milieu de 9, c'est 4 => index 3)
            int compteur = 0;
            while (reader.Read())  // parcours ligne par ligne
            {
                if (numeroLigne == indexMilieu)
                {
                    compteur = reader.GetInt32(0);
                    Console.WriteLine("kilométrage médian = " + compteur);
                    Console.WriteLine("il y a " + indexMilieu + " véhicules ayant un km compteur inférieur");
                    Console.WriteLine("et " + indexMilieu + " véhicules ayant un km compteur supérieur");
                    break; // pour optimisation
                }
                numeroLigne++;
            }

            connection.Close();
        }
        static void Exo9(MySqlConnection connection)
        {
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            MySqlParameter nom = new MySqlParameter("@nom", MySqlDbType.VarChar);
            MySqlParameter categorie = new MySqlParameter("@categorie", MySqlDbType.VarChar);
            Console.WriteLine("Saisissez un nom ");
            string nom1 = Console.ReadLine();
            Console.WriteLine("Saisissez une catégorie ");
            string categorie1 = Console.ReadLine();
            nom.Value = nom1;
            categorie.Value = categorie1;
            command.CommandText =
                "select distinct v.modele, v.marque, l.immat from location l , client c, voiture v where l.codeC = c.codeC and l.immat = v.immat and nom = @nom and categorie = @categorie;";

            command.Parameters.Add(nom);
            command.Parameters.Add(categorie);
            MySqlDataReader reader = command.ExecuteReader();
            string[] valueString = new string[reader.FieldCount];
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    valueString[i] = reader.GetValue(i).ToString();
                    Console.Write(valueString[i] + " , ");
                }
            }
            reader.Close(); // Ne pas oublier, pour se resservir de la même variable ;-)
            connection.Close();
            */
        }
    }
}
