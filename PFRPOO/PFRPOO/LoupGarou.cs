using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProjetS6
{
    public class LoupGarou : Monstre      
    {
        private float indiceCruaute;

        public LoupGarou(int matricule, string nom, string prenom, Typesexe sexe, string function, int cagnotte, Attraction attribution, float indiceCruaute) : base( matricule, nom, prenom, sexe, function,cagnotte, attribution)
        {
            this.IndiceCruaute = indiceCruaute;
        }

        public float IndiceCruaute { get => indiceCruaute; set => indiceCruaute = value; }

        public override string ToString()
        {
            return "\nLOUP GAROU: "+base.ToString() + "Indice de cruauté :" + IndiceCruaute + "\n";
        }

    }
}
