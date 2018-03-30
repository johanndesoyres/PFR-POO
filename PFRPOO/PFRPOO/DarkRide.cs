using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ProjetS6
{
    public class DarkRide: Attraction
    {
        //les attributs`
        private TimeSpan duree;
        private bool vehicule;

        public DarkRide(int identifiant, string nom, int nbMinMonstre, bool besoinSpecifique, string typeDeBesoin,TimeSpan duree , bool vehicule):
        base(besoinSpecifique,  identifiant,  nbMinMonstre, nom, typeDeBesoin)
        {
            this.duree = duree;
            this.vehicule = vehicule;
        }

        public TimeSpan Duree { get => duree; set => duree = value; }
        public bool Vehicule { get => vehicule; set => vehicule = value; }

        public override string ToString()
        {
            return base.ToString() + "Type attraction : DarkRide\n";
        }
    }
}
