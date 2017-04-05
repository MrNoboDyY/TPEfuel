using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GestionTPE.ViewModel;
using GestionTPE.Model;
using GestionTPE.Managers;
using GestionTPE.View;
using GestionTPE.Class;
using System.Text.RegularExpressions;
using GestionTPE.Common;

namespace GestionTPE
{
    [TestClass]
    public class TestEtapesGestionTPE
    {
        private LoginViewModel loginViewModel;

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

        /// <summary>
        /// encrypter le numero de carte avec le securityManager
        /// </summary>
        //[TestMethod]
        //public void EncrypterCarte()
        //{
        //    if (User.tpetoken.HasValue)
        //    {
        //        string reponseDecodee;//= string.Empty;
        //        string reponseCryptee;
        //        string donneeCryptee = SecurityManager.Instance.encrypt((int)User.tpetoken.Value, "1404242000044271626");

        //        var client = new Client_OSS.OnlineServerServiceClient();

        //        if (User.tpetoken.HasValue)
        //        {
        //            reponseCryptee = client.GetLoyaltyPoints(2033, 82, donneeCryptee);
        //            if (reponseCryptee != string.Empty)
        //            {
        //                reponseDecodee = SecurityManager.Instance.decrypt((int)User.tpetoken.Value, reponseCryptee);

        //            }
        //        }
        //    }
        //}

        [TestMethod]
        public void StatutCodeBarre()
        {
            if (User.tpetoken.HasValue)
            {
                string codeproduit = "69";
                string codebarreproduit = "1L03853839";

                string codeproduitCryp = string.Empty;
                string codebarreproduitCrypt = string.Empty;

                string infoprodAcrypterRep;

                if (User.tpetoken.HasValue)
                {
                    codeproduitCryp = SecurityManager.Instance.encrypt((int)User.tpetoken, codeproduit.ToString());
                    codebarreproduitCrypt = SecurityManager.Instance.encrypt((int)User.tpetoken, codebarreproduit.ToString());
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
                        string codeproduitbrule = string.Empty;
                        codeproduitbrule = client.BurnLoyaltyBarCodeBarre(User.codesite, User.numtpe, codebarreproduitCrypt);
                        var brule = Constantes.Burn.ToString();

                        var cdburned = codeproduitbrule;

                        Match codematch = Regex.Match(
                            codeproduitbrule, "^KO[1-99]{1,2}$");

                        //if (!match.Success)
                        //{
                        //}
                    }
                }
            }
        }

        //[TestMethod]
        //public void BrulerCodeProduit()
        //{
        //    if (User.tpetoken.HasValue)
        //    {
        //        //string codeproduitCrypt;
        //        string codeproduitbrule = string.Empty;

        //        var client = new Client_OSS.OnlineServerServiceClient();

        //        //codeproduitbrule = client.BurnLoyaltyBarCodeBarre(User.codesite, User.numtpe, codeproduitCrypt);
        //    }
        //}
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