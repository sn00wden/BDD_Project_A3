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
    /// Logique d'interaction pour Gestion_Piece.xaml
    /// </summary>
    public partial class Gestion_Piece : Window
    {
        
        public Gestion_Piece()
        {
            InitializeComponent();
            List<string> Piece_List = Tools.Requete(Tools.Connection, "*", "pieces");
            foreach (string s in Piece_List)
            {
                /*string[] specs = s.Split(';');
                Piece_Liste.Items.Add(specs[0]);*/
                //MessageBox.Show(s);

            }

        }
    }
}
