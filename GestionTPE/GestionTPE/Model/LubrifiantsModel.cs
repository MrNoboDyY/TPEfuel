using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GestionTPE.Model
{
    public class LubrifiantsModel : NotifyPropertyChanged
    {
        private string codeproduit;

        private string idproduit;

        [RegularExpression("^KO[1-9]{1,2}$", ErrorMessage = "ERREUR")]
        private string statutcode;

        private string pointproduit;

        private string validationcode;

        private Visibility visibiliteinformations;
        private Visibility visibiliteErreur;

        
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
                SetField(ref statutcode,value); 
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
                SetField(ref pointproduit,value); 
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
                SetField(ref statutcode,value); 
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
    }
}
