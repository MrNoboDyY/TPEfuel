using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GestionTPE.ViewModel;
using GestionTPE.Model;
using GestionTPE.Managers;
using GestionTPE.View;
using GestionTPE.Class;

namespace GestionTPE
{
    [TestClass]
    public class TestEtapesGestionTPE
    {
        LoginViewModel loginViewModel;

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
        [TestMethod]
        public void EncrypterCarte()
        {

            if (User.tpetoken.HasValue)
            {  
                string reponseDecodee;//= string.Empty;
                string reponseCryptee;
                string donneeCryptee = SecurityManager.Instance.encrypt((int)User.tpetoken.Value, "1404242000044271626");

                

                var client = new Client_OSS.OnlineServerServiceClient();

                if (User.tpetoken.HasValue)
                {
                    reponseCryptee = client.GetLoyaltyPoints(2033, 82, donneeCryptee);
                    if (reponseCryptee != string.Empty)
                    {
                        reponseDecodee = SecurityManager.Instance.decrypt((int)User.tpetoken.Value, reponseCryptee);
                                                                                             
                    }                  
                }                
            }
        }

        [TestMethod]
        public void StatutCodeBarre()
        {
            if (User.tpetoken.HasValue)
            {
                string codeproduit = "94" ;
                string idproduit ="2L03258369" ;

                string codebarreCryp = string.Empty;
                string codebarreRepCryp;
                string codeEnvoye = string.Empty;


            var client = new Client_OSS.OnlineServerServiceClient();
            {
                if (User.tpetoken.HasValue)

                codebarreCryp = SecurityManager.Instance.encrypt((int)User.tpetoken, codeEnvoye.ToString());
                codebarreRepCryp = client.GetLoyaltyBarCodeStatus(User.codesite, User.numtpe, "2L03258369", "94");
            }
          //  using (var client = new Client_OSS.OnlineServerServiceClient())
           // {
        //        if (User.tpetoken.HasValue)
        //        {
        //            codebarreRepCryp = client.GetLoyaltyBarCodeStatus(User.codesite, User.numtpe, loyaltymodel.Idproduit, loyaltymodel.Codeproduit);
        //            string retourdecode = codebarreRepCryp;
        //            Match match = Regex.Match(retourdecode, "^KO[1-99]{1,2}$");
        //            if (!match.Success)
        //            {
        //                loyaltymodel.VisibiliteInformations = Visibility.Visible;
        //                loyaltymodel.VisibiliteErreur = Visibility.Hidden;
        //            }

                }
            }
        
        }


        //[TestCleanup]
        //public void Close()
        //{
        //    System.Threading.Thread.Sleep(1000);
        //    if (loginViewModel.loginModel.IsConnected)
        //        loginViewModel.Disconnect();

        //    Assert.IsTrue(loginViewModel.loginModel.IsDisconnected);
        //    Assert.IsFalse(loginViewModel.loginModel.IsConnected);
        //}

    }
//}
//reponseDecodee = SecurityManager.Instance.decrypt()

//reponseDecodee = System.Text.Encoding.ASCII.GetString(pointsurlacarte);
//loginmodel.IsDisconnected = true;
//[TestMethod]
//public void ConnectIsTrue()
//{

//}