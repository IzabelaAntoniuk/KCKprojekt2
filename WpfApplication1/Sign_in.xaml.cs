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

namespace ProjektKCK
{
    /// <summary>
    /// Interaction logic for Sign_in.xaml
    /// </summary>
    public partial class Sign_in : Window
    {
        User us = new User();
        File file = new File();

        public Sign_in(User use)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.us = use;
        }

        private void Sign_in_Click(object sender, RoutedEventArgs e)
        {
            string log = null;
            string pass = null;
            int i = 0;
            int j = 0;

            log = login.Text;
            if (log.Length <= 0)
            {
                MessageBox.Show("Login jest wymagany.");
            }

            pass = password.Password;
            if (pass.Length <= 0)
            {
                MessageBox.Show("Hasło jest wymagane.");
            }

            foreach (User use in us.profileList)
            {
                if (use.login == log && use.haslo == pass)
                {
                    us.imie = use.imie;
                    us.nazwisko = use.nazwisko;
                    us.waga = use.waga;
                    us.wzrost = use.wzrost;
                    us.dataUr = use.dataUr;
                    us.wiek = use.wiek;
                    us.aktywnosc = use.aktywnosc;
                    us.login = use.login;
                    us.plec = use.plec;
                    us.haslo = use.haslo;
                    us.BMI = use.BMI;
                    us.kg = use.kg;
                    us.CPM = use.CPM;
                    us.newCPM = use.newCPM;
                    us.productList = use.productList;
                    us.workoutList = use.workoutList;
                    us.dzień = use.dzień;
                    us.rok = use.rok;
                    us.miesiac = use.miesiac;

                    Profile profil = new Profile(us);
                    profil.Show(); // przekazac login i haslo
                    this.Close();
                }
            }

            foreach (User use in us.profileList)
            {
                if (use.login != log)
                    i++;

                if (use.haslo != pass)
                    j++;
            }

            if (log.Length > 0 && i == us.profileList.Count)
                MessageBox.Show("Brak takiego profilu.");

            if (pass.Length > 0 && j == us.profileList.Count)
                MessageBox.Show("Nieprawidłowe hasło.");

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainW = new MainWindow();
            mainW.Show();
            this.Close();
        }

        private void myGif_MediaEnded(object sender, RoutedEventArgs e)
        {
            myGif.Position = new TimeSpan(0, 0, 1);
            myGif.Play();
        }
    }
}
