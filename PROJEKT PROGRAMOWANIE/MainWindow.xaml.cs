using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace PROJEKT_PROGRAMOWANIE
{
    public partial class MainWindow : Window
    {
        string login;

        public MainWindow(string login)                                 //login przekazany został z okna loginWindow w konstruktorze (patrz: OtworzOknoGlowne w LoginWindow)
        {
            InitializeComponent();

            this.login = login;
            TBUzytkownik.Text = login;
            TBWaga.Focus();

            ObservableCollection<string> listPlec = new ObservableCollection<string>();
            listPlec.Add("Kobieta");
            listPlec.Add("Mężczyzna");
            CBPlec.ItemsSource = listPlec;

            ObservableCollection<string> listAktywnosc = new ObservableCollection<string>();
            listAktywnosc.Add("Mała");
            listAktywnosc.Add("Średnia");
            listAktywnosc.Add("Duża");
            CBAktywnosc.ItemsSource = listAktywnosc;

            ObservableCollection<string> listCel = new ObservableCollection<string>();
            listCel.Add("Odchudzanie");
            listCel.Add("Utrzymanie wagi");
            listCel.Add("Nabranie wagi");
            CBCel.ItemsSource = listCel;

            TBInfoAktywnosc.Text = "MAŁA: praca siedząca, brak ruchu\n" +
                "ŚREDNIA: praca w ruchu, aktywność fizyczna 1-2 razy w tygodniu\n" +
                "WYSOKA: praca wymagająca dużo ruchu, aktywnosć fizyczna 3+ razy w tygodniu";


        }
        void Wyczysc()                                                                              //metoda zawierająca instrukcje pozwalajace na wyczyszczenie pól
        {
            TBWaga.Clear();
            TBWzrost.Clear();
            TBObwodTalia.Clear();
            TBObwodBiodra.Clear();
            TBWiek.Clear();
            LBWyniki.Items.Clear();
            CBPlec.SelectedIndex = -1;
            CBAktywnosc.SelectedIndex = -1;
            CBCel.SelectedIndex = -1;
        }
        void OtworzOknoHistorii()
        {
            HistoryWindow historyWindow = new HistoryWindow(login);                                 //tworzenie instancji klasy HistoryWindow o nazwie "historyWindow" z przekazaniem loginu
            historyWindow.ShowDialog();                                                                   //metoda .Show() otwiera obiekt "historyWindow" czyli otwiera nowe okno
            //this.Close();                                                                         //bieżące okno nie jest zamykane, żeby nie utracić właśnie wpisanych danych
        }
        private void ZapiszDane_Click(object sender, RoutedEventArgs e)                             //button "zapisz dane do pliku .txt"
        {
            #region "Inicjalizacja zmiennych i wyliczenie wyników"

            string login1 = login;
            double waga = Convert.ToDouble(TBWaga.Text);
            double wzrost = Convert.ToDouble(TBWzrost.Text);
            double obwodTalia = Convert.ToDouble(TBObwodTalia.Text);
            double obwodBiodra = Convert.ToDouble(TBObwodBiodra.Text);
            int wiek = Convert.ToInt32(TBWiek.Text);
            int plec = Convert.ToInt32(Globalne.CBPlec);
            int aktywnosc = Convert.ToInt32(Globalne.CBAktywnosc);
            int cel = Convert.ToInt32(Globalne.CBCel);

            DateTime data = new DateTime();
            data.ToLongDateString();

            double BMI = Kalkulator.BMI(waga, wzrost);
            double WHR = Kalkulator.WHR(obwodTalia, obwodBiodra, plec);
            double zKcal = Kalkulator.ZapotrzebowanieKaloryczne(waga, wzrost, wiek, plec, aktywnosc, cel);
            double wagaIdealna = Kalkulator.WagaIdealna(waga, wzrost, plec);
            #endregion
            UzytkownikWskazniki uW = new UzytkownikWskazniki(login1, BMI, WHR, zKcal, wagaIdealna);
            Uzytkownik uA = new Uzytkownik(login1, waga, wzrost, obwodTalia, obwodBiodra, wiek, plec, aktywnosc, cel);

            Dane Dane = new Dane(uW, uA);
            Dane.ZapiszDoPliku();
            
        }

        private void Policz_Click(object sender, RoutedEventArgs e)                                 //button "policz"
        {
            #region "Sprawdzenie poprawnosci danych, inicjalizacja zmiennych i wyliczenie wyników"

            bool spr = true;
            do
            {
                try
                {
                    Convert.ToDouble(TBWaga.Text);
                    Convert.ToDouble(TBWzrost.Text);
                    Convert.ToDouble(TBObwodTalia.Text);
                    Convert.ToDouble(TBObwodBiodra.Text);
                    Convert.ToInt32(TBWiek.Text);

                    if (CBPlec.SelectedIndex == -1 | CBAktywnosc.SelectedIndex == -1 | CBCel.SelectedIndex == -1)
                    {
                        //throw new CustomException("Pola wyboru nie mogą być puste!");
                        MessageBox.Show("Pola wyboru nie mogą być puste!");
                        spr = false;
                        break;
                    }
                    if ((Convert.ToDouble(TBWaga.Text) < 0) || (Convert.ToDouble(TBWzrost.Text) < 0) ||
                        (Convert.ToDouble(TBObwodTalia.Text) < 0) ||
                        (Convert.ToDouble(TBObwodBiodra.Text) < 0) ||
                        (Convert.ToInt32(TBWiek.Text) < 0))
                    {
                        MessageBox.Show("Wartości nie mogą być ujemne!");
                        spr = false;
                        break;
                    }

                    if (Convert.ToDouble(TBWaga.Text) > 250)
                    {
                        MessageBox.Show("Nieprawidłowa waga!");
                        spr = false;
                        break;
                    }
                    if (Convert.ToDouble(TBWzrost.Text) < 50 || Convert.ToDouble(TBWzrost.Text) > 250)
                    {
                        MessageBox.Show("Niepoprawny wzrost!");
                        spr = false;
                        break;
                    }
                    if (Convert.ToDouble(TBObwodTalia.Text) < 0 || Convert.ToDouble(TBObwodTalia.Text) > 150)
                    {
                        MessageBox.Show("Niepoprawny obwód talii!");
                        spr = false;
                        break;
                    }
                    if (Convert.ToDouble(TBObwodBiodra.Text) < 0 || Convert.ToDouble(TBObwodBiodra.Text) > 150)
                    {
                        MessageBox.Show("Niepoprawny obwód bioder!");
                        spr = false;
                        break;
                    }
                    if (Convert.ToInt32(TBWiek.Text) < 0 || Convert.ToInt32(TBWiek.Text) > 110)
                    {
                        MessageBox.Show("Niepoprawny wiek!");
                        spr = false;
                        break;
                    }
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Nieprawidłowe dane!");
                    spr = false;
                    break;
                }
                catch (Exception ex1)
                {
                    MessageBox.Show("Błąd");
                    spr = false;
                    break;
                }
            } while (!spr);

            if (spr)
            {
                string login1 = login;
                double waga = Convert.ToDouble(TBWaga.Text);
                double wzrost = Convert.ToDouble(TBWzrost.Text);
                double obwodTalia = Convert.ToDouble(TBObwodTalia.Text);
                double obwodBiodra = Convert.ToDouble(TBObwodBiodra.Text);
                int wiek = Convert.ToInt32(TBWiek.Text);
                int plec = Convert.ToInt32(Globalne.CBPlec);
                int aktywnosc = Convert.ToInt32(Globalne.CBAktywnosc);
                int cel = Convert.ToInt32(Globalne.CBCel);

                double BMI = Kalkulator.BMI(waga, wzrost);
                double WHR = Kalkulator.WHR(obwodTalia, obwodBiodra, plec);
                double zKcal = Kalkulator.ZapotrzebowanieKaloryczne(waga, wzrost, wiek, plec, aktywnosc, cel);
                double wagaIdealna = Kalkulator.WagaIdealna(waga, wzrost, plec);
                #endregion

                Uzytkownik uz1 = new Uzytkownik(login1, waga, wzrost, obwodTalia, obwodBiodra, wiek, plec, aktywnosc, cel);         //tworzenie instancji klasy Uzytkownik o nazwie "uz1"
                UzytkownikWskazniki uW = new UzytkownikWskazniki(login1, BMI, WHR, zKcal, wagaIdealna);                             //tworzenie instancji klasy UzytkownikWskazniki o nazwie "uW"
                Dane Da = new Dane(uW, uz1);                                                                                        //tworzenie instancji klasy Dane o nazwie "Da"
                new Dane(uW, uz1).WypiszDane(this.LBWyniki);                                                                        //z przekazaniem obiektu klasy Uzytkownik - "uz1"    
            }                                                                                                                       //oraz obiektu klasy UzytkownikWskazniki - "uW" w konstruktorze klasy Dane
        }

        private void WyczyscDane_Click(object sender, RoutedEventArgs e)                            //wywołanie metody Wyczysc()
        {
            Wyczysc();
        }
        private void Historia_Click(object sender, RoutedEventArgs e)                               //button "historia"
        {
            OtworzOknoHistorii();                                                                   //wywołanie metody OtworzOknoHistorii
        }

        private void Wyloguj_Click(object sender, RoutedEventArgs e)                                //button "wyloguj" (powrót do okna logowania)
        {
            LoginWindow loginWindow = new LoginWindow();                                            //stworzenie instancji klasy LoginWindow o nazwie "loginWindow"
            loginWindow.Show();                                                                     //metoda .Show() otwiera obiekt "loginWindow" czyli otwiera nowe okno
            this.Close();                                                                           //metoda .Close() zamyka bieżące okno
        }

        private void CBPlec_SelectionChanged(object sender, SelectionChangedEventArgs e)            //combobox plec
        {
            Globalne.CBPlec = CBPlec.SelectedIndex.ToString();                                      //przypisanie do globalnej zmiennej indeksu wybranego elementu z combobox
        }

        private void CBAktywnosc_SelectionChanged(object sender, SelectionChangedEventArgs e)       //combobox aktywnosc
        {
            Globalne.CBAktywnosc = CBAktywnosc.SelectedIndex.ToString();                            //przypisanie do globalnej zmiennej indeksu wybranego elementu z combobox
        }

        private void CBCel_SelectionChanged(object sender, SelectionChangedEventArgs e)             //combobox cel
        {
            Globalne.CBCel = CBCel.SelectedIndex.ToString();                                        //przypisanie do globalnej zmiennej indeksu wybranego elementu z combobox
        }

        private void WyczyscWyniki_Click(object sender, RoutedEventArgs e)
        {
            LBWyniki.Items.Clear();
        }
    }
    
    }