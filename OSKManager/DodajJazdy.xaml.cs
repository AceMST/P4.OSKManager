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
    /// Logika interakcji dla klasy DodajJazdy.xaml
    /// </summary>
    public partial class DodajJazdy : Window
    {
        public DodajJazdy()
        {
            InitializeComponent();
            fill_combo1();
            fill_combo2();
            fill_combo3();
        }

        public int czas;
        public int idKursant;
        public int idPracownik;
        public string nrRejestr;
        public string katIf;
        public void dodajGodziny()
        {
            string connectionString;
            SqlConnection cnn;
            connectionString = @"Data Source=KONRAD;Initial Catalog=OSKBaza;Integrated Security=true";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            string Sql = "";
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            Sql = "Update Kursanci SET Liczba_jazd= '" + czas + "'  WHERE Id_Kursanta = '"+ idKursant+"'";
            command = new SqlCommand(Sql, cnn);
            adapter.InsertCommand = new SqlCommand(Sql, cnn);
            adapter.InsertCommand.ExecuteNonQuery();
            command.Dispose();
            cnn.Close();
            Close();
         
        }
        public void PodliczGodziny()
        {
            string connectionString;
            SqlConnection cnn;
            connectionString = @"Data Source=KONRAD;Initial Catalog=OSKBaza;Integrated Security=true";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            string sqlQ = "Select * from Kursanci where Id_Kursanta = '" +idKursant+"'";

            SqlCommand createCommand = new SqlCommand(sqlQ, cnn);
            createCommand.ExecuteNonQuery();
            SqlDataReader dr = createCommand.ExecuteReader();
            while (dr.Read())
            {
                string czasj = dr.GetInt32(8).ToString();
                string kat = dr.GetString(9);
                katIf = kat;
                czas += Convert.ToInt32(czasj);
            }
            cnn.Close();
            if (katIf=="B" && czas >=30 )
            {
                MessageBox.Show("Kursant zakończył szkolenie");
                zakonczenie();
            }
            if (katIf=="A" && czas >= 15)
            {
                MessageBox.Show("Kursant zakończył szkolenie");
                zakonczenie();
            }
            if (katIf == "C" && czas >= 30)
            {
                MessageBox.Show("Kursant zakończył szkolenie");
                zakonczenie();
            }
            if (katIf == "D" && czas >= 30)
            {
                MessageBox.Show("Kursant zakończył szkolenie");
                zakonczenie();
            }
            else
                Close();

        }
        public void zakonczenie()
        {
            katIf = katIf.Insert(katIf.Length, " Zakończono");

            string connectionString;
            SqlConnection cnn;
            connectionString = @"Data Source=KONRAD;Initial Catalog=OSKBaza;Integrated Security=true";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            string Sql = "";
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            Sql = "Update Kursanci SET Opis= '" + katIf + "' where Id_Kursanta = '" + idKursant + "'";
            command = new SqlCommand(Sql, cnn);
            adapter.InsertCommand = new SqlCommand(Sql, cnn);
            adapter.InsertCommand.ExecuteNonQuery();
            command.Dispose();
            cnn.Close();
        }
        public void fill_combo1()
        {
            string connectionString;
            SqlConnection cnn;
            connectionString = @"Data Source=KONRAD;Initial Catalog=OSKBaza;Integrated Security=true";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            string sqlQ = "Select * from Kursanci";

            SqlCommand createCommand = new SqlCommand(sqlQ, cnn);
            createCommand.ExecuteNonQuery();
            SqlDataReader dr = createCommand.ExecuteReader();
            while (dr.Read())
            {
                string nazw = dr.GetInt32(0).ToString();
                ComboBox1.Items.Add(nazw);

            }

            cnn.Close();
        }

        public void fill_combo2()
        {
            string connectionString;
            SqlConnection cnn;
            connectionString = @"Data Source=KONRAD;Initial Catalog=OSKBaza;Integrated Security=true";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            string sqlQ = "Select * from Pracownicy";

            SqlCommand createCommand = new SqlCommand(sqlQ, cnn);
            createCommand.ExecuteNonQuery();
            SqlDataReader dr = createCommand.ExecuteReader();
            while (dr.Read())
            {
                string nazw = dr.GetInt32(0).ToString();
                ComboBox2.Items.Add(nazw);

            }

            cnn.Close();
        }

        public void fill_combo3()
        {
            string connectionString;
            SqlConnection cnn;
            connectionString = @"Data Source=KONRAD;Initial Catalog=OSKBaza;Integrated Security=true";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            string sqlQ = "Select * from Pojazdy";

            SqlCommand createCommand = new SqlCommand(sqlQ, cnn);
            createCommand.ExecuteNonQuery();
            SqlDataReader dr = createCommand.ExecuteReader();
            while (dr.Read())
            {
                string nazw = dr.GetString(1);
                ComboBox3.Items.Add(nazw);

            }

            cnn.Close();
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
                Sql = "Insert into Zajęcia values('" + czas + "','" + idKursant + "','" + idPracownik + "','" + nrRejestr + "')";
                command = new SqlCommand(Sql, cnn);
                adapter.InsertCommand = new SqlCommand(Sql, cnn);
                adapter.InsertCommand.ExecuteNonQuery();
                command.Dispose();
                MessageBox.Show("Dodano Jazdę.");
                cnn.Close();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

       

        private void KursantView_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void InstruktorView_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void PojazdView_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DataView_TextChanged(object sender, TextChangedEventArgs e)
        {
      
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            Dodaj();
            PodliczGodziny();
            dodajGodziny();
           
           
        }

     

        private void ComboBox1_DropDownClosed(object sender, EventArgs e)
        {
            string connectionString1;
            SqlConnection cnn2;
            connectionString1 = @"Data Source=KONRAD;Initial Catalog=OSKBaza;Integrated Security=true";
            cnn2 = new SqlConnection(connectionString1);
            cnn2.Open();
            string sqlQ1 = "Select * from Kursanci where Id_Kursanta='" + ComboBox1.Text + "' ";

            SqlCommand createCommand1 = new SqlCommand(sqlQ1, cnn2);
            createCommand1.ExecuteNonQuery();
            SqlDataReader dr1 = createCommand1.ExecuteReader();
            while (dr1.Read())
            {
                string numer = dr1.GetInt32(0).ToString();
                string imie = dr1.GetString(1);
                string nazwisko = dr1.GetString(2);
                KursantView.Text = imie + " " + nazwisko;
                idKursant = Convert.ToInt32(numer);
            

            }
            cnn2.Close();
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
                idPracownik = Convert.ToInt32(numer);


            }
            cnn2.Close();
        }

        private void ComboBox3_DropDownClosed(object sender, EventArgs e)
        {
            string connectionString1;
            SqlConnection cnn2;
            connectionString1 = @"Data Source=KONRAD;Initial Catalog=OSKBaza;Integrated Security=true";
            cnn2 = new SqlConnection(connectionString1);
            cnn2.Open();
            string sqlQ1 = "Select * from Pojazdy where Model ='" + ComboBox3.Text + "' ";

            SqlCommand createCommand1 = new SqlCommand(sqlQ1, cnn2);
            createCommand1.ExecuteNonQuery();
            SqlDataReader dr1 = createCommand1.ExecuteReader();
            while (dr1.Read())
            {
                string numer = dr1.GetString(0);
                
                
                PojazdView.Text = numer;
                nrRejestr = numer;
               


            }
            cnn2.Close();
        }

        private void Time_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                czas = Convert.ToInt32(CzasJazdy.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
