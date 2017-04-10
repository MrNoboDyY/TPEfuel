using GestionTPE.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTPE.Class
{
    public class Produit : NotifyPropertyChanged
    {
        public string codeproduit { get; set; }
        public string codebarre { get; set; }
        public string pointproduit { get; set; }
        public string statutcode { get; set; }
    }
}