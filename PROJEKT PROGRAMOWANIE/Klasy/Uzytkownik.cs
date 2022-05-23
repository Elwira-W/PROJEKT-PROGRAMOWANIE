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
    public class Uzytkownik
    {
        public string login;
        public double waga;
        public double wzrost;
        public double obwodTalia;
        public double obwodBiodra;
        public int wiek;
        public int plec;
        public int aktywnosc;
        public int cel;

        public Uzytkownik(string login, double waga, double wzrost, double obwodTalia, double obwodBiodra, int wiek, int plec, int aktywnosc, int cel)
        {
            this.login = login;
            this.waga = waga;
            this.wzrost = wzrost;
            this.obwodTalia = obwodTalia;
            this.obwodBiodra = obwodBiodra;
            this.plec = plec;
            this.wiek = wiek;
            this.aktywnosc = aktywnosc;
            this.cel = cel;
        }
        public int PodajPlec
        {
            get
            {
                return this.plec;
            }
        }
    }
}
