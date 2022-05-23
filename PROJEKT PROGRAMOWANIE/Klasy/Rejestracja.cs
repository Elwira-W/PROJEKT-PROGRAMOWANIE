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
    public class Rejestracja       //klasa zawierająca metodę umożliwiającą stworzenie nowego użytkownika
    {
        public static void NowyUzytkownik(string login, string haslo)   //metoda tworząca nowego użytkownika
        {
            string sciezka = login + ".txt";
            if (!File.Exists(sciezka))
            {
                using (StreamWriter sw = File.CreateText(sciezka))
                {
                    sw.WriteLine(haslo);

                }
            }
        }
    }
}
