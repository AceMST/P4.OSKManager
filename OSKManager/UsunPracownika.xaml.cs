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
    /// Logika interakcji dla klasy UsunPracownika.xaml
    /// </summary>
    public partial class UsunPracownika : Window
    {
        public UsunPracownika()
        {
            InitializeComponent();
        }
        string id;
        string nazw;

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

                Sql = "Delete Pracownicy Where Id_Pracownika ='" + id + "' And Nazwisko = '" + nazw + "'";
                command = new SqlCommand(Sql, cnn);
                adapter.InsertCommand = new SqlCommand(Sql, cnn);
                adapter.InsertCommand.ExecuteNonQuery();
                command.Dispose();
                MessageBox.Show("Usunięto Pracownika");
                cnn.Close();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        private void IDn_TextChanged(object sender, TextChangedEventArgs e)
        {
            id = Id_Pracownika.Text;
        }

        private void Nazwisko_TextChanged(object sender, TextChangedEventArgs e)
        {
            nazw = Nazwisko.Text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Usun();
            Close();
        }
    }
}
