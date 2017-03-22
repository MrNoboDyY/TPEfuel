using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GestionTPE.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        /* creation de l'objet webservice*/
        localhost.InitConnCompletedEventHandler con = new localhost.InitConnCompletedEventHandler();
        
        public LoginView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //utilisation du webService initConn 
            //l'utilisateur entre codesite + numtpe
            int codesite,numtpe,Token;
         
                
        }

        
    }
}
