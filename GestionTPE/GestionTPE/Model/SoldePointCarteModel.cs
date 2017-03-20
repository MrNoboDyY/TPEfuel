using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTPE.Model
{
    class SoldePointCarteModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;/*gestionnaire d'evenements liés au changement*/


        private int numerdecarte;

        public int NumeroDeCarte
        {
            get { return numerdecarte; }
            set
            {
                numerdecarte = value;
                RaisePropertyChanged("NmeroDeCarte");
            }
        }

        #region RaisePropertyChanged
        private void RaisePropertyChanged(string propertyName)/*Fonction qui annonce le changement de la propriété */
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)/*si l'evenement est diff de null*/
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

    }
}
