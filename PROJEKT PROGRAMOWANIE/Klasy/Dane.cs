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
    public class Dane                                                               //klasa zawierająca metody umożliwiające wypisanie wyników w listbox i zapisanie danych do pliku
    {
        private UzytkownikWskazniki w;
        private Uzytkownik A;

        public Dane(UzytkownikWskazniki uW, Uzytkownik uA)                          //przekazanie obiektów klas UzytkownikWskazniki i Uzytkownik
        {
            w = uW;
            A = uA;
        }
        public void WypiszDane(ListBox LBWyniki)                                    //metoda umożliwiająca wypisanie danych do listbox "LBWyniki"
        {
            DateTime data = new DateTime();                                         
            data = DateTime.UtcNow;
            data.ToLongDateString();

            LBWyniki.Items.Add(data.ToLongDateString());
            LBWyniki.Items.Add("BMI: " + w.PodajBMI.ToString());
            # region "Sprawdzenie w jakim zakresie znajduje sie BMI"
            if (w.PodajBMI < 18.49)
            {
                LBWyniki.Items.Add("BMI wskazuje na NIEDOWAGĘ");
            }
            else if (w.PodajBMI >= 25)
            {
                LBWyniki.Items.Add("BMI wskazuje na NADWAGĘ");
            }
            else
            {
                LBWyniki.Items.Add("Waga prawidłowa");
            }
            #endregion 
            LBWyniki.Items.Add("WHR: " + w.PodajWHR.ToString());
            #region "Sprawdzenie typu sylwetki na podstawie WHR i Plci"
            if (A.PodajPlec == 0)
            {
                if (w.PodajWHR < 0.8)
                {
                    LBWyniki.Items.Add("Sylwetka typu: Gruszka");
                }
                else
                {
                    LBWyniki.Items.Add("Sylwetka typu: Jabłko");
                }
            }
            else
            {
                if (w.PodajWHR < 1)
                {
                    LBWyniki.Items.Add("Sylwetka typu: Gruszka");
                }
                else
                {
                    LBWyniki.Items.Add("Sylwetka typu: Jabłko");
                }
            }
            #endregion
            LBWyniki.Items.Add("Zapotrzebowanie kaloryczne: " + w.PodajzKcal.ToString());
            LBWyniki.Items.Add("Waga idealna: " + w.PodajwagaIdealna.ToString());
        }
        public void ZapiszDoPliku()                                                 //metoda umożliwiająca zapisanie danych do pliku
        {
            string sciezkaDane = w.PodajLogin + "Dane.txt";
            if (!File.Exists(sciezkaDane))
            {
                using (StreamWriter sw = File.CreateText(sciezkaDane))
                {
                    DateTime data = new DateTime();
                    data = DateTime.UtcNow;
                    sw.WriteLine(data.ToLongDateString());
                    sw.WriteLine(w.PodajBMI);
                    sw.WriteLine(w.PodajWHR);
                    sw.WriteLine(w.PodajzKcal);
                    sw.WriteLine(w.PodajwagaIdealna);
                    MessageBox.Show("Pomyślnie zapisano do pliku");
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(sciezkaDane))
                {
                    DateTime data = new DateTime();
                    data = DateTime.UtcNow;
                    sw.WriteLine(data.ToLongDateString());
                    sw.WriteLine(w.PodajBMI);
                    sw.WriteLine(w.PodajWHR);
                    sw.WriteLine(w.PodajzKcal);
                    sw.WriteLine(w.PodajwagaIdealna);
                    MessageBox.Show("Pomyślnie zapisano do pliku");
                }
            }
        }
    }
}
