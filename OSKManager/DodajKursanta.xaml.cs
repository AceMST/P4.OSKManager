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
    /// Logika interakcji dla klasy DodajKursanta.xaml
    /// </summary>
    public partial class DodajKursanta : Window
    {
        public DodajKursanta()
        {
            InitializeComponent();
            fill_combo();
            fill_combo2();
           
            
        }
             public void fill_combo()
        {
            string connectionString;
            SqlConnection cnn;
            connectionString = @"Data Source=KONRAD;Initial Catalog=OSKBaza;Integrated Security=true";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            string sqlQ= "Select * from Kursy";
           
            SqlCommand createCommand = new SqlCommand(sqlQ, cnn);
            createCommand.ExecuteNonQuery();
            SqlDataReader dr = createCommand.ExecuteReader();
            while (dr.Read())
            {
                string nazw = dr.GetString(0);
                ComboBox1.Items.Add(nazw);
               
            }
       
            cnn.Close();      
        }
        public void fill_combo2()
        {
            string connectionString1;
            SqlConnection cnn2;
            connectionString1 = @"Data Source=KONRAD;Initial Catalog=OSKBaza;Integrated Security=true";
            cnn2 = new SqlConnection(connectionString1);
            cnn2.Open();
            string sqlQ1 = "Select * from Pracownicy";

            SqlCommand createCommand1 = new SqlCommand(sqlQ1, cnn2);
            createCommand1.ExecuteNonQuery();
            SqlDataReader dr1 = createCommand1.ExecuteReader();
            while (dr1.Read())
            {
                string nazwa = dr1.GetInt32(0).ToString();              
                ComboBox2.Items.Add(nazwa);

            }
            cnn2.Close();
        }
    


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

                Sql = "Insert into Kursanci values('" + im + "','" + surr + "','" + tel + "','" + ul + "','" + instr + "','" + kod + "','" + pkk + "','" + jazdy + "','" + kat + "','" + opis + "')";
                command = new SqlCommand(Sql, cnn);
                adapter.InsertCommand = new SqlCommand(Sql, cnn);
                adapter.InsertCommand.ExecuteNonQuery();
                command.Dispose();
                MessageBox.Show("Dodano Kursanta.");
                cnn.Close();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
               
            }
        }
        public string im;
        public string surr;
        public string tel;
        public string kod;
        public string ul;
        public string pkk;
        public int jazdy = 0;
        public string kat ;
        public string instr;
        public string opis;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Dodaj();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            im = Imie.Text;
        }

        private void Nazwisko_TextChanged(object sender, TextChangedEventArgs e)
        {
            surr = Nazwisko.Text;
        }

        private void PKK_TextChanged(object sender, TextChangedEventArgs e)
        {
            pkk = PKK.Text;
        }

        private void Telefon_TextChanged(object sender, TextChangedEventArgs e)
        {
            tel = Telefon.Text;
        }

        private void Kod_P_TextChanged(object sender, TextChangedEventArgs e)
        {
            kod = Kod_P.Text;
        }

        private void Ulica_TextChanged(object sender, TextChangedEventArgs e)
        {
            ul = Ulica.Text;
        }

        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            instr = ComboBox2.Text;
        }

        private void Opis_TextChanged(object sender, TextChangedEventArgs e)
        {
            opis = Opis.Text;
        }

        private void ComboBox1_DropDownClosed(object sender, EventArgs e)
        {


            string connectionString;
            SqlConnection cnn;
            connectionString = @"Data Source=KONRAD;Initial Catalog=OSKBaza;Integrated Security=true";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            string sqlQ = "Select * from Kursy where Kategoria='" + ComboBox1.Text + "'";

            SqlCommand createCommand = new SqlCommand(sqlQ, cnn);
            createCommand.ExecuteNonQuery();
            SqlDataReader dr = createCommand.ExecuteReader();
            while (dr.Read())
            {
                string nazw = dr.GetString(0);
                kat = nazw;
            }
            cnn.Close();

        }

        private void ComboBox2_DropDownClosed(object sender, EventArgs e)
        {
            string connectionString1;
            SqlConnection cnn2;
            connectionString1 = @"Data Source=KONRAD;Initial Catalog=OSKBaza;Integrated Security=true";
            cnn2 = new SqlConnection(connectionString1);
            cnn2.Open();
            string sqlQ1 = "Select * from Pracownicy where Id_Pracownika='" + ComboBox2.Text + "' ";

            SqlCommand createCommand1 = new SqlCommand(sqlQ1, cnn2);
            createCommand1.ExecuteNonQuery();
            SqlDataReader dr1 = createCommand1.ExecuteReader();
            while (dr1.Read())
            {
                string numer = dr1.GetInt32(0).ToString();
                string imie = dr1.GetString(1);
                string nazwisko = dr1.GetString(2);
                InstruktorView.Text = imie + " " + nazwisko;
                instr = numer;

            }
            cnn2.Close();
        }

        private void InstruktorView_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
