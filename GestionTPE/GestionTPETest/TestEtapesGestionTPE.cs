using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GestionTPE.ViewModel;
using GestionTPE.Model;
using GestionTPE.Managers;
using GestionTPE.View;
using GestionTPE.Class;
using System.Text.RegularExpressions;
using GestionTPE.Common;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace GestionTPE
{
    [TestClass]
    public class TestEtapesGestionTPE
    {
        private LoginViewModel loginViewModel;
        //private LoyaltyModel loyaltymodel;

        public void LoyaltyViewModel()
        {
            loyaltymodel = new LoyaltyModel();
            loyaltymodel.Codeproduit = string.Empty;
            loyaltymodel.Codebarre = string.Empty;
        }

        public LoyaltyModel LoyaltyModel
        {
            get { return loyaltymodel; }
            set { loyaltymodel = value; }
        }

        private ObservableCollection<Produit> produits = new ObservableCollection<Produit>();
        //private List<Produit> produits = new List<Produit>();

        private LoyaltyModel loyaltymodel;

        /// <summary>
        /// test à effectuer en debut de test
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            loginViewModel = new LoginViewModel();
            loginViewModel.loginModel = new LoginModel { CodeSite = 2033, NumTpe = 82 };
            loginViewModel.Connection();

            Assert.IsTrue(loginViewModel.loginModel.IsConnected);
        }

        [TestMethod]
        public void StatutCodeBarre()
        {
            if (User.tpetoken.HasValue)
            {
                string codeproduit = "79";
                string codebarre = "1L03853819";

                string codeproduit1 = "72";
                string codebarre1 = "2L03456117";

                string codeproduit2 = "71";
                string codebarre2 = " 5L03451227";

                string codeproduitCryp = string.Empty;
                string codebarreproduitCrypt = string.Empty;

                string infoprodAcrypterRep;
                //List<Produit> produits = new List<Produit>();

                if (User.tpetoken.HasValue)
                {
                    codeproduitCryp = SecurityManager.Instance.encrypt((int)User.tpetoken, codeproduit.ToString());
                    codebarreproduitCrypt = SecurityManager.Instance.encrypt((int)User.tpetoken, codebarre.ToString());
                }

                var client = new Client_OSS.OnlineServerServiceClient();
                if (User.tpetoken.HasValue)
                {
                    infoprodAcrypterRep = client.GetLoyaltyBarCodeStatus(User.codesite, User.numtpe, codeproduitCryp, codebarreproduitCrypt);
                    string ptsproduit = SecurityManager.Instance.decrypt((int)User.tpetoken, infoprodAcrypterRep);

                    Match match = Regex.Match(
                    infoprodAcrypterRep, "^KO[1-99]{1,2}$");

                    if (!match.Success)
                    {
                        loyaltymodel.Statutcode = Constantes.Lock;
                    }
                    else loyaltymodel.Statutcode = Constantes.EchecLock;
                }
            }
        }

        [TestMethod]
        public void AjouterProduit()
        {
            Produit produits = new Produit();
            produits.codeproduit = LoyaltyModel.Codeproduit;
            produits.codebarre = LoyaltyModel.Codebarre;
            produits.pointproduit = LoyaltyModel.Pointproduit;
            produits.statutcode = LoyaltyModel.Statutcode;

            loyaltymodel.Produits.Add(produits);
        }

        [TestMethod]
        public void BrulerCodeBarre()
        {
            if (User.tpetoken.HasValue)
            {
                string codebarreproduitCrypt = string.Empty;
                var client = new Client_OSS.OnlineServerServiceClient();
                codebarreproduitCrypt = SecurityManager.Instance.encrypt((int)User.tpetoken, loyaltymodel.Codebarre);
                string codebarreproduitcryptRep = client.BurnLoyaltyBarCodeBarre(User.codesite, User.numtpe, codebarreproduitCrypt);
                string codebarreproduitdecryptRep = SecurityManager.Instance.decrypt((int)User.tpetoken, codebarreproduitcryptRep);

                Match match = Regex.Match(codebarreproduitdecryptRep, "^KO[1-99]{1,2}$");
                if (!match.Success)
                {
                    loyaltymodel.Statutcode = Constantes.Burn;
                }
                else loyaltymodel.Statutcode = Constantes.EchecBurn;
            }
        }

        [TestMethod]
        public void LibererCodeProduit()
        {
            if (User.tpetoken.HasValue)
            {
                string codebarreproduitCrypt = string.Empty;
                var client = new Client_OSS.OnlineServerServiceClient();
                codebarreproduitCrypt = SecurityManager.Instance.encrypt((int)User.tpetoken, loyaltymodel.Codebarre);
                string codebarreproduitcryptRep = client.FreeLoyaltyBarCode(User.codesite, User.numtpe, codebarreproduitCrypt);
                string codebarreproduitdecryptRep = SecurityManager.Instance.decrypt((int)User.tpetoken, codebarreproduitcryptRep);

                Match match = Regex.Match(codebarreproduitdecryptRep, "^KO[1-99]{1,2}$");
                if (!match.Success)
                {
                    loyaltymodel.Statutcode = Constantes.Free;
                }
                else loyaltymodel.Statutcode = Constantes.EchecFreed;
            }
        }
    }
}

//    [TestCleanup]
//    public void Close()
//    {
//        System.Threading.Thread.Sleep(1000);
//        if (loginViewModel.loginModel.IsConnected)
//            loginViewModel.Disconnect();

//        Assert.IsTrue(loginViewModel.loginModel.IsDisconnected);
//        Assert.IsFalse(loginViewModel.loginModel.IsConnected);
//    }

//}
//}
//reponseDecodee = SecurityManager.Instance.decrypt()

//reponseDecodee = System.Text.Encoding.ASCII.GetString(pointsurlacarte);
//loginmodel.IsDisconnected = true;
//[TestMethod]
//public void ConnectIsTrue()
//{
//}
//    string codeproduitbrule = string.Empty;
//    codeproduitbrule = client.BurnLoyaltyBarCodeBarre(User.codesite, User.numtpe, codebarreproduitCrypt);
//    var brule = Constantes.Burn.ToString();

//    var cdburned = codeproduitbrule;

//    Match codematch = Regex.Match(
//        codeproduitbrule, "^KO[1-99]{1,2}$");

//    //if (!match.Success)
//    //{
//    //}