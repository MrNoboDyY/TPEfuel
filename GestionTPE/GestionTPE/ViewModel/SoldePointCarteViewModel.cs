using GestionTPE.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTPE.ViewModel
{
    class SoldePointCarteViewModel 
    {
        SoldePointCarteModel soldepointcartemodel;


        public SoldePointCarteViewModel()
        { 
          soldepointcartemodel = new SoldePointCarteModel();
          soldepointcartemodel.NumeroDeCarte = 0;
        }


        public SoldePointCarteModel SoldePointCarteModel
        {
            get { return soldepointcartemodel;}
            set { soldepointcartemodel = value; }
        }


    }
}
