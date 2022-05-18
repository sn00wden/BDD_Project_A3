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
    /// Logique d'interaction pour Gestion_Commande.xaml
    /// </summary>
    public partial class Gestion_Commande : Window
    {
        private List<string> Header;
        private DataTable Data;
        private string table_name = "Commande";
        public Gestion_Commande()
        {
            InitializeComponent();
            this.Header = Tools.Get_Header(Tools.Connection, table_name);

            //this.DataContext = Tools.Get_Data(Tools.Connection,"*", table_name);
            this.Data = Tools.Create_Datatable(Tools.Connection, table_name);
            Commande_Liste.ItemsSource = this.Data.DefaultView;
            Commande_Liste.AutoGenerateColumns = true;
        }



        
        #region Common part

        private DataGridCellInfo edited_cell;

        private DataRowView edited_object;
        public void EditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

            //Get edit cell


            DataRowView new_object = (DataRowView)(((DataGrid)sender).CurrentCell.Item);

            MessageBox.Show("Modif done");

            MessageBox.Show("UPDATE " + this.table_name + " SET " + this.Header[this.edited_cell.Column.DisplayIndex] + " = '" + new_object[this.Header[this.edited_cell.Column.DisplayIndex]] + "' WHERE " + this.Header[0] + " = '" + (this.edited_object[this.Header[0]]) + "'");
            Tools.Requete(Tools.Connection, "UPDATE " + this.table_name + " SET " + this.Header[this.edited_cell.Column.DisplayIndex] + " = '" + new_object[this.Header[this.edited_cell.Column.DisplayIndex]] + "' WHERE " + this.Header[0] + " = '" + (this.edited_object[this.Header[0]]) + "'");


        }

        private void Commande_Liste_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            this.edited_cell = Commande_Liste.CurrentCell;
            this.edited_object = (DataRowView)Commande_Liste.SelectedItem;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            //Delete selected row
            DataRowView selected_row = (DataRowView)Commande_Liste.SelectedItem;
            Tools.Delete_Request(Tools.Connection, table_name, "ID_Commande = " + selected_row[this.Header[0]]);
            Commande_Liste.ItemsSource = Tools.Create_Datatable(Tools.Connection, table_name).DefaultView;

        }

        //add row method and update database
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            //Add row
            //new row
            DataRow new_row = this.Data.NewRow();

            new_row[this.Header[0]] = Tools.GetLastID(Tools.Connection, table_name, this.Header[0]) + 1;
            string request = "INSERT INTO " + this.table_name + " VALUES (";
            request += new_row[this.Header[0]] + ",";
            foreach (string header in this.Header)
            {
                if (header == this.Header[0])
                {
                    continue;
                }
                else if (header == "Date_Commande")
                {
                    new_row[header] = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                }
                else if (header == "Date_Livraison")
                {
                    new_row[header] = default(System.DateTime).ToString("yyyy-MM-dd HH:mm:ss");
                }

                else
                {
                    new_row[header] = 0;
                }
                //gives new_row[header] a null value of header type




                request += "'" + new_row[header] + "',";
            }
            //update database
            request = request.Remove(request.Length - 1);
            request += ");";
            MessageBox.Show(request);
            ////Update database
            Tools.Add_Row(Tools.Connection, request);
            this.Data = Tools.Create_Datatable(Tools.Connection, table_name);
            Commande_Liste.ItemsSource = this.Data.DefaultView;
        }
        private void Export_Click(object sender, RoutedEventArgs e)
        {

            Tools.Json(Tools.Connection,this.table_name, this.Header, @"..\..\..\Commandes.json");
            MessageBox.Show("Export done");

        }

        #endregion
    }
}
