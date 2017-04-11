using GestionTPE.Class;
using GestionTPE.Managers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GestionTPE.Model
{
    public class LoyaltyModel : NotifyPropertyChanged
    {
        /// <summary>
        /// Ce Modele gère Table SoldePoints + Table Lubrifiants
        /// </summary>

        #region Soldepoints

        private long numerodecarte;

        [RegularExpression("^KO[1-99]{1,2}$", ErrorMessage = "ERREUR")]
        private string reponseDecodee;

        private string pointscarte;

        private string datevaliditecarte;

        private string statutcarte;

        private Visibility visibiliteinformations;
        private Visibility visibiliteErreur;

        public long NumeroDeCarte
        {
            get { return numerodecarte; }
            set
            {
                SetField(ref numerodecarte, value);
            }
        }

        public Visibility VisibiliteInformations
        {
            get { return visibiliteinformations; }
            set
            {
                SetField(ref visibiliteinformations, value);
            }
        }

        public string ReponseDecodee
        {
            get { return reponseDecodee; }
            set
            {
                SetField(ref reponseDecodee, value);
            }
        }

        public string PointCarte
        {
            get { return pointscarte; }
            set
            {
                SetField(ref pointscarte, value);
            }
        }

        public string DateCarte
        {
            get { return datevaliditecarte; }
            set
            {
                SetField(ref datevaliditecarte, value);
            }
        }

        public string StatutCarte
        {
            get { return statutcarte; }
            set
            {
                SetField(ref statutcarte, value);
            }
        }

        public Visibility VisibiliteErreur
        {
            get { return visibiliteErreur; }
            set
            {
                SetField(ref visibiliteErreur, value);
            }
        }

        #endregion Soldepoints

        #region Produits

        [RegularExpression("^[1-9]{2}$", ErrorMessage = "Mauvaise saisie du Code Produit")]
        [StringLength(2)]
        private string codeproduit = string.Empty;

        private Timer timer;

        [RegularExpression("^KO[1-99]{1,2}$", ErrorMessage = "Mauvaise saisie de Code Barre")]
        private string codebarre = string.Empty;

        private string infosproduits;

        [RegularExpression("^[1-9]{2}$", ErrorMessage = "ERREUR")]
        private string statutcode;

        private string pointproduit;

        private ObservableCollection<Produit> listproduits;

        //private string validationcode;

        private Visibility visibiliteLocked;
        private Visibility visibiliteBurned;
        private Visibility visibiliteFree;

        public Timer Timenow
        {
            get
            {
                return timer;
            }
            set
            {
                SetField(ref timer, value);
            }
        }

        public Visibility VisibiliteLocked
        {
            get
            {
                return visibiliteLocked;
            }
            set
            {
                SetField(ref visibiliteLocked, value);
            }
        }

        public Visibility VisibiliteBurned
        {
            get
            {
                return visibiliteBurned;
            }
            set
            {
                SetField(ref visibiliteBurned, value);
            }
        }

        public Visibility VisibiliteFree
        {
            get
            {
                return visibiliteFree;
            }
            set
            {
                SetField(ref visibiliteFree, value);
            }
        }

        public string InfosProduit
        {
            get
            {
                return infosproduits;
            }
            set
            {
                SetField(ref infosproduits, value);
            }
        }

        public string Codeproduit
        {
            get
            {
                return codeproduit;
            }
            set
            {
                SetField(ref codeproduit, value);
            }
        }

        public string Codebarre
        {
            get
            {
                return codebarre;
            }
            set
            {
                SetField(ref codebarre, value);
            }
        }

        public string Statutcode
        {
            get
            {
                return statutcode;
            }
            set
            {
                SetField(ref statutcode, value);
            }
        }

        public string Pointproduit
        {
            get
            {
                return pointproduit;
            }
            set
            {
                SetField(ref pointproduit, value);
            }
        }

        public ObservableCollection<Produit> Produits
        {
            get { return listproduits; }
            set { listproduits = value; }
        }

        #endregion Produits
    }
}