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
                us.imie = name.ToString();
                if (us.imie.Length <= 0)
                {
                    do
                    {
                        us.imie = name.ToString();

                    } while (us.imie.Length <= 0);
                }
                
                us.nazwisko = surname.ToString();
                if (us.nazwisko.Length <= 0)
                {
                    do
                    {
                        Console.WriteLine("Pole wymagane");
                        us.nazwisko = surname.ToString();
                    } while (us.nazwisko.Length <= 0);
                }

                us.haslo = password.ToString();
                if (us.haslo.Length <= 0)
                {
                    do
                    {
                        Console.WriteLine("Pole wymagane");
                        us.haslo = password.ToString();
                    } while (us.haslo.Length <= 0);
                }

                us.login = login.ToString();
                if (us.login.Length <= 0)
                {
                    do
                    {
                        Console.WriteLine("Pole wymagane");
                        us.login = login.ToString();
                    } while (us.login.Length <= 0);
                }

                //Kalkulator kal = new Kalkulator();
                //kal.mojeBMI(us);
                //kal.zapotrzebowanieKCAL(us);
                //profileList.Add(us);
                //File load = new File();
                //file.zapisywaniePlikuProfile(profileList);
                //zapiszListe();
            }
            catch (FormatException)
            {
                Console.WriteLine("Wprowadziles zle dane");
            }

            this.contentControl.Content = new Sign_up_part2(us);
        }

        private void Sign_up_Click(object sender, RoutedEventArgs e)
        {
            User us = new User();

            try
            {
                Console.Write("Imie: ");
                us.imie = Console.ReadLine();
                if (us.imie.Length <= 0)
                {
                    do
                    {
                        Console.WriteLine("Pole wymagane");
                        Console.Write("Imie: ");
                        us.imie = Console.ReadLine();
        
    } while (us.imie.Length <= 0);
                }

Console.Write("Nazwisko: ");
                us.nazwisko = Console.ReadLine();
                if (us.nazwisko.Length <= 0)
                {
                    do
                    {
                        Console.WriteLine("Pole wymagane");
                        Console.Write("Nazwisko: ");
                        us.nazwisko = Console.ReadLine();
                    } while (us.nazwisko.Length <= 0);
                }

                Console.WriteLine("Płeć: ");
                Console.WriteLine("1- kobieta\n2- mężczyzna");
                us.plec = Console.ReadLine();
                if (us.plec.Length <= 0 || int.Parse(us.plec) <= 0)
                {
                    do
                    {
                        Console.WriteLine("Pole wymagane. Wybierz płeć");
                        Console.WriteLine("Płeć:");
                        Console.WriteLine("1- kobieta\n2- mężczyzna");
                        us.plec = Console.ReadLine();
                    } while (us.plec.Length <= 0 || int.Parse(us.plec) <= 0);
                }
                Console.Write("Hasło: ");
                us.haslo = "";
                ConsoleKeyInfo keyInfo;
                do
                {
                    keyInfo = Console.ReadKey(true);
                    // Skip if Backspace or Enter is Pressed
                    if (keyInfo.Key != ConsoleKey.Backspace && keyInfo.Key != ConsoleKey.Enter)
                    {
                        us.haslo += keyInfo.KeyChar;
                        Console.Write("*");
                    }
                    else
                    {
                        if (keyInfo.Key == ConsoleKey.Backspace && us.haslo.Length > 0)
                        {
                            // Remove last charcter if Backspace is Pressed
                            us.haslo = us.haslo.Substring(0, (us.haslo.Length - 1));
                            Console.Write("\b \b");
                        }
                    }
                }
                // Stops Getting Password Once Enter is Pressed
                while (keyInfo.Key != ConsoleKey.Enter);

                if (us.haslo.Length <= 0)
                {
                    do
                    {
                        Console.WriteLine("\nHaslo nieprawidlowe.");
                        Console.Write("Hasło: ");
                        do
                        {
                            keyInfo = Console.ReadKey(true);
                            if (keyInfo.Key != ConsoleKey.Backspace && keyInfo.Key != ConsoleKey.Enter)
                            {
                                us.haslo += keyInfo.KeyChar;
                                Console.Write("*");
                            }
                            else
                            {
                                if (keyInfo.Key == ConsoleKey.Backspace && us.haslo.Length > 0)
                                {
                                    us.haslo = us.haslo.Substring(0, (us.haslo.Length - 1));
                                    Console.Write("\b \b");
                                }
                            }
                        }
                        while (keyInfo.Key != ConsoleKey.Enter);
                    } while (us.haslo.Length <= 0);
                }
                Console.Write("\nLogin:");
                us.login = Console.ReadLine();
                if (us.login.Length <= 0)
                {
                    do
                    {
                        Console.WriteLine("Pole wymagane");
                        Console.Write("Login: ");
                        us.login = Console.ReadLine();
                    } while (us.login.Length <= 0);
                }

                //Console.Write("Data urodzenia: to trzeba rozkminic");
                Console.Write("Waga (kg):");
                us.waga = Console.ReadLine();
                if (us.waga.Length <= 0 || float.Parse(us.waga) <= 0)
                {
                    do
                    {
                        Console.WriteLine("Pole wymagane. Wprowadź właściwą wagę.");
                        Console.Write("Waga (kg): ");
                        us.waga = Console.ReadLine();
                    } while (us.waga.Length <= 0 || float.Parse(us.waga) <= 0);
                }

                Console.Write("Wzrost (cm):");
                us.wzrost = Console.ReadLine();
                if (us.wzrost.Length <= 0 || float.Parse(us.wzrost) <= 0)
                {
                    do
                    {
                        Console.WriteLine("Pole wymagane. Wprowadź właściwy wzrost.");
                        Console.Write("Wzrost (cm): ");
                        us.wzrost = Console.ReadLine();
                    } while (us.wzrost.Length <= 0 || float.Parse(us.wzrost) <= 0);
                }

                Console.WriteLine("Aktywność fizyczna:");
                Console.WriteLine("1- znikoma\n2- bardzo mala\n3- umiarkowana\n4- duża\n5- bardzo duża");
                us.aktywnosc = Console.ReadLine();
                if (us.aktywnosc.Length <= 0 || int.Parse(us.aktywnosc) <= 0)
                {
                    do
                    {
                        Console.WriteLine("Pole wymagane. Wybierz aktywność");
                        Console.WriteLine("Aktywność fizyczna: ");
                        Console.WriteLine("1- znikoma\n2- bardzo mala\n3- umiarkowana\n4- duża\n5- bardzo duża");
                        us.aktywnosc = Console.ReadLine();
                    } while (us.aktywnosc.Length <= 0 || int.Parse(us.aktywnosc) <= 0);
                }

                Kalkulator kal = new Kalkulator();
kal.mojeBMI(us);
                kal.zapotrzebowanieKCAL(us);
                profileList.Add(us);
                //File load = new File();
                //file.zapisywaniePlikuProfile(profileList);
                zapiszListe();
            }
            catch (FormatException)
            {
                Console.WriteLine("Wprowadziles zle dane");
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
    }
}
