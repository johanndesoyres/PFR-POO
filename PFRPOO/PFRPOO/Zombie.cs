using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProjetS6
{
    public class Zombie : Monstre
    {
        

        private int degreDecomposition;
        private CouleurZ teint;

      

        public Zombie(int matricule, string nom, string prenom, Typesexe sexe, string function, int cagnotte, Attraction attribution, CouleurZ teint,int degreDecomposition) : base( matricule, nom, prenom, sexe, function,cagnotte, attribution)
        {
            this.DegreDecomposition = degreDecomposition;
            this.Teint = teint;
        }

        public int DegreDecomposition { get => degreDecomposition; set => degreDecomposition = value; }
        public CouleurZ Teint { get => teint; set => teint = value; }

        public override string ToString()
        {
            return "\nZOMBIE: "+base.ToString() + "CouleurZ:" + Teint + "\nDegre de decomposition: "+DegreDecomposition+"\n";
        }
    }
}
