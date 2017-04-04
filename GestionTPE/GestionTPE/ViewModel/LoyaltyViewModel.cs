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
using System.Windows.Data;

namespace GestionTPE.ViewModel
{
    public class LoyaltyViewModel : ValidationRule
    {
        private LoyaltyModel loyaltymodel;
        private string codeproduitCrypt = string.Empty;
        //private Client_OSS.OnlineServerServiceClient client = new Client_OSS.OnlineServerServiceClient();

        public LoyaltyViewModel()
        {
            loyaltymodel = new LoyaltyModel();
            loyaltymodel.Codeproduit = string.Empty;
            loyaltymodel.Codebarre = string.Empty;
            loyaltymodel.VisibiliteInformations = Visibility.Hidden;
            loyaltymodel.VisibiliteErreur = Visibility.Hidden;
            loyaltymodel.VisibiliteLocked = Visibility.Hidden;
            loyaltymodel.VisibiliteBurned = Visibility.Hidden;
            loyaltymodel.VisibiliteFree = Visibility.Hidden;
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

        private bool CanShowSoldePointCarte()
        {
            return true;
        }

        public void ShowSoldePointCarte()
        {
            string donneeCryptee = string.Empty;
            string reponseCryptee;

            if (User.tpetoken.HasValue)
            {
                donneeCryptee = SecurityManager.Instance.encrypt((int)User.tpetoken, loyaltymodel.NumeroDeCarte.ToString());
            }
            //renvoi au webservice qui gere le calcul des points sur la carte ...
            using (var client = new Client_OSS.OnlineServerServiceClient())
            {
                if (User.tpetoken.HasValue)
                {
                    reponseCryptee = client.GetLoyaltyPoints(User.codesite, User.numtpe, donneeCryptee);
                    if
                        (
                        reponseCryptee != string.Empty
                        )
                    {
                        //str = SecurityManager.Instance.decrypt((int)User.tpetoken, reponseCryptee);
                        loyaltymodel.ReponseDecodee = SecurityManager.Instance.decrypt((int)User.tpetoken, reponseCryptee);

                        //if (!loyaltymodel.ReponseDecodee.StartsWith("K"))
                        string str = loyaltymodel.ReponseDecodee;
                        Match match = Regex.Match(str, "^KO[1-99]{1,2}$");

                        if
                            (
                            !match.Success
                            )
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

        #endregion SoldepPoints Carte

        #region Lubrifiants

        private bool CanShowCodebarreStatus()
        {
            return true;
        }

        public void BrulerCodeBarre()
        {
            using (var client = new Client_OSS.OnlineServerServiceClient())
                if (User.tpetoken.HasValue)
                {
                    loyaltymodel.Validationcode = client.BurnLoyaltyBarCodeBarre(User.codesite, User.numtpe, codeproduitCrypt);
                    loyaltymodel.VisibiliteBurned = Visibility.Visible;
                    loyaltymodel.VisibiliteFree = Visibility.Hidden;
                    loyaltymodel.VisibiliteLocked = Visibility.Hidden;
                }
        }

        public void ShowCodebarreStatus()
        {
            string codeproduit = loyaltymodel.Codeproduit;
            string codebarre = loyaltymodel.Codebarre;
            string codebarreCrypt = string.Empty;
            string codebarreCrypRep = string.Empty;

            if (User.tpetoken.HasValue)
            {
                codeproduitCrypt = SecurityManager.Instance.encrypt((int)User.tpetoken, codeproduit.ToString());
                codebarreCrypt = SecurityManager.Instance.encrypt((int)User.tpetoken, codebarre.ToString());
            }
            using (var client = new Client_OSS.OnlineServerServiceClient())
            {
                if
                    (
                    User.tpetoken.HasValue
                    )
                {
                    codebarreCrypRep = client.GetLoyaltyBarCodeStatus(User.codesite, User.numtpe, codeproduitCrypt, codebarreCrypt);

                    loyaltymodel.Pointproduit = SecurityManager.Instance.decrypt((int)User.tpetoken, codebarreCrypRep);

                    string pprod = loyaltymodel.Pointproduit;

                    Match match = Regex.Match(
                        pprod, "^KO[1-99]{1,2}$");
                    if
                        (!match.Success)
                    {
                        loyaltymodel.VisibiliteLocked = Visibility.Visible;
                        loyaltymodel.VisibiliteBurned = Visibility.Hidden;
                        loyaltymodel.VisibiliteFree = Visibility.Hidden;

                        //loyaltymodel.VisibiliteInformations = Visibility.Visible;
                        //loyaltymodel.VisibiliteErreur = Visibility.Hidden;
                    }
                }
            }
        }

        #endregion Lubrifiants

        private bool CanReturnAccueil()
        {
            return true;
        }

        public void RetourAccueil()
        {
            WindowsManager windowManager = new WindowsManager();

            windowManager.OpenExisting(Enum.WindowsEnum.LoginView);
            windowManager.Close(Enum.WindowsEnum.LoyaltyView);
        }

        public ICommand SoldePointCommand
        {
            get
            {
                return new ViewModelRelay(ShowSoldePointCarte);
            }
        }

        public ICommand RetourAccueilCommand
        {
            get
            {
                return new ViewModelRelay(RetourAccueil, CanReturnAccueil);
            }
        }

        public ICommand CodebarreStatusCommand
        {
            get
            {
                return new ViewModelRelay(ShowCodebarreStatus);
            }
        }

        public ICommand BrulerCodeProduitCommand
        {
            get
            {
                return new ViewModelRelay(BrulerCodeBarre);
            }
        }

        //public ICommand LibererCodeProduitCommand(LibererCodeProduit);

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            throw new NotImplementedException();
        }
    }
}