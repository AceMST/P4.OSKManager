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
    /// Logika interakcji dla klasy DodajPojazd.xaml
    /// </summary>
    public partial class DodajPojazd : Window
    {
        public DodajPojazd()
        {
            InitializeComponent();
        }

       
        public string numRej;
        public string model;
        public string zakup;
        
        public void Dodaj()
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

                Sql = "Insert into Pojazdy (nr_Rejestracyjny, Model, DataZakupu) values('" + numRej + "','" + model + "','" + zakup + "')";
                command = new SqlCommand(Sql, cnn);
                adapter.InsertCommand = new SqlCommand(Sql, cnn);
                adapter.InsertCommand.ExecuteNonQuery();
                command.Dispose();
                MessageBox.Show("Dodano Pojazd.");
                cnn.Close();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Dodaj();
        }

        private void Rejestracja_TextChanged(object sender, TextChangedEventArgs e)
        {
            numRej = Rejestracja.Text;
        }

        private void Model_TextChanged(object sender, TextChangedEventArgs e)
        {
            model = Model.Text;
        }

        private void Zakup_TextChanged(object sender, TextChangedEventArgs e)
        {
            zakup = Zakup.Text;
        }
    }
}
