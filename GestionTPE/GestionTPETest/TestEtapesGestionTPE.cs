using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GestionTPE.ViewModel;
using GestionTPE.Model;
using GestionTPE.Managers;
using GestionTPE.View;

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

            if (loginViewModel.TpeToken.HasValue)
            {  
                string reponseDecodee;//= string.Empty;
                string reponseCryptee;
                string donneeCryptee = SecurityManager.Instance.encrypt((int)loginViewModel.TpeToken.Value, "1404242000044271626");

                

                var client = new Client_OSS.OnlineServerServiceClient();
            
                if (loginViewModel.TpeToken.HasValue)
                {
                    reponseCryptee = client.GetLoyaltyPoints(2033, 82, donneeCryptee);
                    if (reponseCryptee != string.Empty)
                    {
                       reponseDecodee  = SecurityManager.Instance.decrypt((int)loginViewModel.TpeToken.Value, reponseCryptee);
                                                                                             
                    }                  
                }                
            }
        }

        /// <summary>
        /// renvoyer a l'accueil
        /// </summary>
        [TestMethod]
        public void RetourAccueil()
        {
            var client = new Client_OSS.OnlineServerServiceClient();

            if (loginViewModel.TpeToken.HasValue)
            {
            
            }
        }


        [TestCleanup]
        public void Close()
        {
            System.Threading.Thread.Sleep(1000);
            if (loginViewModel.loginModel.IsConnected)
                loginViewModel.Disconnect();

            Assert.IsTrue(loginViewModel.loginModel.IsDisconnected);
            Assert.IsFalse(loginViewModel.loginModel.IsConnected);
        }

    }
}
//reponseDecodee = SecurityManager.Instance.decrypt()

//reponseDecodee = System.Text.Encoding.ASCII.GetString(pointsurlacarte);
//loginmodel.IsDisconnected = true;
//[TestMethod]
//public void ConnectIsTrue()
//{

//}