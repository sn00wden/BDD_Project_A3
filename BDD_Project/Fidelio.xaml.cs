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
using System.Data;

namespace BDD_Project
{
    /// <summary>
    /// Interaction logic for Fidelio.xaml
    /// </summary>
    public partial class Fidelio : Window
    {
        private List<string> Header;
        private DataTable Data;
        private string table_name = "Fidelio";
        public Fidelio()
        {
            InitializeComponent();
            this.Header = Tools.Get_Header(Tools.Connection, table_name);

            //this.DataContext = Tools.Get_Data(Tools.Connection,"*", table_name);


            string req = "select client_individuel.Nom_Client_Individuel,client_individuel.Prenom,fidelio.Description,client_individuel.Date_Adhesion from client_individuel inner join fidelio on fidelio.No_Programme = Numero_Programme";
            this.Data = Tools.Create_Datatable(Tools.Connection, table_name,req);
            Data_Grid.ItemsSource = this.Data.DefaultView;
            Data_Grid.AutoGenerateColumns = true;
            

        }
        private void Export_Click(object sender, RoutedEventArgs e)
        {

            Tools.Json(Tools.Connection, this.table_name, this.Header, @"..\..\..\Fidelio.json");
            MessageBox.Show("Export done");

        }
    }
}
