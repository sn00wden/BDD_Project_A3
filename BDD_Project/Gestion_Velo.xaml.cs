using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;

namespace BDD_Project
{
    /// <summary>
    /// Logique d'interaction pour Gestion_Velo.xaml
    /// </summary>
    public partial class Gestion_Velo : Window
    {
        private List<string> Header;
        private DataTable Data;
        private string table_name = "bicyclette";
        public Gestion_Velo()
        {
            InitializeComponent();
            this.Data = Tools.Create_Datatable(Tools.Connection, table_name);
            this.Header = Tools.Get_Header(Tools.Connection, table_name);
            Velo_Liste.ItemsSource = this.Data.DefaultView;
            Velo_Liste.AutoGenerateColumns = true;
            piece_manquante(Tools.Connection);
        }

        public void piece_manquante(MySqlConnection connection)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT Stock,Nom FROM "+ this.table_name+";";

            MySqlDataReader reader;
            reader = command.ExecuteReader();

            string p = "";

            while (reader.Read())
            {
                string a = (reader.GetValue(0).ToString());
                if (a[0] == '0')
                {
                    p += reader.GetValue(1).ToString() + ", ";
                }
            }
            reader.Close();
            p = p.Remove(p.Length - 2);
            MessageBox.Show("Aucune vélo de la liste suivante n'est en stock : " + p);

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
            piece_manquante(Tools.Connection);

        }

        private void BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            this.edited_cell = Velo_Liste.CurrentCell;
            this.edited_object = (DataRowView)Velo_Liste.SelectedItem;
            
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            //Delete selected row
            DataRowView selected_row = (DataRowView)Velo_Liste.SelectedItem;
            Tools.Delete_Request(Tools.Connection, table_name, this.Header[0] +" = " + selected_row[this.Header[0]]);
            Velo_Liste.ItemsSource = Tools.Create_Datatable(Tools.Connection, table_name).DefaultView;
            

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
            Velo_Liste.ItemsSource = this.Data.DefaultView;
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {

            string t = Tools.Json(Tools.Connection,this.table_name, this.Header, @"..\..\..\Velos.json");
            MessageBox.Show("Export done : " + t);

        }

        #endregion

    }
}
