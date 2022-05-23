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
    public static class Globalne            //klasa statyczna zawierająca globalną listę i globalne zmienne
    {
        public static List<string> ListaDanych = new List<string>();
        public static string CBPlec, CBAktywnosc, CBCel;
        //public static List<string> ListaWynikow = new List<string>();
        //public static string[] tab = new string[10];
        //public static int plec;

    }
}
