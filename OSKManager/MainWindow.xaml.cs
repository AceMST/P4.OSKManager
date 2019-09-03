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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;

namespace OSKManager
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string sqlPr = "Select Id_Pracownika, Imię, Nazwisko, Telefon, Kod_Pocztowy, Ulica from Pracownicy";
        string sqlK = "Select Id_Kursanta AS Id, Imię, Nazwisko, Kategoria, Telefon, NumerPKK, Kod_Pocztowy, Ulica, Id_Pracownika AS Instruktor, Liczba_jazd AS [Liczba godzin], Opis from Kursanci";
        string sqlPoj = "Select Model, nr_Rejestracyjny, DataZakupu from Pojazdy";
        string kursy = "Select Kategoria, Cena AS [Cena kursu], Liczba_godzin AS [Liczba godzin] from Kursy";
        string sqlJ = "Select * From Zajęcia";
        public void Wyswietl(string query, string tabela) // Do wyswietlania z bazy według string'ów wyżej
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Data Source=KONRAD;Initial Catalog=OSKBaza;Integrated Security=true";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            SqlCommand command;

            string Sql;

            Sql = query;
            command = new SqlCommand(Sql, cnn);
            command.ExecuteNonQuery();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable(tabela);
            dataAdapter.Fill(dt);
            DataGrid1.ItemsSource = dt.DefaultView;
            dataAdapter.Update(dt);
            cnn.Close();
        }
        

       


        private void Button_Click(object sender, RoutedEventArgs e) // Do kursantów
        {
            string tab = "Pracownicy";
            Wyswietl(sqlK, tab);
        }
        private void Button_Click_1(object sender, RoutedEventArgs e) //Pracownicy
        {
            string tab = "Pracownicy";
            Wyswietl(sqlPr, tab);
        }
        private void Button_Click_2(object sender, RoutedEventArgs e) //Pojazdy
        {
            string tab = "Pojazdy";
            Wyswietl(sqlPoj, tab);
        }

        private void DataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e) // + Kursant
        {
            DodajKursanta NowyKursant = new DodajKursanta();
            NowyKursant.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e) // + Pojazd
        {
            DodajPojazd NowyPojazd = new DodajPojazd();
            NowyPojazd.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e) // + Pracownik
        {
            DodajPracownika NowyPracownik = new DodajPracownika();
            NowyPracownik.Show();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e) // - Kursant
        {
            UsunKursanta UsunKursant = new UsunKursanta();
            UsunKursant.Show();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e) // - Pojazd
        {
            UsunPojazd Usunpoj = new UsunPojazd();
            Usunpoj.Show();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e) // - Pracownik
        {
            UsunPracownika usunPracownik = new UsunPracownika();
            usunPracownik.Show();
        }

        private void Button_Click_9(object sender, RoutedEventArgs e) // Kursy
        {
            string tab = "Kursy";
            Wyswietl(kursy, tab);
        }

        private void Button_Click_10(object sender, RoutedEventArgs e) // Jazdy
        {
            string tab = "Jazdy";
            Wyswietl(sqlJ, tab);
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            DodajJazdy NowaJazda = new DodajJazdy();
            NowaJazda.Show();
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            UsunJazde usunJazde = new UsunJazde();
            usunJazde.Show();
        }
    }
}
