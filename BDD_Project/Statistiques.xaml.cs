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
    /// Interaction logic for Statistiques.xaml
    /// </summary>
    public partial class Statistiques : Window
    {
        private string bef = "SELECT ";
        
        public Statistiques()
        {
            InitializeComponent();
        }

        private void Velos_commande_Click(object sender, RoutedEventArgs e)
        {
            string req = "select bicyclette.nom, sum(contenir_bicyclette.quantite) from bicyclette,contenir_bicyclette,commande WHERE (commande.id_commande = contenir_bicyclette.id_commande and contenir_bicyclette.id_bicyclette = bicyclette.id_bicyclette) GROUP BY bicyclette.nom";
            Data_Grid.ItemsSource = Tools.Create_Datatable(Tools.Connection,"bicyclette",req).DefaultView;
            Data_Grid.AutoGenerateColumns = true;            

        }

        private void Piece_commande_Click(object sender, RoutedEventArgs e)
        {
            string req = "select pieces.description,contenir_pieces.quantite from pieces,contenir_pieces,commande WHERE (commande.id_commande = contenir_pieces.id_commande and contenir_pieces.id_piece = pieces.id_piece) GROUP BY pieces.description";
            Data_Grid.ItemsSource = Tools.Create_Datatable(Tools.Connection, "pieces", req).DefaultView;
            Data_Grid.AutoGenerateColumns = true;
        }

        private void Nb_membres_fidelio_Click(object sender, RoutedEventArgs e)
        {
            string req = "select fidelio.description, count(souscrit.No_programme) from Fidelio,Souscrit WHERE souscrit.No_programme = fidelio.No_programme GROUP BY souscrit.No_programme";
            Data_Grid.ItemsSource = Tools.Create_Datatable(Tools.Connection, "", req).DefaultView;
            Data_Grid.AutoGenerateColumns = true;

        }

        private void Date_exp_Click(object sender, RoutedEventArgs e)
        {
            string req = "select day(Client_Individuel.Date_Adhesion),month(Client_Individuel.Date_Adhesion),year(Client_Individuel.Date_Adhesion)+fidelio.duree,Client_Individuel.Nom_Client_Individuel from Client_Individuel,fidelio Where Client_Individuel.Numero_Programme = Fidelio.No_Programme";
            Data_Grid.ItemsSource = Tools.Create_Datatable(Tools.Connection, "", req).DefaultView;
            Data_Grid.AutoGenerateColumns = true;
        }

        private void Best_client_pro_Click(object sender, RoutedEventArgs e)
        {
            string req = "select Commander_PRO.ID_Client_Pro,sum(commande.Prix) from Commander_PRO,commande WHERE commande.id_commande = commander_pro.id_commande GROUP BY Commander_PRO.ID_Client_Pro ORDER BY sum(commande.Prix) desc  ";
            Data_Grid.ItemsSource = Tools.Create_Datatable(Tools.Connection, "", req).DefaultView;
            Data_Grid.AutoGenerateColumns = true;
        }

        private void Best_client_ind_Click(object sender, RoutedEventArgs e)
        {
            string req = "select Commander_INDIVIDUEL.ID_Client_Individuel,sum(commande.Prix) from Commander_INDIVIDUEL,commande WHERE commande.id_commande = Commander_INDIVIDUEL.id_commande GROUP BY ID_Client_Individuel ORDER BY sum(commande.Prix) desc ";
            Data_Grid.ItemsSource = Tools.Create_Datatable(Tools.Connection, "", req).DefaultView;
            Data_Grid.AutoGenerateColumns = true;
        }

        private void Mean_com_price_Click(object sender, RoutedEventArgs e)
        {
            string req = "select avg(prix) from commande";
            Data_Grid.ItemsSource = Tools.Create_Datatable(Tools.Connection, "", req).DefaultView;
            Data_Grid.AutoGenerateColumns = true;
        }

        private void Mean_nb_velo_Click(object sender, RoutedEventArgs e)
        {
            string req = "select avg(quantite) from contenir_bicyclette";
            Data_Grid.ItemsSource = Tools.Create_Datatable(Tools.Connection, "", req).DefaultView;
            Data_Grid.AutoGenerateColumns = true;


        }

        private void Mean_nb_piece_Click(object sender, RoutedEventArgs e)
        {
            string req = "select avg(quantite) from contenir_pieces";
            Data_Grid.ItemsSource = Tools.Create_Datatable(Tools.Connection, "", req).DefaultView;
            Data_Grid.AutoGenerateColumns = true;

        }
    }
}
