using GestionTPE.Enum;
using GestionTPE.Model;
using GestionTPE.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GestionTPE.ViewModel
{
    class LoginViewModel
    {

        LoginModel loginmodel;/* objet loginmodel*/


        /* A l'ouverture de l'application constructeur de l'objet vide*/
        public LoginViewModel()
        {
            loginmodel = new LoginModel();/*instanciation de l'objet loginmodel*/
            loginmodel.CodeSite = string.Empty;/* champ vide*/
            loginmodel.NumTpe = string.Empty;/* champ vide*/
            loginmodel.IsConnected = false;/*connection à 0,car pas de connection*/
        }


        /* recuperation de l'objet loginmodel*/
        public LoginModel loginModel
        {
            get { return loginmodel; }
            set { loginmodel = value; }
        }



        bool CanShowLoyaltyView()
        {
            return loginmodel.IsConnected;
        }


        bool CanShowTomcardView() 
        {
            return loginmodel.IsConnected;
        }


       void  ShowTomcardView()
        {
            new TomcardView().Show();
           
            new WindowControl().CloseWindow(WindowsEnum.LoginView);
        }

        /*monter la vue LoyaltyView et fermer la fenetre LoginView*/
        void ShowLoyaltyView()
        {
            /* afficher loyaltyView*/
            new LoyaltyView().Show();

            /*fermer la fenetre LoginView*/
            new WindowControl().CloseWindow(WindowsEnum.LoginView);
        }



        
        /*verifier que les deux champs sont bien rempli pour la connexion*/
        bool CanConnect()
        {
            //if (!loginmodel.isValid())
            //{
             
            //}
            /*si CodeSite de lo'objet loginmodel Empty*/
            if (String.IsNullOrEmpty(loginmodel.CodeSite) 
                ||
                /*si NumTpe de l'objet loginmodel Empty*/
                String.IsNullOrEmpty(loginmodel.NumTpe))
            { loginmodel.IsConnected = false; return false; }/*le bouton connect est grisé*/
            return true;
        }


        /* se conneter avec l'objet loginmodel*/
        void Connection()
        {
            loginmodel.IsConnected = true;/* passer la connexion à vraie avec loginmodel validé*/
        }

        /* envoi depuis le relay de la partie Loyalty/loyaltyview */
        public ICommand LoyaltyViewCommand { get { return new ViewModelRelay(ShowLoyaltyView, CanShowLoyaltyView); } }
               
        /* envoi depuis le relay de la connexion*/
        public ICommand ConnectionCommand { get { return new ViewModelRelay(Connection, CanConnect); } }

        /* envoi depuis le relay de la partie Tomcard / Tomcardview*/
        public ICommand TomcardViewCommand { get { return new ViewModelRelay(Connection, CanShowTomcardView); } }


    }
}
