using GestionTPE.Managers;
using GestionTPE.Model;
using GestionTPE.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GestionTPE.ViewModel
{
    public class SoldePointCarteViewModel
    {
      public  int? TpeToken;
        //SecurityManager securitymanager;



        SoldePointCarteModel soldepointcartemodel;
        SoldePointCarteViewModel soldepointcarteviewmodel;

        public SoldePointCarteModel SoldePointCarteModel
        {
            get { return soldepointcartemodel; }
            set { soldepointcartemodel = value; }
        }


        public SoldePointCarteViewModel()
        {
            soldepointcartemodel = new SoldePointCarteModel();
            soldepointcartemodel.NumeroDeCarte = 0;
        }



        bool CanShowSoldePointCarte()
       {
            return soldepointcartemodel.NumeroDeCarte != 0;
        }



        public void ShowSoldePointCarte()
        {
            
            string numerodecarte = "";
            string donneeCryptee = string.Empty;
            string reponseDecodee = string.Empty;
            string reponseCryptee;
            //if (TpeToken.HasValue && soldepointcarteviewmodel.soldepointcartemodel.NumeroDeCarte != 0)
            if (TpeToken.HasValue)
            {
                donneeCryptee = SecurityManager.Instance.encrypt((int)TpeToken, /*numerodecarte*/"1404242000044271626");
            }
            //renvoi au webservice qui gere le calcul des points sur la carte ... 
            using (var client = new Client_OSS.OnlineServerServiceClient())
            {
                if (TpeToken.HasValue)
                {
                    reponseCryptee = client.GetLoyaltyPoints(2033, 82, donneeCryptee);
                    if (reponseCryptee != string.Empty)
                    {
                        reponseDecodee = SecurityManager.Instance.decrypt((int)TpeToken, reponseCryptee);
                    }

                    //loginmodel.IsDisconnected = true;
                }
            }
        }


        public void RetourAccueil()
        {
            
        }


                bool CanReturnAccueil()
        {
            return true;
        }

        public ICommand SoldePointCommand { get { return new ViewModelRelay(ShowSoldePointCarte, CanShowSoldePointCarte); } }

        public ICommand RetourAccueilCommand { get { return new ViewModelRelay(RetourAccueil, CanReturnAccueil); } }
        //public ICommand DeconnexionCommand { get { return new ViewModelRelay( Deconnexion, CanDisconnect)}}
    }
}
