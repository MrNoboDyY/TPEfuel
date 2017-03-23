using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTPE.Model
{
    public class LoginModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;/*gestionnaire d'evenements liés au changement 
                                                                  de la propriété */
        private int numtpe;/*propriéte LoginModel*/
        private int codesite;/*propriéte LoginModel*/

        private bool isConnected;/* si connecté*/
        private bool isDisconnected;/* si deconnecté */

     
        //public bool isValid()
        //{
        //    return true;
        //}

        #region Login Attributs
        public int NumTpe /* Numero TPE à renseigner*/
        {
            get { return numtpe; }
            set
            {
                numtpe = value;
                RaisePropertyChanged("NumTpe");/* si la propriété a changée*/
            }
        }

        public int CodeSite /* Numero Code Site à renseigner*/
        {
            get { return codesite; } 
            set 
            { 
                codesite = value;
                RaisePropertyChanged("CodeSite"); /* si la propriété a changée*/
            } 
        }
        #endregion

        #region IsConnected
        public bool IsConnected { /* vérif si il y a une connection en boolean */
            get 
            { 
                return isConnected; 
            } 
            set 
            { 
                isConnected = value; 
                RaisePropertyChanged("IsConnected"); 
            } 
        }

        #endregion

        #region isDisconnected

        public bool IsDisconnected
        {
            get { 
                return isDisconnected; 
            }
            set { 
            isDisconnected = value;
            RaisePropertyChanged("isDisconnected");
            }
        }

        #endregion

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
