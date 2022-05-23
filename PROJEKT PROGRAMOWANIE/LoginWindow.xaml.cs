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
    public partial class LoginWindow : Window
    {

        void Wyczysc()              //metoda czyszcząca pola login i haslo
        {
            TBLogin.Clear();
            TBHaslo.Clear();
        }

        void OtworzOknoGlowne()     //metoda zawierająca instrukcje umożliwiające otwarcie okna glownego
        {
            MainWindow mainWindow = new MainWindow(TBLogin.Text);       //tworzenie instancji klasy MainWindow "mainWindow" i przekazanie w konstruktorze loginu (TBLogin.Text)
            mainWindow.Show();                                          //metoda .Show() otwiera obiekt "OknoGlowne"
            this.Close();                                               //metoda .Close() zamyka  bieżące okno
        }   

        public LoginWindow()
        {
            InitializeComponent();
            TBLogin.Focus();        //ustawienie kursora na textbox login
        }

        private void BT_Logowanie_Click(object sender, RoutedEventArgs e)
        {
            if (Sprawdz.SprawdzPoprawnoscLoginu(TBLogin.Text))
            {
                if (Sprawdz.SprawdzPoprawnoscHasla(TBHaslo.Text))
                {
                    if (!Logowanie.SprawdzUzytkownika(TBLogin.Text))
                    {
                        if (Logowanie.SprawdzHaslo(TBLogin.Text, TBHaslo.Text))
                        {
                            MessageBox.Show("Zalogowano pomyślnie");

                            OtworzOknoGlowne();
                        }
                        else
                        {
                            MessageBox.Show("Podane hasło/login jest nieprawidłowe, albo użytkownik nie istnieje.");
                            Wyczysc();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Podany użytkownik nie istnieje.");
                    }
                }
            }
            Wyczysc();
        }

        private void BT_Rejestracja_Click(object sender, RoutedEventArgs e)
        {
            if (Sprawdz.SprawdzPoprawnoscLoginu(TBLogin.Text))
            {
                if (Logowanie.SprawdzUzytkownika(TBLogin.Text))
                {
                    if (Sprawdz.SprawdzPoprawnoscHasla(TBHaslo.Text))
                    {
                        Rejestracja.NowyUzytkownik(TBLogin.Text, TBHaslo.Text);
                        MessageBox.Show("Zarejestrowano pomyślnie. Zaloguj się");
                        Wyczysc();
                    }
                }
                else if (TBHaslo.Text == "")
                {
                    MessageBox.Show("Pole hasło nie może być puste!");
                } else
                {
                    MessageBox.Show("Użytkownik już istnieje. Proszę wybrać inny login");
                    Wyczysc();
                }
            }
            Wyczysc();
        }
    }
}
