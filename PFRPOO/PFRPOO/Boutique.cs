using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProjetS6
{
    public class Boutique : Attraction
    {
        
        //les attributs
        private typeBoutique type;

        //propriete
        public typeBoutique Type { get => type; set => type = value; }

        public Boutique(  int identifiant,string nom, int nbMinMonstre, bool besoinSpecifique, string typeDeBesoin, typeBoutique type):
        base(besoinSpecifique,  identifiant,  nbMinMonstre, nom, typeDeBesoin)
        {
            this.Type = type;
        }

        public override string ToString()
        {
            return base.ToString()+"Type attraction : Boutique\nType de boutique : "+ Type+"\n";
        }
    }
}
