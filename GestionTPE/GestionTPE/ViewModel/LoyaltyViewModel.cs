using GestionTPE.Class;
using GestionTPE.Managers;
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
        LoyaltyModel loyaltymodel;


        public LoyaltyViewModel()
        {
            loyaltymodel = new LoyaltyModel();
            loyaltymodel.VisibiliteInformations = Visibility.Hidden;

        }

        public LoyaltyModel LoyaltyModel
        {
            get { return loyaltymodel; }
            set { loyaltymodel = value; }
        }


        bool CanShowSoldePointCarte()
        {
            return true;
        }



        public void ShowSoldePointCarte()
        {
            string donneeCryptee = string.Empty;
 
            string reponseCryptee;
            if (User.tpetoken.HasValue)
            {
                //donneeCryptee = SecurityManager.Instance.encrypt((int)TpeToken, "1404242000044271626");

                donneeCryptee = SecurityManager.Instance.encrypt((int)User.tpetoken, loyaltymodel.NumeroDeCarte.ToString());
                // string test = loyaltymodel.ReponseDecodee;


            }
            //renvoi au webservice qui gere le calcul des points sur la carte ... 
            using (var client = new Client_OSS.OnlineServerServiceClient())
            {
                if (User.tpetoken.HasValue)
                {
                    reponseCryptee = client.GetLoyaltyPoints(User.codesite, User.numtpe, donneeCryptee);
                    if (reponseCryptee != string.Empty)
                    {

                        loyaltymodel.ReponseDecodee = SecurityManager.Instance.decrypt((int)User.tpetoken, reponseCryptee);

                        if (!loyaltymodel.ReponseDecodee.StartsWith("K"))
                        {
                            /*Recuperation de la reponse splité en indices / sans les # */
                            string[] Rep = loyaltymodel.ReponseDecodee.Split(new char[] { '#' }, StringSplitOptions.None);

                            /* les infos de la carte sont visible si pas de KO*/
                            loyaltymodel.VisibiliteInformations = Visibility.Visible;
                            /* affichage des données splitées*/
                            loyaltymodel.PointCarte = Rep[0];
                            loyaltymodel.DateCarte = Rep[1];
                            loyaltymodel.StatutCarte = Rep[2];

                            //foreach (object rep in Rep)
                            //{ 
                            //    //loyaltymodel.PointCarte = Rep.ToString();
                            //    rep.ToString();

                            //}
                        }
                    }
                }

            }

        }

        bool CanReturnAccueil()
        {
            return true;
        }

        public void RetourAccueil()
        {

            WindowsManager windowManager = new WindowsManager();

            windowManager.OpenExisting(Enum.WindowsEnum.LoginView);
            windowManager.Close(Enum.WindowsEnum.LoyaltyView);

        }

        public ICommand SoldePointCommand { get { return new ViewModelRelay(ShowSoldePointCarte); } }

        public ICommand RetourAccueilCommand
        { get { return new ViewModelRelay(RetourAccueil, CanReturnAccueil); } }




    }
}
