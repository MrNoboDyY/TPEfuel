using GestionTPE.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTPE.Class
{
    public class Produit : NotifyPropertyChanged
    {
        public static string codeproduit;
        public static string codebarre;
        public static string pointproduit;
        public static string statutcode;

        private ObservableCollection<Produit> produits = new ObservableCollection<Produit>();
    }
}