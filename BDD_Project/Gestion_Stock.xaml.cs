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
    /// Logique d'interaction pour Gestion_Stock.xaml
    /// </summary>
    public partial class Gestion_Stock : Window
    {
        private List<string> Header;
        private DataTable Data;
        private string table_name = "Stock";
        public Gestion_Stock()
        {
            InitializeComponent();
            this.Header = Tools.Get_Header(Tools.Connection, table_name);

            //this.DataContext = Tools.Get_Data(Tools.Connection,"*", table_name);
            this.Data = Tools.Create_Datatable(Tools.Connection, table_name);
            Stock_Liste.ItemsSource = this.Data.DefaultView;
            Stock_Liste.AutoGenerateColumns = true;
        }

        #region Common part

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

        private void Stock_Liste_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            this.edited_cell = Stock_Liste.CurrentCell;
            this.edited_object = (DataRowView)Stock_Liste.SelectedItem;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            //Delete selected row
            DataRowView selected_row = (DataRowView)Stock_Liste.SelectedItem;
            Tools.Delete_Request(Tools.Connection, table_name, "ID_Piece = " + selected_row["ID_Piece"]);
            Stock_Liste.ItemsSource = Tools.Create_Datatable(Tools.Connection, table_name).DefaultView;

        }

        //add row method and update database
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            //Add row
            //new row
            DataRow new_row = this.Data.NewRow();

            new_row["ID_Piece"] = Tools.GetLastID(Tools.Connection, table_name, "ID_Piece") + 1;
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
                    new_row[header] = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                }
                else if (header == "Date_Discontinuation")
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
            Stock_Liste.ItemsSource = this.Data.DefaultView;
        }

        /*private void Export_Click(object sender, RoutedEventArgs e)
        {

            Tools.Json(Tools.Connection, this.Header, @"..\..\..\Stock.json");

        }*/

        #endregion
    }
}
