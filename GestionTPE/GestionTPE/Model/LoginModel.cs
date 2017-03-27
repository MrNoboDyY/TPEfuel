using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTPE.Model
{
    public class LoginModel : NotifyPropertyChanged
    {
        //public event PropertyChangedEventHandler PropertyChanged;/*gestionnaire d'evenements liés au changement 
        //                                                          de la propriété */
        private int numtpe;/*propriéte LoginModel*/
        private int codesite;/*propriéte LoginModel*/

        private bool isConnected;/* si connecté*/
        private bool isDisconnected;/* si deconnecté */

        private string webserviceAddress;

        //public bool isValid()
        //{
        //    return true;
        //}
        public string WebServiceAddress
        {
            get { return webserviceAddress; }
            set { SetField(ref webserviceAddress, value); }
        }

        public int NumTpe /* Numero TPE à renseigner*/
        {
            get { return numtpe; }
            set { SetField(ref numtpe, value); }
        }

        public int CodeSite /* Numero Code Site à renseigner*/
        {
            get { return codesite; }
            set { SetField(ref codesite, value); }
        }

        public bool IsConnected
        { /* vérif si il y a une connection en boolean */
            get { return isConnected; }
            set { SetField(ref isConnected, value); }
        }

        public bool IsDisconnected
        {
            get { return isDisconnected; }
            set { SetField(ref isDisconnected, value); }
        }

    }
}
