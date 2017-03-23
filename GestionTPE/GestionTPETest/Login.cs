using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GestionTPE.ViewModel;
using GestionTPE.Model;

namespace GestionTPETest
{
    [TestClass]
    public class Login
    {
        LoginViewModel loginViewModel;

        [TestInitialize]
        public void Initialize()
        {
            loginViewModel = new LoginViewModel();
        }

        [TestCleanup]
        public void Close()
        {
            System.Threading.Thread.Sleep(1000);
            if (loginViewModel.loginModel.IsConnected)
                loginViewModel.DisconnectCommand();

            Assert.IsTrue(loginViewModel.loginModel.IsDisconnected);
            Assert.IsFalse(loginViewModel.loginModel.IsConnected);
        }

        [TestMethod]
        public void ConnectIsTrue()
        {
            loginViewModel.loginModel = new LoginModel { CodeSite = 2033, NumTpe = 82 };
            loginViewModel.Connection();

            Assert.IsTrue(loginViewModel.loginModel.IsConnected);
        }

    }
}
