using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionTPE
{
    class DataObject
    {
        private string idproduit;
        private string codeproduit;

        //public DataObject dataobject
        //{  
        //    get 
        //    { 
        //    return dataobject; 
        //    }
        //    set 
        //    { 
        //        dataobject = value; 
        //    }
        //}


        public string Idproduit
        {
            get { return idproduit; }
            set { idproduit = value; }
        }

        public string Codeproduit
        {
            get { return codeproduit; }
            set { codeproduit = value; }
        }

        public DataObject(string idproduit, string codeproduit)
        {
            // TODO: Complete member initialization
            this.idproduit = idproduit;
            this.codeproduit = codeproduit;
        }
    }

  


}
