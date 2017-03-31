using GestionTPE.Class;
using GestionTPE.Managers;
using GestionTPE.Model;
using GestionTPE.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace GestionTPE.ViewModel
{
    public class LoyaltyViewModel : ValidationRule
    {
        LoyaltyModel loyaltymodel;
        LubrifiantsModel lubrifiantmodel;

        public LoyaltyViewModel()
        {
            loyaltymodel = new LoyaltyModel();
            loyaltymodel.VisibiliteInformations = Visibility.Hidden;
            loyaltymodel.VisibiliteErreur = Visibility.Hidden;


        }

        public LoyaltyModel LoyaltyModel
        {
            get { return loyaltymodel; }
            set { loyaltymodel = value; }
        }

        //public LubrifiantsModel lubrifiantModel
        //{
        //    get { return lubrifiantmodel; }
        //    set { lubrifiantmodel = value; }
        //}

        #region SoldepPoints Carte
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
                        //str = SecurityManager.Instance.decrypt((int)User.tpetoken, reponseCryptee);
                        loyaltymodel.ReponseDecodee = SecurityManager.Instance.decrypt((int)User.tpetoken, reponseCryptee);

                        //if (!loyaltymodel.ReponseDecodee.StartsWith("K"))
                        string str = loyaltymodel.ReponseDecodee;
                        Match match = Regex.Match(str, "^KO[1-99]{1,2}$");

                        if (!match.Success)
                        {
                            /*Recuperation de la reponse splité en indices / sans les # */
                            string[] Rep = loyaltymodel.ReponseDecodee.Split(new char[] { '#' }, StringSplitOptions.None);

                            /* les infos de la carte sont visible si pas de KO*/
                            loyaltymodel.VisibiliteInformations = Visibility.Visible;
                            loyaltymodel.VisibiliteErreur = Visibility.Hidden;
                            /* affichage des données splitées*/
                            loyaltymodel.PointCarte = Rep[0];
                            loyaltymodel.DateCarte = Rep[1];
                            loyaltymodel.StatutCarte = Rep[2];

                        }
                        else
                        {
                            loyaltymodel.VisibiliteInformations = Visibility.Hidden;
                        }

                        loyaltymodel.VisibiliteErreur = Visibility.Hidden;

                        if (match.Success)
                        {
                            loyaltymodel.VisibiliteErreur = Visibility.Visible;
                        }

                    }
                }

            }

        }

        #endregion

        #region Lubrifiants

        bool CanShowCodebarreStatus()
        {
            return true;
        }


        public void ShowCodebarreStatus()
        {
            string codeproduit = loyaltymodel.Codeproduit;
            string idproduit = loyaltymodel.Idproduit;

            string codebarreCryp = string.Empty;
            string codebarreRepCryp;

            if (User.tpetoken.HasValue)
            {
                DataObject codeEnvoye = new DataObject(codeproduit, idproduit);

                codebarreCryp = SecurityManager.Instance.encrypt((int)User.tpetoken, codeEnvoye.ToString());
            }
            using (var client = new Client_OSS.OnlineServerServiceClient())
            {
                if (User.tpetoken.HasValue)
                {
                    codebarreRepCryp = client.GetLoyaltyBarCodeStatus(User.codesite,User.numtpe,loyaltymodel.Idproduit,loyaltymodel.Codeproduit);
                    string retourdecode = codebarreRepCryp;
                    Match match = Regex.Match(retourdecode, "^KO[1-99]{1,2}$");
                    if (!match.Success)
                    {
                        loyaltymodel.VisibiliteInformations = Visibility.Visible;
                        loyaltymodel.VisibiliteErreur = Visibility.Hidden;
                    }

                }
            }
        }

        #endregion

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





        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            throw new NotImplementedException();
        }
    }
}
