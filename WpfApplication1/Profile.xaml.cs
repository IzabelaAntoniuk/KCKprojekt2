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
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        User us = new User();
        int calosc = 0;
        int postep = 0;
        int dz = DateTime.Now.Day;
        int m = DateTime.Now.Month;
        int r = DateTime.Now.Year;

        File file = new File();
        List<User> profileList = new List<User>();

        public void zapiszListe()
        {
            file.zapisywaniePlikuProfile(profileList);
        }

        public Profile(User use)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            profileList = use.profileList;
            this.us = use;
            nickname.Content = us.imie + " " + us.nazwisko;
            name.Content = us.imie;
            surname.Content = us.nazwisko;
            age.Content = us.wiek;
            weight.Content = us.waga;
            height.Content = us.wzrost;
            active.Content = us.aktywnosc;
            pbStatus.Maximum = use.newCPM;
            calosc = (int)us.newCPM;

            bmi.Content = us.BMI;
            cpm.Content = us.CPM;

            foreach (Food prod in us.productList)
            {
                if (int.Parse(prod.year) == r && int.Parse(prod.month) == m && int.Parse(prod.day) == dz)
                {
                    postep = postep + int.Parse(prod.foodKcal);
                    if (postep >= calosc)
                        postep = calosc;
                }
            }

            foreach (Workout akt in us.workoutList)
            {
                if (int.Parse(akt.yearW) == r && int.Parse(akt.monthW) == m && int.Parse(akt.dayW) == dz)
                {
                    postep = postep - int.Parse(akt.kcalWorkout);
                    if (postep < 0)
                        postep = 0;
                }
            }
            pbStatus.Value = postep;

            List<Food> items = new List<Food>();
            foreach(Food f in us.productList)
            {
                items.Add(f);
            }
            lbTodoList.ItemsSource = items;

            List<Workout> items2 = new List<Workout>();
            foreach (Workout w in us.workoutList)
            {
                items2.Add(w);
            }
            lbTodoList2.ItemsSource = items2;
        }

        private void myGif_MediaEnded(object sender, RoutedEventArgs e)
        {
            myGif.Position = new TimeSpan(0, 0, 1);
            myGif.Play();
        }

        private void Sign_out_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainW = new MainWindow();
            mainW.Show();
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
        }

        private void Add_food_Click(object sender, RoutedEventArgs e)
        {
            Food prod = new Food();

            prod.foodName = productName.Text;
            prod.foodWeight = productWeight.Text;
            prod.foodKcal = productKcal.Text;
            prod.day = day.Text;
            prod.month = month.Text;
            prod.year = year.Text;
            prod.foodDate = prod.year + "-" + prod.month + "-" + prod.day;

            foreach (User use in profileList)
            {
                if (use.login == us.login && use.haslo == us.haslo)
                {
                    use.productList.Add(prod);
                }
            }

            us.zapiszListe();
            wyswietlPasek();

            List<Food> items = new List<Food>();
            foreach (Food f in us.productList)
            {
                items.Add(f);
            }
            lbTodoList.ItemsSource = items;

            MessageBox.Show("Dodałeś " + prod.foodName + " do swojego dziennika.");
        }

        private void Add_training_Click(object sender, RoutedEventArgs e)
        {
            Workout work = new Workout();

            work.nameWorkout = trainingName.Text;
            work.timeWorkout = trainingWeight.Text;
            work.kcalWorkout = trainingKcal.Text;
            work.dayW = dayW.Text;
            work.monthW = monthW.Text;
            work.yearW = yearW.Text;
            work.dateWorkout = work.yearW + "-" + work.monthW + "-" + work.dayW;

            foreach (User use in us.profileList)
            {
                if (use.login == us.login && use.haslo == us.haslo)
                {
                    use.workoutList.Add(work);
                }
            }

            us.zapiszListe();
            wyswietlPasek();

            List<Workout> items2 = new List<Workout>();
            foreach (Workout w in us.workoutList)
            {
                items2.Add(w);
            }
            lbTodoList2.ItemsSource = items2;

            MessageBox.Show("Dodałeś " + work.nameWorkout + " do swojego dziennika.");
        }

        public void wyswietlPasek()
        {
            postep = 0;

            foreach (Food prod in us.productList)
            {
                if (int.Parse(prod.year) == r && int.Parse(prod.month) == m && int.Parse(prod.day) == dz)
                {
                    postep = postep + int.Parse(prod.foodKcal);
                    if (postep >= calosc)
                        postep = calosc;
                }
            }

            foreach (Workout akt in us.workoutList)
            {
                if (int.Parse(akt.yearW) == r && int.Parse(akt.monthW) == m && int.Parse(akt.dayW) == dz)
                {
                    postep = postep - int.Parse(akt.kcalWorkout);
                    if (postep < 0)
                        postep = 0;
                }
            }
            
            pbStatus.Value = postep;
        }

        private void Update_weight_Click(object sender, RoutedEventArgs e)
        {
            string wag = us.waga;

            foreach (User use in profileList)
            {
                if (use.login == us.login && use.haslo == us.haslo)
                {
                    use.waga = newWeight.Text;
                }
            }
            file.zapisywaniePlikuProfile(profileList);
            MessageBox.Show("Zaktualizowałeś wagę z " + wag + "kg na " + newWeight.Text + "kg.");
        }

        private void Update_logpas_Click(object sender, RoutedEventArgs e)
        {
            string l = us.login;
            string p = us.haslo;

            foreach (User use in profileList)
            {
                if (use.login == us.login && use.haslo == us.haslo)
                {
                    if (log.Text.Length > 0)
                        use.login = log.Text;
                    else log.Text = use.login;

                    if (pas.Text.Length > 0)
                        use.haslo = pas.Text;
                    else pas.Text = use.haslo;
                }
            }
            file.zapisywaniePlikuProfile(profileList);
            MessageBox.Show("Zaktualizowałeś dane");
        }
        
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            foreach (User use in profileList)
            {
                if (use.login == us.login && use.haslo == us.haslo)
                {
                    if (i.Text.Length > 0)
                        use.imie = i.Text;
                    else i.Text = use.imie;

                    if (n.Text.Length > 0)
                        use.nazwisko = n.Text;
                    else n.Text = use.nazwisko;

                    if (dd.Text.Length > 0)
                    {
                        if (dd.Text != "dd")
                        {
                            use.dzień = int.Parse(dd.Text);
                        }
                    } else dd.Text = use.dzień.ToString();

                    if (mm.Text.Length > 0)
                    {
                        if (mm.Text != "mm")
                        {
                            use.miesiac = int.Parse(mm.Text);
                        }
                    } else mm.Text = use.miesiac.ToString();

                    if (yyyy.Text.Length > 0)
                    {
                        if (yyyy.Text != "yyyy")
                        {
                            use.rok = int.Parse(yyyy.Text);
                        }
                    } else yyyy.Text = use.rok.ToString();

                    if (a.Text.Length > 0)
                        use.aktywnosc = a.Text;
                    else a.Text = use.aktywnosc;

                    use.dataUr = use.rok + "-" + use.miesiac + "-" + use.dzień;

                    DateTime now = DateTime.Today;
                    use.wiek = now.Year - use.rok;

                    if (w.Text.Length > 0)
                        use.wzrost = w.Text;
                    else w.Text = use.wzrost;

                    if (kg.Text.Length > 0)
                        use.kg = kg.Text;
                    else kg.Text = use.kg;
                }
            }
            file.zapisywaniePlikuProfile(profileList);
            MessageBox.Show("Zaktualizowałeś dane");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
