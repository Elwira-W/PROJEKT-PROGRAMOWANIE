using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEKT_PROGRAMOWANIE
{
    public class Kalkulator
    {
        public static double BMI(double waga, double wzrost)
        {
            wzrost *= 0.01;
            double BMI = Math.Round(waga / Math.Pow(wzrost, 2), 5);
            return BMI;
        }
        public static double WHR(double obwodTalia, double obwodBiodra, int plec)
        {
            double WHR = Math.Round(obwodTalia / obwodBiodra, 2);
            return WHR;
        }
        public static double ZapotrzebowanieKaloryczne(double waga, double wzrost, int wiek, int plec, double aktywnosc, int cel)
        {
            double PPA, zKcal = 0;

            if (aktywnosc == 0)
            {
                aktywnosc = 1.2;
            }
            else if (aktywnosc == 1)
            {
                aktywnosc = 1.4;
            }
            else if (aktywnosc == 2)
            {
                aktywnosc = 1.8;
            }

            if (plec == 0)
            {
                PPA = 665 + (9.6 * waga) + (1.85 * wzrost) - (4.7 * wiek);
                zKcal = PPA * aktywnosc;
            }
            else
            {
                PPA = 66.5 + (13.7 * waga) + (1.85 * wzrost) - (4.7 * wiek);
                zKcal = PPA * aktywnosc;
            }

            if (cel == 1)
            {
                return zKcal;
            }
            else if (cel == 0)
            {
                zKcal = zKcal - (0.15 * zKcal);
            }
            else if (cel == 2)
            {
                zKcal = zKcal + (0.15 * zKcal);
            }

            return zKcal;
        }

        public static double WagaIdealna(double waga, double wzrost, int plec)
        {
            double wagaIdealna;

            if (plec == 0)
            {
                wagaIdealna = wzrost - 100 - ((wzrost - 100) / 10);
            }
            else
            {
                wagaIdealna = wzrost - 100 - ((wzrost - 100) / 20);
            }
            return wagaIdealna;
        }
    }
}
