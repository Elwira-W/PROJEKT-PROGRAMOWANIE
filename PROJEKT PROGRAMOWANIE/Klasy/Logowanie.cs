using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PROJEKT_PROGRAMOWANIE
{
    public class Logowanie          //klasa zawierająca metody umożliwiające zalogowanie się
    {
        public static bool SprawdzUzytkownika(string login)         //metoda sprawdzająca, czy podany użytkownik istnieje
        {
            if (login == "") return false;

            string sciezka = login + ".txt";
            if (File.Exists(sciezka))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool SprawdzHaslo(string login, string haslo)
        {
            string sciezka = login + ".txt";

            using (StreamReader sr = File.OpenText(sciezka))
            {
                string hasloPlik = sr.ReadLine();
                if (hasloPlik == haslo)
                {
                    {
                        return true;
                    }
                }
                else
                {

                    return false;
                }

            }
        }       //metoda sprawdzająca poprawność hasła dla danego loginu
    }
}
