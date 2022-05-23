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
    public class UzytkownikWskazniki
    {
        private string login;
        private double BMI;
        private double WHR;
        private double zKcal;
        private double wagaIdealna;

        public UzytkownikWskazniki(string login, double BMI, double WHR, double zKcal, double wagaIdealna)
        {
            this.login = login;
            this.BMI = BMI;
            this.WHR = WHR;
            this.zKcal = zKcal;
            this.wagaIdealna = wagaIdealna;
        }
        public string PodajLogin
        {
            get
            {
                return this.login;
            }
        }
        public double PodajBMI
        {
            get
            {
                return this.BMI;
            }
        }
        public double PodajWHR
        {
            get
            {
                return this.WHR;
            }
        }
        public double PodajzKcal
        {
            get
            {
                return this.zKcal;
            }
        }
        public double PodajwagaIdealna
        {
            get
            {
                return this.wagaIdealna;
            }
        }
    }
}
