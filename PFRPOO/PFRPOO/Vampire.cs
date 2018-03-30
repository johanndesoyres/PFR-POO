using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProjetS6
{
    public class Vampire : Monstre
    {
        private float indiceLuminosite;

        public Vampire(int matricule, string nom, string prenom, Typesexe sexe, string function, int cagnotte, Attraction attribution, float indiceLuminosite) : base( matricule, nom, prenom, sexe, function,cagnotte, attribution)
        {
            this.IndiceLuminosite = indiceLuminosite;
        }

        public float IndiceLuminosite { get => indiceLuminosite; set => indiceLuminosite = value; }

        public override string ToString()
        {
            return "\nVAMPIRE: "+base.ToString() + "Indice de luminosité :" + IndiceLuminosite +"\n";
        }
    }
}
