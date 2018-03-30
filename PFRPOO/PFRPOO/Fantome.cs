using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProjetS6
{
    public class Fantome : Monstre
    {
        private string atout;   

        public Fantome(int matricule, string nom, string prenom, Typesexe sexe, string function, int cagnotte, Attraction attribution) : base( matricule, nom, prenom, sexe, function,cagnotte, attribution)
        {
            Atout = "invisibilite";
        }

        public string Atout { get => atout; set => atout = value; }

        public override string ToString()
        {
            return "\nFANTOME: "+base.ToString() + "atout :" + Atout+ "\n";
        }
    }
}
