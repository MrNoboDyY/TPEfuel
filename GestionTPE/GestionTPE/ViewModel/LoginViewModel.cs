﻿using GestionTPE.Enum;
using GestionTPE.Managers;
using GestionTPE.Model;
using GestionTPE.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GestionTPE.ViewModel
{
    public class LoginViewModel
    {
        public int? TpeToken { get; set; }

        LoginModel loginmodel;/* objet loginmodel*/

        private bool isConnected;

        /* A l'ouverture de l'application constructeur de l'objet vide*/
        public LoginViewModel()
        {
           

            loginmodel = new LoginModel();//instanciation de l'objet loginmodel
            loginmodel.CodeSite = 0;/* champ vide*/
            loginmodel.NumTpe = 0;/* champ vide*/
            loginmodel.IsConnected = false;/*connection à 0,car pas de connection*/
             //System.Configuration.ConfigurationManager.AppSettings["URL"].ToString();

             loginmodel.WebServiceAddress = new AppConfigManager().GetEndPoint();
            
            
        }



        public LoginViewModel(System.Windows.FrameworkElement view)
        {
            this.view = view;
        }

        System.Windows.FrameworkElement view;

        /* recuperation de l'objet loginmodel*/
        public LoginModel loginModel
        {
            get { return loginmodel; }
            set { loginmodel = value; }
        }

        /// <summary>
        /// recuperation de l'adress du webservice
        /// </summary>
        public AppConfigManager webserviceAdress
        {
            get { return webserviceAdress; }
            set { webserviceAdress = value; }
    
         }

        

        bool CanShowLoyaltyView()
        {
            return loginmodel.IsConnected;
        }

        bool CanShowTomcardView()
        {
            return loginmodel.IsConnected;
        }

        //void ShowTomcardView()
        //{
        //    new TomcardView().Show();
            
        //    //new WindowControl().CloseWindow(WindowsEnum.LoginView);
        //}

        /*monter la vue LoyaltyView et fermer la fenetre LoginView*/
        void ShowLoyaltyView()
        {
            /* afficher loyaltyView*/
            new SoldePointCarteView(TpeToken).Show();
            Application.Current.MainWindow.Hide();
            Application.Current.MainWindow.Show();
            

            /*fermer la fenetre LoginView*/
            //new WindowControl().CloseWindow(WindowsEnum.LoginView);
        }

        /*verifier que les deux champs sont bien rempli pour la connexion*/
        bool CanConnect()
        {
            if (loginmodel.IsConnected)
                return false;
            /*si CodeSite de l'objet loginmodel Empty*/
            if ((loginmodel.CodeSite == 0)
                ||
                /*si NumTpe de l'objet loginmodel Empty*/
                (loginmodel.NumTpe == 0))
            {
                loginmodel.IsConnected = false;
                return false;
            }/*le bouton connect est grisé*/
            return true;
        }

        bool CanDisconnect()
        {
            return loginmodel.IsConnected;
        }

        /* se conneter avec l'objet loginmodel*/
        public void Connection()
        {
            //consomation du webservice/ creation d'un objet "client" Webservice

            var client = new Client_OSS.OnlineServerServiceClient();

            TpeToken = (int)client.InitConn(loginmodel.CodeSite, loginmodel.NumTpe);
            loginModel.IsConnected = TpeToken.HasValue;
            

            //if (!TpeToken.HasValue)
            //{
            //    // Gerer l'exception
            //    loginmodel.IsConnected = false;
            //}

        }



        public void Disconnect()
        {

            var client = new Client_OSS.OnlineServerServiceClient();

            if (TpeToken.HasValue)
            {
                client.Disconnect(loginmodel.CodeSite, loginmodel.NumTpe);
                loginmodel.IsDisconnected = true;
                loginModel.IsConnected = false;
                
            }
        }

        /// <summary>
        /// envoi depuis le relay de la Deconnexion
        /// </summary>
        public ICommand DisconnectCommand { get { return new ViewModelRelay(Disconnect, CanDisconnect); } }


        /// <summary>
        /// envoi depuis le relay de la partie Loyalty/loyaltyview
        /// </summary>
        public ICommand LoyaltyViewCommand { get { return new ViewModelRelay(ShowLoyaltyView); } }


        /// <summary>
        /// envoi depuis le relay de la connexion
        /// </summary>
        public ICommand ConnectionCommand { get { return new ViewModelRelay(Connection, CanConnect); } }


        /// <summary>
        /// envoi depuis le relay de la partie Tomcard / Tomcardview
        /// </summary>
        public ICommand TomcardViewCommand { get { return new ViewModelRelay(Connection, CanShowTomcardView); } }

    }
}
