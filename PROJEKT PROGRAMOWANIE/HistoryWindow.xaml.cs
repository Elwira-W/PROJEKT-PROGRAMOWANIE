using System;
using System.IO;
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

namespace PROJEKT_PROGRAMOWANIE
{
    public partial class HistoryWindow : Window
    {
        string login;

        public HistoryWindow(string login)                                                //login został przekazany w konstruktorze (patrz: OtworzOknoHsitorii w MainWindow)
        {
            InitializeComponent();
            this.login = login;
        }

        public void WypiszDane(SelectedDatesCollection selectedDates)                     //metoda wczytująca dane z pliku .txt
        {                                                                                               //selectedDates to data/daty wybrane z kalendarzu
            string sciezkaDane = login + "Dane.txt";

            FileStream plikTekstowy = new FileStream(sciezkaDane, FileMode.Open, FileAccess.Read);
            StreamReader strum2 = new StreamReader(plikTekstowy);
            string danePlik;

            do
            {
                danePlik = strum2.ReadLine();
                foreach (var data in selectedDates)                                                     //"dla każdej daty (data) w selectedDates (...)"
                {

                    if (danePlik != null)
                    {
                        if (danePlik == data.ToLongDateString())                                        //jeśli linijka w pliku (danePlik) zgadza się z wybraną datą w kalendarzu (data) z (selectedDates)
                        {                                                                               //wypisanie danePlik (w tym wypadku data (data)
                            LBHistoria.Items.Add(danePlik);                                             //wypisanie wszystkich wskaźników (do pliku zapisywane są zawsze w tej samej kolejności)
                            LBHistoria.Items.Add("BMI: " + strum2.ReadLine());
                            LBHistoria.Items.Add("WHR: " + strum2.ReadLine());
                            LBHistoria.Items.Add("Zapotrzebowanie kaloryczne: " + strum2.ReadLine());
                            LBHistoria.Items.Add("Waga idealna: " + strum2.ReadLine());
                            LBHistoria.Items.Add("");

                        }
                    }
                }
            } while (danePlik != null);
        }

        private void Powrot_Click(object sender, RoutedEventArgs e)                       //button "powrót"
        {
            this.Close();                                                                 //metoda .Close() zamyka bieżące okno
        }                                                                                 //nie tworzymy instancji klasy MainWindow (okna mainWindow) bo jest ono utworzone i cały czas otwarte


        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)      //zmiana wyboru w kalendarzu
        {
            LBHistoria.Items.Clear();                                                     //wyczyszczenie listboxa

            Calendar calendar = sender as Calendar;                                             
            SelectedDatesCollection selectedDates = calendar.SelectedDates;               //klasa reprezentująca zbiór wybranych dat w kalendarzu  
            WypiszDane(selectedDates);                                                    //wywołanie metody z przekazaniem wybranych dat (selectedDates)
        }
    }
}
