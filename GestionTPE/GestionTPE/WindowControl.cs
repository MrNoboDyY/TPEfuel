using GestionTPE.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GestionTPE
{
    /* gestionnaire de l'affichage des fenetres*/
    class WindowControl
    {
        /* fermer une fenetre de la liste WindowEnum*/
        public void CloseWindow(WindowsEnum windowsToClose)
        {
            /*pouur chaque fenetre win da l'application*/
            foreach (Window win in Application.Current.Windows)
            {
                /*fermer la fenetre dont le nom est indiqué dans l'appel*/
                if (win.Title == windowsToClose.ToString())
                    win.Close();
            }
        }
    }
}
