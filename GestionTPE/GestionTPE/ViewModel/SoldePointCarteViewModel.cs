using GestionTPE.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GestionTPE.ViewModel
{
    public class SoldePointCarteViewModel 
    {
        SoldePointCarteModel soldepointcartemodel;


        public SoldePointCarteModel SoldePointCarteModel
        {
            get { return soldepointcartemodel;}
            set { soldepointcartemodel = value; }
        }


        public SoldePointCarteViewModel()
        { 
          soldepointcartemodel = new SoldePointCarteModel();
          soldepointcartemodel.NumeroDeCarte = 0;          
        }

        bool CanShowSoldePointCarte() 
        {
            return soldepointcartemodel.NumeroDeCarte != 0;
        }

        void ShowSoldePointCarte() 
        {
         //renvoi au webservice qui gere le calcul des points sur la carte ... 
        }
           

        public ICommand SoldePointCommand { get { return new ViewModelRelay(ShowSoldePointCarte, CanShowSoldePointCarte); } }

       // public ICommand RetourAccueilCommand { get { return new ViewModelRelay ( RetourAccueil, CanReturn )} }
        //public ICommand DeconnexionCommand { get { return new ViewModelRelay( Deconnexion, CanDisconnect)}}
    }
}
