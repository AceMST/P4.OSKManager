using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace OSKManager
{
    /// <summary>
    /// Logika interakcji dla klasy UsunJazde.xaml
    /// </summary>
    public partial class UsunJazde : Window
    {
        public UsunJazde()
        {
            InitializeComponent();
        }
        int idJazdy;

        public void Usun()
        {
            try
            {
                string connectionString;
                SqlConnection cnn;
                connectionString = @"Data Source=KONRAD;Initial Catalog=OSKBaza;Integrated Security=true";
                cnn = new SqlConnection(connectionString);
                cnn.Open();
                string Sql = "";
                SqlCommand command;
                SqlDataAdapter adapter = new SqlDataAdapter();

                Sql = "Delete Zajęcia Where Id_Zajęć ='" + idJazdy + "'";
                command = new SqlCommand(Sql, cnn);
                adapter.InsertCommand = new SqlCommand(Sql, cnn);
                adapter.InsertCommand.ExecuteNonQuery();
                command.Dispose();
                MessageBox.Show("Usunięto Jazdę");
                cnn.Close();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void Jazda_TextChanged(object sender, TextChangedEventArgs e)
        {
            idJazdy = Convert.ToInt32(Id_Jazdy.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Usun();
        }
    }
}
