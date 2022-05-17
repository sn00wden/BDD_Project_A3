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

namespace BDD_Project
{
    /// <summary>
    /// Logique d'interaction pour Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

/*        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;

        }
*/


        private void Gestion_Piece_Button(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Gestion_Piece gestion_Piece = new Gestion_Piece();
            gestion_Piece.ShowDialog();
            this.Show();
        }

        private void Gestion_Velo_Button(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Gestion_Velo gestion_Velo = new Gestion_Velo();
            gestion_Velo.ShowDialog();
            this.Show();

        }

        private void Gestion_Stock_Button(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Gestion_Stock gestion_Stock = new Gestion_Stock();

            gestion_Stock.ShowDialog();
            this.Show();


        }

        private void Gestion_Commande_Button(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Gestion_Commande gestion_Commande = new Gestion_Commande();
            gestion_Commande.ShowDialog();
            this.Show();

        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            //read file
            string[] lines = System.IO.File.ReadAllLines(@"..\..\..\Base_de_donnee_VeloMax.sql");
            Tools.Requete(Tools.Connection, string.Join(" ",lines));
            MessageBox.Show("Base de donnée réinitialisée");

        }

        private void Clients_Individuels_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Client_Individuels clients_Individuels = new Client_Individuels();
            clients_Individuels.ShowDialog();
            this.Show();

        }

        private void Clients_Professionels_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Clients_Professionels clients_Professionels = new Clients_Professionels();
            clients_Professionels.ShowDialog();
            this.Show();

        }
    }
}
