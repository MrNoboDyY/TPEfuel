using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GestionTPE.Model
{
    public class LoyaltyModel : NotifyPropertyChanged
    {
        private long numerodecarte;
        private string reponseDecodee;
        private string pointscarte;
        private string datevaliditecarte;
        private string statutcarte;
        private string erreur;
        private Visibility visibiliteinformations;

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

        public string Erreur
        {
            get { return erreur; }
            set
            {
                SetField(ref erreur, value);
            }
        }

    }
}
