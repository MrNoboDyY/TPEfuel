﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GestionTPE.Model
{
    public class LoyaltyModel : NotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        //LoyaltyModel source = new LoyaltyModel();         
        //private bool showWindow;                   
        
           
        private Page pageaafficher;


        public Page PageaAfficher
        {
            get { return pageaafficher; }
            set { SetField(ref pageaafficher, value);}
        }


        //private void RaisePropertyChanged(string propertyName)/*Fonction qui annonce le changement de la propriété */
        //{
        //    PropertyChangedEventHandler handler = PropertyChanged;
        //    if (handler != null)/*si l'evenement est diff de null*/
        //    {
        //        handler(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}

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
