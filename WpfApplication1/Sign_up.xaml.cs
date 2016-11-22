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
    /// Interaction logic for Sign_up.xaml
    /// </summary>
    public partial class Sign_up : Window
    {
        User us = new User();
        File file = new File();
        List<User> profileList = new List<User>();

        public Sign_up(User use)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.us = use;
            //this.contentControl.Content = new Sign_up_part1(this.contentControl);
        }

        public void zapiszListe()
        {
            file.zapisywaniePlikuProfile(profileList);
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            User us = new User();

            try
            {
                us.imie = name.Text;
                us.nazwisko = surname.Text;
                us.haslo = password.Text;
                us.login = login.Text;
                us.rok = int.Parse(year.Text);
                us.miesiac = int.Parse(month.Text);
                us.dzień = int.Parse(day.Text);
                us.dataUr = us.rok + "-" + us.miesiac + "-" + us.dzień;

                DateTime now = DateTime.Today;
                us.wiek = now.Year - us.rok;

                if (us.imie.Length <= 0)
                {
                    MessageBox.Show("Imie.");

                }

                else if (us.nazwisko.Length <= 0)
                {
                    MessageBox.Show("Wprowadz nazwisko.");
                }

                else if (us.haslo.Length <= 0)
                {
                    MessageBox.Show("Wprowadz haslo.");
                }

                else if (us.login.Length <= 0)
                {
                    MessageBox.Show("Wprowadz login.");
                }
                else
                {
                    this.contentControl.Content = new Sign_up_part2(us);
                }

            }
            catch (FormatException)
            {
                MessageBox.Show("Wprowadziles zle dane");
            }
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

        public void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
        }
    }
}
