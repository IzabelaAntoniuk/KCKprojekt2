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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       // static List<User> glownyProfile = new List<User>();
        //Kalkulator kal = new Kalkulator();
        User us = new User();

        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            us.uzupelnijListe();
        }

        private void Sign_in_Click(object sender, RoutedEventArgs e)
        {
            Sign_in sign_in = new Sign_in(us);
            sign_in.Show();
            this.Close(); 
        }

        private void Sign_up_Click(object sender, RoutedEventArgs e)
        {
            Sign_up sign_up = new Sign_up(us);
            sign_up.Show();
            this.Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void myGif_MediaEnded(object sender, RoutedEventArgs e)
        {
            myGif.Position = new TimeSpan(0, 0, 1);
            myGif.Play();
        }
    }
}
