using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProjetS6
{
    public class Administration
    {
        private List<Attraction> attractions;
        private List<Personnel> toutLePersonnel;

        public List<Attraction> Attractions { get => attractions; set => attractions = value; }
        public List<Personnel> ToutLePersonnel { get => toutLePersonnel; set => toutLePersonnel = value; }

        public Administration(List<Attraction> attractions,List<Personnel> toutLePersonnel)
        {
            this.Attractions = attractions;
            this.ToutLePersonnel = toutLePersonnel;
        }

        //renvoie une attraction
        public Attraction creer_attraction()
        {
            Attraction a = new Attraction();

            try
            {
                Console.WriteLine("identifiant:");
                a.Identifiant = int.Parse(Console.ReadLine());
            }
            catch (InvalidCastException e) { Console.WriteLine(e.Message); }

            Console.WriteLine("");
            Console.WriteLine("nom:");
            a.Nom = Console.ReadLine();
            Console.WriteLine("nom:");

            try
            {
                Console.WriteLine("nombre minimum de monstres:");
                a.NbMinMonstre = int.Parse(Console.ReadLine());
            }
            catch (InvalidCastException e) { Console.WriteLine(e.Message); }
            Console.WriteLine("");

            try
            {
                Console.WriteLine("besoin specifique (0 pour true sinon false) :");
                a.BesoinSpecifique = bool.Parse(Console.ReadLine());
            }
            catch (InvalidCastException e) { Console.WriteLine(e.Message); }
            Console.WriteLine("");

            try
            {
                Console.WriteLine("type de besoin:");
                a.TypeDeBesoin = Console.ReadLine();
            }
            catch (InvalidCastException e) { Console.WriteLine(e.Message); }
            Console.WriteLine("");

            return a;
        }

        //ajouter un spectacle dans une liste d'attraction
        public void ajouter_spectacle()
        {
            Spectacle a = creer_attraction() as Spectacle;

            try
            {
                Console.WriteLine("nom de la salle:");
                a.NomSalle = Console.ReadLine();
            }
            catch (InvalidCastException e) { Console.WriteLine(e.Message); }
            Console.WriteLine("");

            try
            {
                Console.WriteLine("nombre de places:");
                a.NombrePlace = int.Parse(Console.ReadLine());
            }
            catch (InvalidCastException e) { Console.WriteLine(e.Message); }
            Console.WriteLine("");

            try
            {
                Console.WriteLine("nombre de places:");
                DateTime heure = DateTime.Parse(Console.ReadLine());
                a.Horaire.Add(heure);
            }
            catch (InvalidCastException e) { Console.WriteLine(e.Message); }
            Console.WriteLine("");

            this.Attractions.Add(a);
        }

        //ajouter un DarkRide dans une liste d'attraction
        public void ajouter_DarkRide()
        {
            DarkRide a = creer_attraction() as DarkRide;

            try
            {
                Console.WriteLine("duree:");
                a.Duree = TimeSpan.Parse(Console.ReadLine());
            }
            catch (InvalidCastException e) { Console.WriteLine(e.Message); }
            Console.WriteLine("");

            try
            {
                Console.WriteLine("vehicule (0 pour true sinon false) :");
                a.Vehicule = bool.Parse(Console.ReadLine());
            }
            catch (InvalidCastException e) { Console.WriteLine(e.Message); }
            Console.WriteLine("");

            attractions.Add(a);


        }

        //ajouter une boutique dans une liste d'attraction
        public void ajouter_Boutique()
        {
            Boutique a = creer_attraction() as Boutique;

            try
            {
                Console.WriteLine("type de Boutique :");
                a.Type = (typeBoutique)Enum.Parse(typeof(typeBoutique), Console.ReadLine());

            }
            catch (InvalidCastException e) { Console.WriteLine(e.Message); }
            Console.WriteLine("");

            attractions.Add(a);

        }

        //ajouter un RollerCoaster dans une liste d'attraction
        public void ajouter_RollerCoaster()
        {
            RollerCoaster a = creer_attraction() as RollerCoaster;

            try
            {
                Console.WriteLine(" categorie :");
                a.Categorie = (TypeCategorie)Enum.Parse(typeof(TypeCategorie), Console.ReadLine());
            }
            catch (InvalidCastException e) { Console.WriteLine(e.Message); }
            Console.WriteLine("");

            try
            {
                Console.WriteLine("age minimum :");
                a.AgeMinimum = int.Parse(Console.ReadLine());
            }
            catch (InvalidCastException e) { Console.WriteLine(e.Message); }
            Console.WriteLine("");

            try
            {
                Console.WriteLine("Taille minimum :");
                a.TailleMinimum = float.Parse(Console.ReadLine());
            }
            catch (InvalidCastException e) { Console.WriteLine(e.Message); }
            Console.WriteLine("");

            attractions.Add(a);

        }


        public void MainAjouterAttraction()
        {
            Console.WriteLine("Quel type d'attraction voulez vous ajouter :");
            Console.WriteLine("1- Spectacle\n2- Boutique\n3- DarkRide\n4- RollerCoaster");
            int choix = -1;

            while (choix != 1 && choix != 2 && choix != 3 && choix != 4) { try { choix = int.Parse(Console.ReadLine()); } catch (InvalidCastException e) { Console.WriteLine(e.Message); } }

            switch (choix)
            {
                case 1:
                    Console.WriteLine("");
                    ajouter_spectacle();
                    Console.WriteLine("");
                    break;
                case 2:
                    Console.WriteLine("");
                    ajouter_Boutique();
                    Console.WriteLine("");
                    break;
                case 3:
                    Console.WriteLine("");
                    ajouter_DarkRide();
                    Console.WriteLine("");
                    break;
                case 4:
                    Console.WriteLine("");
                    ajouter_RollerCoaster();
                    Console.WriteLine("");
                    break;
            }

        }

        //---------------------------------------------------------------------------------------------------------------

        //On cree un membre personnel
        public Personnel creer_personnel()
        {
            Personnel a = new Personnel();

            try
            {
                Console.WriteLine("Matricule :");
                a.Matricule = int.Parse(Console.ReadLine());
            }
            catch (InvalidCastException e) { Console.WriteLine(e.Message); }

            Console.WriteLine("");
            try
            {
                Console.WriteLine("Nom :");
                a.Nom = Console.ReadLine();
            }
            catch (InvalidCastException e) { Console.WriteLine(e.Message); }
            Console.WriteLine("");

            try
            {
                Console.WriteLine("Prenom :");
                a.Prenom = Console.ReadLine();
            }
            catch (InvalidCastException e) { Console.WriteLine(e.Message); }
            Console.WriteLine("");

            try
            {
                Console.WriteLine("type de Boutique :");
                a.Sexe = (Typesexe)Enum.Parse(typeof(Typesexe), Console.ReadLine());

            }
            catch (InvalidCastException e) { Console.WriteLine(e.Message); }
            Console.WriteLine("");



            return a;
        }

        //On cree un membre monstre
        public Monstre creer_monstre()
        {
            Monstre a = creer_personnel() as Monstre;
            try
            {
                Console.WriteLine("Cagnotte :");
                a.Cagnotte = int.Parse(Console.ReadLine());
            }
            catch (InvalidCastException e) { Console.WriteLine(e.Message); }
            Console.WriteLine("");

            try
            {
                foreach(Attraction i in attractions)
                {
                    Console.WriteLine("");
                    i.ToString();
                    Console.WriteLine("");
                }
                Console.WriteLine("Choissisez l'identifiant de l'attraction à affectée :");
                int id = int.Parse(Console.ReadLine());
                for(int i=0; i<attractions.Count; i++)
                {
                    if (attractions[i].Identifiant == id) {a.Affectation = attractions.ElementAt(i);}
                }
            }
            catch (InvalidCastException e) { Console.WriteLine(e.Message); }
            Console.WriteLine("");

            return a;

        }

        //ajouter un sorcier dans une liste de personnel
        public void ajouter_sorcier()
        {
            Sorcier a = creer_personnel() as Sorcier;

            try
            {
                Console.WriteLine("Tatouage :");
                a.Tatouage = (grade)Enum.Parse(typeof(grade), Console.ReadLine());
            }
            catch (InvalidCastException e) { Console.WriteLine(e.Message); }
            Console.WriteLine("");

            try
            {
                Console.WriteLine("Nombre de pouvoirs a attribuer :");
                int nb_pouvoirs = int.Parse(Console.ReadLine());
                int i = 0;
                Console.WriteLine("Pouvoirs :");
                while (i != nb_pouvoirs) 
                {
                    a.Pouvoirs.Add(Console.ReadLine());
                    i++;
                }
                 
            }
            catch (InvalidCastException e) { Console.WriteLine(e.Message); }
            Console.WriteLine("");

            ToutLePersonnel.Add(a);

        }

        //ajouter un démon dans une liste de personnel
        public void ajouter_demon()
        {
            Demon a = creer_monstre() as Demon;

            try
            {
                Console.WriteLine("Force :");
                a.Force = int.Parse(Console.ReadLine());
            }
            catch (InvalidCastException e) { Console.WriteLine(e.Message); }
            Console.WriteLine("");

            ToutLePersonnel.Add(a);
        }

        //ajouter un loup-garou dans une liste de personnel
        public void ajouter_loupgarous()
        {
            LoupGarou a = creer_monstre() as LoupGarou;

            try
            {
                Console.WriteLine("Indice de cruauté :");
                a.IndiceCruaute = float.Parse(Console.ReadLine());
            }
            catch (InvalidCastException e) { Console.WriteLine(e.Message); }
            Console.WriteLine("");

            ToutLePersonnel.Add(a);
        }

        //ajouter un vampire dans une liste de personnel
        public void ajouter_vampire()
        {
            Vampire a = creer_monstre() as Vampire;

            try
            {
                Console.WriteLine("Indice de luminosité :");
                a.IndiceLuminosite = float.Parse(Console.ReadLine());
            }
            catch (InvalidCastException e) { Console.WriteLine(e.Message); }
            Console.WriteLine("");

            ToutLePersonnel.Add(a);
        }

        //ajouter un zombie dans une liste de personnel
        public void ajouter_zombie()
        {
            Zombie a = creer_monstre() as Zombie;

            try
            {
                Console.WriteLine("Degré de décomposition :");
                a.DegreDecomposition = int.Parse(Console.ReadLine());
            }
            catch (InvalidCastException e) { Console.WriteLine(e.Message); }
            Console.WriteLine("");

            try
            {
                Console.WriteLine("Couleur du zombie :");
                a.Teint = (CouleurZ)Enum.Parse(typeof(CouleurZ), Console.ReadLine());
            }
            catch (InvalidCastException e) { Console.WriteLine(e.Message); }
            Console.WriteLine("");

            ToutLePersonnel.Add(a);
        }

        //ajouter un fantome dans une liste de personnel
        public void ajouter_fantome()
        {
            Fantome a = creer_monstre() as Fantome;

            try
            {
                Console.WriteLine("Atout :");
                a.Atout = Console.ReadLine();
            }
            catch (InvalidCastException e) { Console.WriteLine(e.Message); }
            Console.WriteLine("");

            ToutLePersonnel.Add(a);
        }


        public void MainAjouterPersonnel()
        {
            Console.WriteLine("Quel type de personnel voulez vous ajouter :");
            Console.WriteLine("1-Sorcier\n2- Demon\n3- Loup-Garou\n4- Zombie\n5- Fantôme\n6- Vampire\n7- Monstre ");
            int choix = -1;

            while (choix != 1 && choix != 2 && choix != 3 && choix != 4 && choix != 5 && choix != 6) { try { choix = int.Parse(Console.ReadLine()); } catch (InvalidCastException e) { Console.WriteLine(e.Message); } }

            switch (choix)
            {
                case 1:
                    Console.WriteLine("");
                    ajouter_sorcier();
                    Console.WriteLine("");
                    break;
                case 2:
                    Console.WriteLine("");
                    ajouter_demon();
                    Console.WriteLine("");
                    break;
                case 3:
                    Console.WriteLine("");
                    ajouter_loupgarous();
                    Console.WriteLine("");
                    break;
                case 4:
                    Console.WriteLine("");
                    ajouter_zombie();
                    Console.WriteLine("");
                    break;
                case 5:
                    Console.WriteLine("");
                    ajouter_fantome();
                    Console.WriteLine("");
                    break;
                case 6:
                    Console.WriteLine("");
                    ajouter_vampire();
                    Console.WriteLine("");
                    break;
                case 7:
                    Console.WriteLine("");
                    Monstre a = creer_monstre();
                    ToutLePersonnel.Add(a);
                    Console.WriteLine("");
                    break;
            }

        }

       
    }
}
