using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionTPE;
using GestionTPE.ViewModel;
using GestionTPE.Model;

namespace GestionTPEConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var loginViewModel = new LoginViewModel();
            loginViewModel.loginModel = new LoginModel { CodeSite = 2033, NumTpe = 82 };
            loginViewModel.Connection();            
            
            Console.WriteLine("Connecté : {0}", loginViewModel.loginModel.IsConnected);
            System.Threading.Thread.Sleep(1000);
            if (loginViewModel.loginModel.IsConnected)
                loginViewModel.Diconnect();

            Console.WriteLine("Déconnecté : {0}", loginViewModel.loginModel.IsDisconnected);


        }
    }
}
