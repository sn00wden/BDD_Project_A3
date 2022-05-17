using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace BDD_Project
{
    /// <summary>
    /// Logique d'interaction pour Gestion_Piece.xaml
    /// </summary>
    public partial class Gestion_Piece : Window
    {
        private List<string> Header;
        private DataTable Data;

        public Gestion_Piece()
        {
            InitializeComponent();
            this.Header = Tools.Get_Header(Tools.Connection, "Pieces");

            //this.DataContext = Tools.Get_Data(Tools.Connection,"*", "Pieces");
            this.Data = Tools.Create_Datatable(Tools.Connection, "Pieces");
            Piece_Liste.ItemsSource = this.Data.DefaultView;
            Piece_Liste.AutoGenerateColumns = true;

            //this.Highlight_Lacking_Component();
        }

        //method to highlight row if quantite = 0
        /*private void Highlight_Lacking_Component()
        {
            foreach (DataRowView row in Piece_Liste.Items)
            {
                if (row["Quantite"].ToString() == "0")
                {
                    row.Row.Background = System.Windows.Media.Brushes.Red;
                }
            }
        }*/
        /*private void Highlight_Lacking_Component()
        {
            for(int i = 0;i<Piece_Liste.Items.Count; i++)
            {
                if (Piece_Liste.Items[i] != null)
                {
                    
                    if (Piece_Liste.Items[i].ToString() == "0")
                    {
                        Piece_Liste.RowBackground= Brushes.Red;
                    }
                }
            }
        }*/


        /*private void Piece_Liste_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            DataGridCellInfo edited_cell = Piece_Liste.CurrentCell;

            bool new_edit = Piece_Liste.CommitEdit();

            MessageBox.Show("New : " + new_edit + "Old : " + this.edit);

            DataRowView edited_object = (DataRowView)Piece_Liste.SelectedItem;

            if (new_edit == true && edit == false)
            {
                //Remove commas from float values
                *//*if (edited_object["Prix_achat"].Contains(","))
                {
                    edited_object["Prix_achat"] = edited_object["Prix_achat"].ToString().Replace(",", ".");
                }*//*


                Tools.Requete(Tools.Connection, "UPDATE Pieces SET " + this.Header[edited_cell.Column.DisplayIndex] + " = '" + edited_object[this.Header[edited_cell.Column.DisplayIndex]].ToString() + "' WHERE ID_Piece = " + (edited_object["ID_Piece"]));


            }
            this.edit = new_edit;


        }*/

        private DataGridCellInfo edited_cell;

        private DataRowView edited_object;
        public void EditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

            //Get edit cell
            

            DataRowView new_object = (DataRowView)(((DataGrid)sender).CurrentCell.Item);

            MessageBox.Show("Modif done");
            
            MessageBox.Show("UPDATE Pieces SET " + this.Header[this.edited_cell.Column.DisplayIndex] + " = '" + new_object[this.Header[this.edited_cell.Column.DisplayIndex]] + "' WHERE ID_Piece = " + (this.edited_object["ID_Piece"]));
            Tools.Requete(Tools.Connection, "UPDATE Pieces SET " + this.Header[this.edited_cell.Column.DisplayIndex] + " = '" + new_object[this.Header[this.edited_cell.Column.DisplayIndex]] + "' WHERE ID_Piece = " + (this.edited_object["ID_Piece"]));


        }

        private void Piece_Liste_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            this.edited_cell = Piece_Liste.CurrentCell;
            this.edited_object = (DataRowView)Piece_Liste.SelectedItem;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            //Delete selected row
            DataRowView selected_row = (DataRowView)Piece_Liste.SelectedItem;
            Tools.Delete_Request(Tools.Connection, "Pieces", "ID_Piece = "+ selected_row["ID_Piece"]);
            Piece_Liste.ItemsSource = Tools.Create_Datatable(Tools.Connection, "Pieces").DefaultView;
            
        }

        //add row method and update database
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            //Add row
            //new row
            DataRow new_row = this.Data.NewRow();

            new_row["ID_Piece"] = Tools.GetLastID(Tools.Connection, "Pieces","ID_Piece") + 1;
            string request = "INSERT INTO Pieces VALUES (";
            request += new_row["ID_Piece"] + ",";
            foreach (string header in this.Header)
            {
                if (header == "ID_Piece")
                {
                    continue;
                }
                else if (header == "Date_Intro_Marche")
                {
                    new_row[header] = System.DateTime.Now.ToString("yyyy-MM-dd");
                }
                else if (header == "Date_Discontinuation")
                {
                    new_row[header] = "0000-00-00";
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
            Tools.Requete(Tools.Connection, request);
            this.Data = Tools.Create_Datatable(Tools.Connection, "Pieces");
            Piece_Liste.ItemsSource = this.Data.DefaultView;
        }


        /*private void Add_Click(object sender, RoutedEventArgs e)
        {
            //Add row
            DataRowView new_row = (DataRowView)Piece_Liste.Items[0].GetType().GetProperty("NewRow").GetValue(Piece_Liste.Items[0], null);
            new_row.Row.Table.Rows.Add(new_row.Row);
            Piece_Liste.ItemsSource = Tools.Create_Datatable(Tools.Connection, "Pieces").DefaultView;
        }*/
    }
}
