using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProjetS6
{
    public class Demon : Monstre, IComparable<Demon>
    {
        private int force;

        public Demon( int matricule, string nom, string prenom, Typesexe sexe, string function, int cagnotte,Attraction affectation, int force) : base( matricule, nom, prenom, sexe, function,cagnotte, affectation)
        {
            this.Force = force;

        }

        public int Force { get => force; set => force = value; }

        public override string ToString()
        {
            return "\nDEMON: "+base.ToString() + "Force :" + Force + "\n";
        }

        public int CompareTo(Demon a)
        {
            return force.CompareTo(a.force);
        }
    }
}
