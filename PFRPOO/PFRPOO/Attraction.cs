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
            this.maintenance = false;
            this.identifiant = identifiant;
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

        public bool pas_besoinspecifique()
        {
            bool suppression = true;
            if (besoinSpecifique) { suppression = false; }
            return suppression;
        }

        public bool pas_maintenance()
        {
            bool suppression = true;
            if (maintenance) { suppression = false; }
            return suppression;
        }

        public bool test_nbminMonstres(int nb, string condition)
        {
            bool suppression = true;
            if (condition == ">=")
            {
                if (nbMinMonstre >= nb) { suppression = false; }
            }
            else
            {
                if (nbMinMonstre <= nb) { suppression = false; }
            }
            return suppression;
            
        }

        public bool pas_ouvert()
        {
            bool suppression = true;
            if (ouvert) { suppression = false; }
            return suppression;
        }

    }
}
