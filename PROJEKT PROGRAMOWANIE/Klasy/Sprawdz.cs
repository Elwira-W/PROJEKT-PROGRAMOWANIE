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
    public class Sprawdz        //klasa zawierająca metody umożliwiające sprawdzenie poprawności danych wpisanych przez użytkownika
    {
        public static bool SprawdzPoprawnoscLoginu(string login)
        {
            int number;
            bool success = int.TryParse(login, out number);
            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");

            if (login == "")
            {
                MessageBox.Show("Pole login nie może być puste!");
                return false;
            }
            else if (success)
            {
                MessageBox.Show("Login nie może składać się z samych cyfr!");
                return false;
            }
            else if (!regexItem.IsMatch(login))
            {
                MessageBox.Show("Login nie może zawierać znaków specjalnych!");
                return false;
            }
            else if (login.Length < 4 || login.Length > 10)
            {
                MessageBox.Show("Login musi się składać z minimum 4 i maksimum 10 liter!");
                return false;
            }
            else
            {
                return true;
            }
        }   //metoda sprawdzająca poprawność loginu
        public static bool SprawdzPoprawnoscHasla(string haslo)
        {
            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");
            if (haslo == "")
            {
                MessageBox.Show("Hasło powinno składać się z conajmniej 5 znaków!");
                return false;

            }
            else if (!regexItem.IsMatch(haslo))
            {
                MessageBox.Show("Hasło nie może zawierać znaków specjalnych!");
                return false;
            }
            else if (haslo.Length < 5)
            {
                MessageBox.Show("Pole hasło nie może być puste!");
                return false;
            }
            else
            {
                return true;
            }
        }   //metoda sprawdzająca poprawność hasła
    }
}
