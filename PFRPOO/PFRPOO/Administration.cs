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

        public Administration(List<Attraction> attractions, List<Personnel> toutLePersonnel)
        {
            this.Attractions = attractions;
            this.ToutLePersonnel = toutLePersonnel;
        }

        //renvoie une attraction
        public Attraction creer_attraction()
        {
            int identifiant = 0;
            string nom = "";
            int nbMinMonstre = 0;
            string typeDeBesoin = "";
            bool besoinSpecifique = false;
            try
            {
                Console.WriteLine("identifiant (composé de chiffre):");
                identifiant = int.Parse(Console.ReadLine());
            }
            catch (Exception e) { Console.WriteLine(e.Message); }

            Console.WriteLine("");
            Console.WriteLine("nom:");
            nom = Console.ReadLine();
            Console.WriteLine("");
            //Console.WriteLine("nom:");

            try
            {
                Console.WriteLine("nombre minimum de monstres:");
                nbMinMonstre = int.Parse(Console.ReadLine());
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            Console.WriteLine("");

            try
            {
                Console.WriteLine("besoin specifique (true ou false) :");
                besoinSpecifique = bool.Parse(Console.ReadLine());
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            Console.WriteLine("");

            try
            {
                Console.WriteLine("type de besoin: ");
                typeDeBesoin = Console.ReadLine();
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            Console.WriteLine("");
            Attraction a = new Attraction(besoinSpecifique, identifiant, nbMinMonstre, nom, typeDeBesoin);
            return a;
        }

        //ajouter un spectacle dans une liste d'attraction
        public void ajouter_spectacle()
        {
            Attraction a = creer_attraction();
            string nomSalle = "";
            int nombrePlace = 0;
            List<DateTime> horaires = new List<DateTime>();
            try
            {
                Console.WriteLine("nom de la salle:");
                nomSalle = Console.ReadLine();
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            Console.WriteLine("");

            try
            {
                Console.WriteLine("nombre de places:");
                nombrePlace = int.Parse(Console.ReadLine());
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            Console.WriteLine("");

            try
            {
                Console.WriteLine("Combien d'horaire de spectacle voulez vous rajouter ?");
                int compt = int.Parse(Console.ReadLine());


                for (int i = 0; i < compt; i++)
                {
                    Console.WriteLine("Nouvelle horaire : ");
                    Console.Write("Heure : ");
                    int hour = int.Parse(Console.ReadLine());
                    Console.Write("Minute : ");
                    int minute = int.Parse(Console.ReadLine());
                    DateTime t = DateTime.Now;
                    DateTime d = new DateTime(t.Year, t.Month, t.Day, hour, minute, 0);
                    horaires.Add(d);
                }

            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            Console.WriteLine("");

            Spectacle b = new Spectacle(a.Identifiant, a.Nom, a.NbMinMonstre, a.BesoinSpecifique, a.TypeDeBesoin, nomSalle, nombrePlace, horaires);
            this.Attractions.Add(b);
        }

        //ajouter un DarkRide dans une liste d'attraction
        public void ajouter_DarkRide()
        {
            Attraction a = creer_attraction();
            TimeSpan duree = new TimeSpan();
            bool vehicule = false;
            try
            {
                Console.WriteLine("duree de l'attraction en heure : ");
                duree = TimeSpan.Parse(Console.ReadLine());
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            Console.WriteLine("");

            try
            {
                Console.WriteLine("vehicule (true ou false) :");
                vehicule = bool.Parse(Console.ReadLine());
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            Console.WriteLine("");

            DarkRide b = new DarkRide(a.Identifiant, a.Nom, a.NbMinMonstre, a.BesoinSpecifique, a.TypeDeBesoin, duree, vehicule);
            attractions.Add(b);


        }

        //ajouter une boutique dans une liste d'attraction
        public void ajouter_Boutique()
        {
            Attraction a = creer_attraction();
            typeBoutique type = typeBoutique.none;
            try
            {
                Console.WriteLine("type de Boutique (souvenir, barbeAPapa, nourriture) :");
                type = (typeBoutique)Enum.Parse(typeof(typeBoutique), Console.ReadLine());

            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            Console.WriteLine("");
            Boutique b = new Boutique(a.Identifiant, a.Nom, a.NbMinMonstre, a.BesoinSpecifique, a.TypeDeBesoin, type);
            attractions.Add(b);

        }

        //ajouter un RollerCoaster dans une liste d'attraction
        public void ajouter_RollerCoaster()
        {
            Attraction a = creer_attraction();
            int ageMinimum = -1;
            float tailleMinimum = 0;
            TypeCategorie categorie = TypeCategorie.none;
            try
            {
                Console.WriteLine(" categorie (assise, inversee, bobsleigh) : ");
                categorie = (TypeCategorie)Enum.Parse(typeof(TypeCategorie), Console.ReadLine());
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            Console.WriteLine("");

            try
            {
                Console.WriteLine("age minimum :");
                ageMinimum = int.Parse(Console.ReadLine());
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            Console.WriteLine("");

            try
            {
                Console.WriteLine("Taille minimum :");
                tailleMinimum = float.Parse(Console.ReadLine());
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            Console.WriteLine("");
            RollerCoaster b = new RollerCoaster(a.Identifiant, a.Nom, a.NbMinMonstre, a.BesoinSpecifique, a.TypeDeBesoin, categorie, ageMinimum, tailleMinimum);
            attractions.Add(b);

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
            string function = "";
            int matricule = 0;
            string nom = "";
            string prenom = "";
            Typesexe sex = Typesexe.none;
            try
            {
                Console.WriteLine("Function :");
                function = Console.ReadLine();
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            Console.WriteLine("");
            try
            {
                Console.WriteLine("Matricule :");
                matricule = int.Parse(Console.ReadLine());
            }
            catch (InvalidCastException e) { Console.WriteLine(e.Message); }

            Console.WriteLine("");
            try
            {
                Console.WriteLine("Nom :");
                nom = Console.ReadLine();
            }
            catch (InvalidCastException e) { Console.WriteLine(e.Message); }
            Console.WriteLine("");

            try
            {
                Console.WriteLine("Prenom :");
                prenom = Console.ReadLine();
            }
            catch (InvalidCastException e) { Console.WriteLine(e.Message); }
            Console.WriteLine("");

            try
            {
                Console.WriteLine("Sexe :");
                sex = (Typesexe)Enum.Parse(typeof(Typesexe), Console.ReadLine());

            }
            catch (InvalidCastException e) { Console.WriteLine(e.Message); }
            Console.WriteLine("");

            Personnel a = new Personnel(function, matricule, nom, prenom, sex);

            return a;
        }

        //On cree un membre monstre
        public Monstre creer_monstre()
        {
            Personnel a = creer_personnel();
            int cagnotte = 0;
            Attraction affectation = null;
            try
            {
                Console.WriteLine("Cagnotte :");
                cagnotte = int.Parse(Console.ReadLine());
            }
            catch (InvalidCastException e) { Console.WriteLine(e.Message); }
            Console.WriteLine("");

            try
            {
                foreach (Attraction i in attractions)
                {
                    Console.WriteLine("");
                    i.ToString();
                    Console.WriteLine("");
                }
                Console.WriteLine("Choissisez l'identifiant de l'attraction à affectée :");
                int id = int.Parse(Console.ReadLine());
                for (int i = 0; i < attractions.Count; i++)
                {
                    if (attractions[i].Identifiant == id) { affectation = attractions.ElementAt(i); }
                }
            }
            catch (InvalidCastException e) { Console.WriteLine(e.Message); }
            Console.WriteLine("");

            Monstre b = new Monstre(a.Matricule, a.Nom, a.Prenom, a.Sexe, a.Function, cagnotte, affectation);
            return b;


        }

        //ajouter un sorcier dans une liste de personnel
        public void ajouter_sorcier()
        {
            Personnel a = creer_personnel();
            grade tatouage = grade.none;
            List<string> mesPouvoirs = new List<string>();
            try
            {
                Console.WriteLine("Tatouage :");
                tatouage = (grade)Enum.Parse(typeof(grade), Console.ReadLine());
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
                    mesPouvoirs.Add(Console.ReadLine());
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
            Monstre a = creer_monstre();
            int force = 0;
            try
            {
                Console.WriteLine("Force :");
                force = int.Parse(Console.ReadLine());
            }
            catch (InvalidCastException e) { Console.WriteLine(e.Message); }
            Console.WriteLine("");
            Demon b = new Demon(a.Matricule, a.Nom, a.Prenom, a.Sexe, a.Function, a.Cagnotte, a.Affectation, force);
            ToutLePersonnel.Add(b);
        }

        //ajouter un loup-garou dans une liste de personnel
        public void ajouter_loupgarous()
        {
            Monstre a = creer_monstre();
            float indiceCruaute = 0;
            try
            {
                Console.WriteLine("Indice de cruauté :");
                indiceCruaute = float.Parse(Console.ReadLine());
            }
            catch (InvalidCastException e) { Console.WriteLine(e.Message); }
            Console.WriteLine("");
            LoupGarou b = new LoupGarou(a.Matricule, a.Nom, a.Prenom, a.Sexe, a.Function, a.Cagnotte, a.Affectation, indiceCruaute);
            ToutLePersonnel.Add(b);
        }

        //ajouter un vampire dans une liste de personnel
        public void ajouter_vampire()
        {
            Monstre a = creer_monstre();
            float indiceLuminosite = 0;
            try
            {
                Console.WriteLine("Indice de luminosité :");
                indiceLuminosite = float.Parse(Console.ReadLine());
            }
            catch (InvalidCastException e) { Console.WriteLine(e.Message); }
            Console.WriteLine("");
            Vampire b = new Vampire(a.Matricule, a.Nom, a.Prenom, a.Sexe, a.Function, a.Cagnotte, a.Affectation, indiceLuminosite);
            ToutLePersonnel.Add(b);
        }

        //ajouter un zombie dans une liste de personnel
        public void ajouter_zombie()
        {
            Monstre a = creer_monstre();

            int degreDecomposition = 0;
            CouleurZ teint = CouleurZ.none;
            try
            {
                Console.WriteLine("Degré de décomposition :");
                degreDecomposition = int.Parse(Console.ReadLine());
            }
            catch (InvalidCastException e) { Console.WriteLine(e.Message); }
            Console.WriteLine("");

            try
            {
                Console.WriteLine("Couleur du zombie :");
                teint = (CouleurZ)Enum.Parse(typeof(CouleurZ), Console.ReadLine());
            }
            catch (InvalidCastException e) { Console.WriteLine(e.Message); }
            Console.WriteLine("");
            Zombie b = new Zombie(a.Matricule, a.Nom, a.Prenom, a.Sexe, a.Function, a.Cagnotte, a.Affectation, teint, degreDecomposition);
            ToutLePersonnel.Add(b);
        }

        //ajouter un fantome dans une liste de personnel
        public void ajouter_fantome()
        {
            Fantome a = creer_monstre() as Fantome;
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


        //------------------------------------------------------------------------------------------------------------------------------------

        //Creer une liste d'attractions selon un critere
        public List<Attraction> SelectionAttraction()
        {
            List<Attraction> ma_selection = new List<Attraction>();

            ma_selection = attractions;

            Console.WriteLine("1- Liste des attrcatuions avec un besoin specifique \n2- Liste des attractions en maintenance\n3- Liste des attractions ouvertes" +
               "\n4- Listes des boutiques\n5- Liste des DarkRides\n6- Liste des Rollercoasters \n7- Liste des Spectacles ");
            int choix = -1;

            while (choix != 1 && choix != 2 && choix != 3 && choix != 4 && choix != 5 && choix != 6 && choix != 7) { try { choix = int.Parse(Console.ReadLine()); } catch (InvalidCastException e) { Console.WriteLine(e.Message); } }

            switch (choix)
            {
                case 1:
                    Console.WriteLine("");
                    ma_selection.RemoveAll(montest1);//RemoveAll() supprime toues les attractions de ma_selection pour lesquelles le test renvoie true
                    Console.WriteLine("");
                    break;
                case 2:
                    Console.WriteLine("");
                    ma_selection.RemoveAll(montest2);
                    Console.WriteLine("");
                    break;
                case 3:
                    Console.WriteLine("");
                    ma_selection.RemoveAll(montest3);
                    Console.WriteLine("");    
                    break;
                case 4:
                    Console.WriteLine("");
                    ma_selection.RemoveAll(montest4);
                    Console.WriteLine("");
                    break;
                case 5:
                    Console.WriteLine("");
                    ma_selection.RemoveAll(montest5);
                    Console.WriteLine("");
                    break;
                case 6:
                    Console.WriteLine("");
                    ma_selection.RemoveAll(montest6);
                    Console.WriteLine("");
                    break;
                case 7:
                    Console.WriteLine("");
                    ma_selection.RemoveAll(montest7);
                    Console.WriteLine("");
                    break;


            }

            return ma_selection;

        }

        //Si le test renvoie true l'attraction a est supprimée

        //Test si l'attraction a un besoin spécifique
        private bool montest1(Attraction a)
        {
            bool resultat = false;

            resultat = a.pas_besoinspecifique();
            return resultat;
          
        }
        //Test si l'attraction est en maintenance
        private bool montest2(Attraction a)
        {
            bool resultat = a.pas_maintenance();
            return resultat;

        }
        //Test si l'attraction est ouverte
        private bool montest3(Attraction a)
        {
            bool resultat = a.pas_ouvert();
            return resultat;

        }
        //Test si l'attraction est une boutique
        private bool montest4(Attraction a)
        {

            bool resultat = true;

            if(a is Boutique) { resultat = false; }
            
            return resultat;

        }
        //Test si l'attraction est un DrakRide
        private bool montest5(Attraction a)
        {

            bool resultat = true;

            if (a is DarkRide) { resultat = false; }

            return resultat;

        }
        //Test si l'attraction est un Rollercoaster
        private bool montest6(Attraction a)
        {

            bool resultat = true;

            if (a is RollerCoaster) { resultat = false; }

            return resultat;

        }
        //Test si l'attraction est un Spectacle
        private bool montest7(Attraction a)
        {

            bool resultat = true;

            if (a is Spectacle) { resultat = false; }

            return resultat;

        }

        //---------------------------------------------------------------------------------------------

        //Creer une liste de personnel selon un critere
        public List<Personnel> SelectionPersonnel()
        {
            List<Personnel> ma_selection = new List<Personnel>();

            ma_selection = toutLePersonnel;

            Console.WriteLine("1- Liste des monstres affecté a une Boutique \n2- Liste des monstres affecté a un DarkRide\n3- Liste des monstres affecté a un RollerCoaster" +
               "\n4- Liste des monstres affecté a un Spectacle\n5- Liste des Sorciers\n6- Liste des Démons \n7- Liste des Loups-Garous\n8- Liste des vampires\n9- Liste des Fantômes\n10- Liste des Zombies ");
            int choix = -1;

            while (choix != 1 && choix != 2 && choix != 3 && choix != 4 && choix != 5 && choix != 6 && choix != 7 && choix != 8 && choix != 9 && choix != 10) { try { choix = int.Parse(Console.ReadLine()); } catch (InvalidCastException e) { Console.WriteLine(e.Message); } }

            switch (choix)
            {
                case 1:
                    Console.WriteLine("");
                    ma_selection.RemoveAll(test1);
                    Console.WriteLine("");
                    break;
                case 2:
                    Console.WriteLine("");
                    ma_selection.RemoveAll(test2);
                    Console.WriteLine("");
                    break;
                case 3:
                    Console.WriteLine("");
                    ma_selection.RemoveAll(test3);
                    Console.WriteLine("");
                    break;
                case 4:
                    Console.WriteLine("");
                    ma_selection.RemoveAll(test4);
                    Console.WriteLine("");
                    break;
                case 5:
                    Console.WriteLine("");
                    ma_selection.RemoveAll(test5);
                    Console.WriteLine("");
                    break;
                case 6:
                    Console.WriteLine("");
                    ma_selection.RemoveAll(test6);
                    Console.WriteLine("");
                    break;
                case 7:
                    Console.WriteLine("");
                    ma_selection.RemoveAll(test7);
                    Console.WriteLine("");
                    break;
                case 8:
                    Console.WriteLine("");
                    ma_selection.RemoveAll(test8);
                    Console.WriteLine("");
                    break;
                case 9:
                    Console.WriteLine("");
                    ma_selection.RemoveAll(test9);
                    Console.WriteLine("");
                    break;
                case 10:
                    Console.WriteLine("");
                    ma_selection.RemoveAll(test10);
                    Console.WriteLine("");
                    break;

            }

            return ma_selection;

        }

        //Si le test renvoie true le personnel a est supprimé

       //Test si le personnel a une affectation sur une boutique
        private bool test1(Personnel a)
        {
            bool resultat = false;

            if (a is Monstre) { resultat = (a as Monstre).affectation_Boutique(); }
            return resultat;

        }
        //Test si le personnel a une affectation sur un DarkRide
        private bool test2(Personnel a)
        {
            bool resultat = false;

            if (a is Monstre) { resultat = (a as Monstre).affectation_DarkRide(); }
            return resultat;

        }
        //Test si le personnel a une affectation sur un Rollercoaster
        private bool test3(Personnel a)
        {
            bool resultat = false;

            if (a is Monstre) { resultat = (a as Monstre).affectation_Rollercoaster(); }
            return resultat;

        }
        //Test si le personnel sur un Spectacle
        private bool test4(Personnel a)
        {
            bool resultat = false;

            if (a is Monstre) { resultat = (a as Monstre).affectation_Spectacle(); }
            return resultat;

        }
        //Test si le personnel est un sorcier
        private bool test5(Personnel a)
        {
            bool resultat = true;

            if (a is Sorcier) { resultat = false; }
            return resultat;

        }
        //Test si le personnel est un démon
        private bool test6(Personnel a)
        {
            bool resultat = true;

            if (a is Demon) { resultat = false ; }
            return resultat;

        }
        //Test si le personnel est un Loup-Garou
        private bool test7(Personnel a)
        {
            bool resultat = true;

            if (a is LoupGarou) { resultat = false; }
            return resultat;

        }
        //Test si le personnel est un Vampire
        private bool test8(Personnel a)
        {
            bool resultat = true;

            if (a is Vampire) { resultat = false; }
            return resultat;

        }
        //Test si le personnel est un Fantome
        private bool test9(Personnel a)
        {
            bool resultat = true;

            if (a is Fantome) { resultat = false; }
            return resultat;

        }
        //Test si le personnel est un Zombie
        private bool test10(Personnel a)
        {
            bool resultat = true;

            if (a is Zombie) { resultat = false; }
            return resultat;

        }
    }
}
