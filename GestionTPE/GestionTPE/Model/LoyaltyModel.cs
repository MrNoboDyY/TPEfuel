using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
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

        [RegularExpression("^KO[1-9]{1,2}$", ErrorMessage = "ERREUR")]
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
        #endregion

        #region Lubrifiants
        
            private string codeproduit;

            private string idproduit;
            private string infosproduits;
            
            [RegularExpression("^KO[1-9]{1,2}$", ErrorMessage = "ERREUR")]
            private string statutcode;

            private string pointproduit;

            private string validationcode;


            public string InfosProduit 
            { 
                get 
                { 
                    return infosproduits;
                }
                set 
                { 
                    SetField(ref infosproduits,value); 
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


            public string Idproduit
            {
                get
                {
                    return idproduit;
                }
                set
                {
                    SetField(ref idproduit, value);
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


            public string Validationcode
            {
                get
                {
                    return validationcode;
                }
                set
                {
                    SetField(ref validationcode, value);
                }
            }

           
        #endregion
        }
    }

