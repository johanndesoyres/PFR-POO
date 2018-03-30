using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProjetS6
{
    public class Attraction
    {
        #region Attributs
        private bool besoinSpecifique;
        private TimeSpan dureeMaintenance;
        private List<Monstre> equipe;
        private int identifiant;
        private bool maintenance;
        private string natureMaintenance;
        private int nbMinMonstre; 
        private string nom;
        private bool ouvert;
        private string typeDeBesoin;
        #endregion

        public int Identifiant { get => identifiant; set { identifiant = value; } }
        public string Nom { get => nom; set { nom = value; } }
        public int NbMinMonstre { get => nbMinMonstre; set => nbMinMonstre = value; }
        public string TypeDeBesoin { get => typeDeBesoin; set => typeDeBesoin = value; }
        public bool BesoinSpecifique { get => besoinSpecifique; set => besoinSpecifique = value; }

        public Attraction()
        { }

        public Attraction(bool besoinSpecifique, int identifiant, int nbMinMonstre, string nom, string typeDeBesoin)
        {
            this.BesoinSpecifique = besoinSpecifique;
            this.dureeMaintenance = new TimeSpan(0,0,0);
            this.equipe = null;
            this.identifiant = identifiant;
            this.maintenance = false;
            this.natureMaintenance = null;
            this.NbMinMonstre = nbMinMonstre;
            this.nom = nom;
            this.ouvert = false;
            this.TypeDeBesoin = typeDeBesoin;
        }



        public override string ToString()
        {
            return "Nom : " + Nom + "\nIdentifiant : " + Identifiant+ "\n";
        }



    }
}
