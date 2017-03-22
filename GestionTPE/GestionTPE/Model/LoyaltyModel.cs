using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GestionTPE.Model
{
    class LoyaltyModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;/*gestionnaire d'evenements liés au changement de la propriété */
        //LoyaltyModel source = new LoyaltyModel();         
        private bool showWindow;                   
        
           
        private Page pageaafficher;


        public Page PageaAfficher
        {
            get { return pageaafficher; }
            set { pageaafficher = value; RaisePropertyChanged("PageaAfficher"); }
        }


        private void RaisePropertyChanged(string propertyName)/*Fonction qui annonce le changement de la propriété */
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)/*si l'evenement est diff de null*/
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

       //public bool ShowWindow
       // {
       //     get
       //     {
       //         return showWindow; 
       //     }
       //     set 
       //     {
       //         showWindow = value;
       //         RaisePropertyChanged("ShowWindow");
       //     }
       // }



    }
}
