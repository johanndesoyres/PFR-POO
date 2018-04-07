using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ProjetS6
{
    public class Spectacle:Attraction,IComparable<Spectacle>
    {
        //Les attributs
        private List<DateTime> horaire;
        private int nombrePlace;
        private string nomSalle;

        public Spectacle(int identifiant, string nom, int nbMinMonstre, bool besoinSpecifique, string typeDeBesoin,string nomSalle, int nombrePlace, List<DateTime>horaire):
        base(besoinSpecifique,  identifiant,  nbMinMonstre, nom, typeDeBesoin)
        {
            this.horaire = horaire;
            this.nombrePlace = nombrePlace;
            this.nomSalle = nomSalle;
        }

        public List<DateTime> Horaire { get => horaire; set => horaire = value; }
        public int NombrePlace { get => nombrePlace; set => nombrePlace = value; }
        public string NomSalle { get => nomSalle; set => nomSalle = value; }

        public override string ToString()
        {
            
            return base.ToString()+"Type attraction : Spectacle\nNom salle : " + nomSalle + "\nNombre de places : " + nombrePlace+"\n";
        }

        public int CompareTo(Spectacle a)
        {
            return nombrePlace.CompareTo(a.nombrePlace);
        }
    }
}
