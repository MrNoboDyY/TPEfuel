using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTPE.Model
{
    public class SoldePointCarteModel : NotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        private int numerdecarte;

        public int NumeroDeCarte
        {
            get { return numerdecarte; }

            set { SetField(ref numerdecarte, value); }

        }



    }
}
