using GestionTPE.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GestionTPE.Managers
{
    class WindowsManager
    {
        /// <summary>
        /// Ferme une fenetre existante
        /// </summary>
        /// <param name="window"></param>
        public void Close(WindowsEnum window)
        {
            foreach (Window win in Application.Current.Windows)
            {
                if (window.ToString() == win.Title)
                    win.Close();
            }
        }
        /// <summary>
        /// Ouvre une fenetre existante
        /// </summary>
        /// <param name="window"></param>
        public void OpenExisting(WindowsEnum window)
        {
            foreach (Window win in Application.Current.Windows)
            {
                if (window.ToString() == win.Title)
                    win.Show();
            }
        }
    }
}
