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
       
        private int numtpe;
        private int codesite;
        private bool isConnected;
        private bool isDisconnected;
        private string webserviceAddress;
        private int? tpetoken;



        public int? TpeToken 
        {
            get
            {
                return tpetoken;
            }
            set { SetField(ref tpetoken, value); }
        }

      
        public string WebServiceAddress
        {
            get { return webserviceAddress; }
            set { SetField(ref webserviceAddress, value); }
        }

        public int NumTpe 
        {
            get { return numtpe; }
            set { SetField(ref numtpe, value); }
        }

        public int CodeSite 
        {
            get { return codesite; }
            set { SetField(ref codesite, value); }
        }

        public bool IsConnected
        { 
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
