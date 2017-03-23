using GestionTPE.Model;
using GestionTPE.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace GestionTPE.ViewModel
{
    public class LoyaltyViewModel
    {
        LoyaltyModel loyaltyModel;



        public LoyaltyViewModel() 
        {
            loyaltyModel = new LoyaltyModel();
               
        }



        public LoyaltyModel LoyaltyModel 
        {
            get { return loyaltyModel; }
            set { loyaltyModel = value; }
        }

        void ShowSoldePointCarteView() 
        {
            new SoldePointCarteView();
           
        }


        bool CanShowSoldePointCarteView() 
        {
            return true;
        }

       


        ICommand SoldePointCarteViewCommand { get { return new ViewModelRelay(ShowSoldePointCarteView, CanShowSoldePointCarteView); } }
     

    }
}
