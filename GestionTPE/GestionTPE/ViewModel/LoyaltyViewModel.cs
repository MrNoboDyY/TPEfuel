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
using GestionTPE.Common;
using System.Collections.ObjectModel;
using System.Windows.Threading;

namespace GestionTPE.ViewModel
{
    public class LoyaltyViewModel : ValidationRule
    {
        private LoyaltyModel loyaltymodel;
        //private EventHandler Timer_Tick;

        public LoyaltyViewModel()
        {
            loyaltymodel = new LoyaltyModel();
            loyaltymodel.Codeproduit = string.Empty;
            loyaltymodel.Codebarre = string.Empty;
            //List<Produit> produits = new List<Produit>();
            loyaltymodel.Produits = new ObservableCollection<Produit>();
            //DispatcherTimer timer = new DispatcherTimer();
            //timer.Interval = TimeSpan.FromSeconds(1);
            //timer.Tick += Timer_Tick;
            //timer.Start();

            loyaltymodel.VisibiliteInformations = Visibility.Hidden;
            loyaltymodel.VisibiliteErreur = Visibility.Hidden;
        }

        //private void Timer_Tick(object sender, EventArgs e)
        //{
        //    timer_Tick.Content = DateTime.Now.ToLongTimeString();
        //}

        public LoyaltyModel LoyaltyModel
        {
            get { return loyaltymodel; }
            set { loyaltymodel = value; }
        }

        private bool VerificationsOk(string OSS_Reponse)
        {
            Match match = Regex.Match(OSS_Reponse, "^KO[1-99]{1,2}$");
            return !match.Success;
        }

        #region SoldepPoints Carte

        private bool CanShowSoldePointCarte()
        {
            if (loyaltymodel.NumeroDeCarte == null)
            {
                return false;
            }
            else
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
                    if (reponseCryptee != string.Empty)
                    {
                        loyaltymodel.ReponseDecodee = SecurityManager.Instance.decrypt((int)User.tpetoken, reponseCryptee);

                        if (VerificationsOk(loyaltymodel.ReponseDecodee))
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
                            loyaltymodel.VisibiliteErreur = Visibility.Visible;
                        }
                    }
                }
            }
        }

        #endregion SoldepPoints Carte

        #region Lubrifiants

        public void ShowCodebarrePoint()
        {
            string codeproduitCrypt = string.Empty;
            string codebarreCrypt = string.Empty;
            string codebarreCrypRep = string.Empty;

            if (User.tpetoken.HasValue)
            {
                ///prévoir un foreach pour parcourir les codeproduit + codesbarre de tous les produits de la listView !!!!
                ///du style
                ///Produit produits = new Produit();
                //produits.codeproduit = LoyaltyModel.Codeproduit;
                //produits.codebarre = LoyaltyModel.Codebarre;
                //produits.pointproduit = LoyaltyModel.Pointproduit;
                //produits.statutcode = LoyaltyModel.Statutcode;
                ///loyaltymodel.Produits.Add(produits);
                ///foreach(Produit prod in produits ou listView.Items ou listproduit)
                ///{  codeproduitCrypt = SecurityManager.Instance.encrypt......produits.codeproduit    }
                ///{  codebarreCrypt = SecurityManager.Instance.encrypt.....produits.codebarre  }
                ///ListView.Items
                codeproduitCrypt = SecurityManager.Instance.encrypt((int)User.tpetoken, loyaltymodel.Codeproduit);
                codebarreCrypt = SecurityManager.Instance.encrypt((int)User.tpetoken, loyaltymodel.Codebarre);

                using (var client = new Client_OSS.OnlineServerServiceClient())
                {
                    codebarreCrypRep = client.GetLoyaltyBarCodeStatus(User.codesite, User.numtpe, codeproduitCrypt, codebarreCrypt);

                    loyaltymodel.Pointproduit = SecurityManager.Instance.decrypt((int)User.tpetoken, codebarreCrypRep);

                    if (VerificationsOk(loyaltymodel.Pointproduit))

                    { loyaltymodel.Statutcode = Constantes.Lock; }
                    else
                    { loyaltymodel.Statutcode = Constantes.EchecLock; }
                }
            }
            else
            {
            }
        }

        private void AjouterProduit()
        {
            Produit produits = new Produit();
            produits.codeproduit = LoyaltyModel.Codeproduit;
            produits.codebarre = LoyaltyModel.Codebarre;
            produits.pointproduit = LoyaltyModel.Pointproduit;
            produits.statutcode = LoyaltyModel.Statutcode;

            loyaltymodel.Produits.Add(produits);
        }

        public void BrulerCodeBarre()
        {
            string codebarreCrypt = string.Empty;

            using (var client = new Client_OSS.OnlineServerServiceClient())

                if (User.tpetoken.HasValue && loyaltymodel.Pointproduit != null)
                {
                    codebarreCrypt = SecurityManager.Instance.encrypt((int)User.tpetoken, loyaltymodel.Codebarre);

                    string reponseCryptee = client.BurnLoyaltyBarCodeBarre(User.codesite, User.numtpe, codebarreCrypt);

                    string repDecryptee = SecurityManager.Instance.decrypt((int)User.tpetoken, reponseCryptee);

                    if (VerificationsOk(repDecryptee))
                    {
                        loyaltymodel.Statutcode = Constantes.Burn;
                    }
                    else loyaltymodel.Statutcode = Constantes.EchecBurn;
                }
        }

        public void LibererCodeProduit()
        {
            string codebarCrypt = string.Empty;
            string repCrypt = string.Empty;
            string repDecrypt = string.Empty;

            using (var client = new Client_OSS.OnlineServerServiceClient())
                if (User.tpetoken.HasValue && loyaltymodel.Pointproduit != null)
                {
                    codebarCrypt = SecurityManager.Instance.encrypt((int)User.tpetoken, loyaltymodel.Codebarre);
                    repCrypt = client.FreeLoyaltyBarCode(User.codesite, User.numtpe, codebarCrypt);
                    repDecrypt = SecurityManager.Instance.decrypt((int)User.tpetoken, repCrypt);

                    if (VerificationsOk(repDecrypt))
                    {
                        loyaltymodel.Statutcode = Constantes.Free;
                    }
                    else loyaltymodel.Statutcode = Constantes.EchecFreed;
                }
        }

        #endregion Lubrifiants

        private bool CanReturnAccueil()
        {
            return true;
        }

        private bool CanAddProduit()
        {
            if (loyaltymodel.Codeproduit == null && loyaltymodel.Codebarre == null)
            {
                return true;
            }
            else
                return false;
        }

        private bool CanBrulerCodeBarre()
        {
            if (loyaltymodel.Pointproduit != null)
            {
                return true;
            }
            else
                return false;
        }

        private bool CanFreeCodeBarre()
        {
            if (loyaltymodel.Pointproduit != null)
            {
                return true;
            }
            else
                return false;
        }

        private bool CanShowCodebarrePoint()
        {
            if (loyaltymodel.Codeproduit == null)
            {
                return true;
            }
            else
                return false;
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

        public ICommand AjouterProduitCommand
        {
            get
            {
                return new ViewModelRelay(AjouterProduit, CanAddProduit);
            }
        }

        public ICommand RetourAccueilCommand
        {
            get
            {
                return new ViewModelRelay(RetourAccueil, CanReturnAccueil);
            }
        }

        public ICommand CodebarrePointCommand
        {
            get
            {
                return new ViewModelRelay(ShowCodebarrePoint, CanShowCodebarrePoint);
            }
        }

        public ICommand BrulerCodeProduitCommand
        {
            get
            {
                return new ViewModelRelay(BrulerCodeBarre, CanBrulerCodeBarre);
            }
        }

        public ICommand LibererCodeProduitCommand
        {
            get
            {
                return new ViewModelRelay(LibererCodeProduit, CanFreeCodeBarre);
            }
        }

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            throw new NotImplementedException();
        }
    }
}