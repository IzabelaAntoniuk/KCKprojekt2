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

        private void Sign_up_Click(object sender, RoutedEventArgs e)
        {
            Kalkulator kal = new Kalkulator();
            kal.mojeBMI(us);
            kal.zapotrzebowanieKCAL(us);
            profileList.Add(us);
            //File load = new File();
            //file.zapisywaniePlikuProfile(profileList);
            file.zapisywaniePliku(profileList);
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
