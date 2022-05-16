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
        private string pswd;
        private string username;
        
        public MainWindow()
        {
           

        }
        private void Main_PSWD(object sender, RoutedEventArgs e)
        {
            this.pswd = PSWD_box.Password;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection("server=localhost;user id=" + this.username + ";database=velomax;password=" + this.pswd + ";");
                connection.Open();
                Tools.Connection = connection;
                MessageBox.Show("Connexion réussie");
                

                this.Hide();

                Menu menu = new Menu();
                menu.Show();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void ID_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.username = username_box.Text;
        }
    }
}
