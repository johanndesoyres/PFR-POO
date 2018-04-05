using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProjetS6
{
    public class Monstre: Personnel
    {
        private Attraction affectation; 

        private int cagnotte;

        public Monstre( int matricule, string nom, string prenom, Typesexe sexe, string function, int cagnotte, Attraction affectation ) : base(function, matricule, nom, prenom, sexe)
        {
            this.Affectation = affectation;
            this.Cagnotte = cagnotte;
        }

        public Attraction Affectation { get => affectation; set => affectation = value; }
        public int Cagnotte { get => cagnotte; set => cagnotte = value; }

        public override string ToString()
        {
            string r = "Pas d'affectation";
            if(Affectation!=null)r = "\nAffectatoin: "+Affectation.Nom;
            return "\nMonstre: "+base.ToString() + r+ "\nCagnotte: "+Cagnotte+"\n";
        }

        public bool affectation_Boutique()
        {
            bool resultat = true;
            if (affectation is Boutique) { resultat = false; }
            return resultat;
        }
        public bool affectation_DarkRide()
        {
            bool resultat = true;
            if (affectation is DarkRide) { resultat = false; }
            return resultat;
        }
        public bool affectation_Rollercoaster()
        {
            bool resultat = true;
            if (affectation is RollerCoaster) { resultat = false; }
            return resultat;
        }
        public bool affectation_Spectacle()
        {
            bool resultat = true;
            if (affectation is Spectacle) { resultat = false; }
            return resultat;
        }
        public void Incrementer(int nb_points)
        {
            cagnotte += nb_points;
        }
        public void Decrementer(int nb_points)
        {
            cagnotte -= nb_points;
        }
    }
}
