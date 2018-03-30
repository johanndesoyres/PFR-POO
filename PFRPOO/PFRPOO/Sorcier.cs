using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProjetS6
{
    public class Sorcier : Personnel
    {
        

        private List<string> pouvoirs;
        private grade tatouage;

       
        

        public Sorcier(int matricule, string nom, string prenom, Typesexe sexe,string function,  grade tatouage,List<string> pouvoirs) : base(function, matricule, nom, prenom, sexe)
        {
            this.Pouvoirs = pouvoirs;
            this.Tatouage = tatouage;
        }

        public List<string> Pouvoirs { get => pouvoirs; set => pouvoirs = value; }
        public grade Tatouage { get => tatouage; set => tatouage = value; }

        public override string ToString()
        {
            return "\nSORCIER: "+base.ToString()+ "\nTatouage: "+ Tatouage + "\n";
        }


    }
}
