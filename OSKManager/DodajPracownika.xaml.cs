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
    /// Logika interakcji dla klasy DodajPracownika.xaml
    /// </summary>
    public partial class DodajPracownika : Window
    {
        public DodajPracownika()
        {
            InitializeComponent();
        }
        class Pracownik
        {

            public string Imie { get; set; }
            public string Nazwisko { get; set; }
            public int Telefon { get; set; }
            public string Kod_Pocztowy { get; set; }
            public string Ulica { get; set; }
        }

        public string imie;
        public string nazwisko;
        public string telefon;
        public string kodPocztowy;
        public string ulica;

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

                Sql = "Insert into Pracownicy values('" + imie + "','" + nazwisko + "','" + telefon + "','" + ulica + "','" + kodPocztowy + "')";
                command = new SqlCommand(Sql, cnn);
                adapter.InsertCommand = new SqlCommand(Sql, cnn);
                adapter.InsertCommand.ExecuteNonQuery();
                command.Dispose();
                MessageBox.Show("Dodano pracownika.");
                cnn.Close();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)  //Dodaj
        {
            Dodaj();
        }

        private void Imie_TextChanged(object sender, TextChangedEventArgs e)
        {
            imie = Imie.Text;
        }

        private void Nazwisko_TextChanged(object sender, TextChangedEventArgs e)
        {
            nazwisko = Nazwisko.Text;
        }

        private void Telefon_TextChanged(object sender, TextChangedEventArgs e)
        {
            telefon = Telefon.Text;
        }

        private void Kod_P_TextChanged(object sender, TextChangedEventArgs e)
        {
            kodPocztowy = Kod_P.Text;
        }

        private void Ulica_TextChanged(object sender, TextChangedEventArgs e)
        {
            ulica = Ulica.Text;
        }


    }
}
