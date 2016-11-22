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

namespace ProjektKCK
{
    /// <summary>
    /// Interaction logic for UserControl2.xaml
    /// </summary>
    public partial class Sign_up_part2 : UserControl
    {
        User us = new User();
        File file = new File();
        List<User> profileList = new List<User>();

        public Sign_up_part2(User use)
        {
            InitializeComponent();
            us = use;
        }
        public void zapiszListe()
        {
            file.zapisywaniePlikuProfile(profileList);
        }

        private void Sign_up_Click(object sender, RoutedEventArgs e)
        {


            us.waga = weight.Text;
            us.wzrost = height.Text;
            us.plec = gender.Text;
            us.aktywnosc = active.Text;
            us.kg = kg.Text;

            if (us.waga.Length <= 0 || float.Parse(us.waga) <= 0)
            {
                MessageBox.Show("Wprowadz wage.");
            }

            else if (us.wzrost.Length <= 0 || float.Parse(us.wzrost) <= 0)
            {
                MessageBox.Show("Wprowadz wzrost.");
            }

            else if (us.plec.Length <= 0)
            {
                MessageBox.Show("Wprowadz plec.");
            }

            else if (us.aktywnosc.Length <= 0)
            {
                MessageBox.Show("Wprowadz aktywnosc.");
            }
            else if (us.kg.Length <= 0)
            {
                MessageBox.Show("Wprowadz kg.");
            }
            else
            {
                MessageBox.Show("Utworzono nowy profil");
                Kalkulator kal = new Kalkulator();
                kal.mojeBMI(us);
                kal.zapotrzebowanieKCAL(us);
                profileList.Add(us);
                file.zapisywaniePlikuProfile(profileList);

                MainWindow mainW = new MainWindow();
                mainW.Show();
                var myWindow = Window.GetWindow(this);
                myWindow.Close();
            }

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainW = new MainWindow();
            mainW.Show();
            var myWindow = Window.GetWindow(this);
            myWindow.Close();
        }
    }
}
