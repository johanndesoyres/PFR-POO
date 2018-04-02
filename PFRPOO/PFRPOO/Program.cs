using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProjetS6
{
    class MainClass
    {
      
        //Méthodes pour lire le fichier
        static Attraction QuelEstAttraction(List<Attraction>Liste_attraction, int num)
        {
            Attraction a = null;
            foreach(Attraction i in Liste_attraction)
            {
                if (i.Identifiant == num) a = i;
            }
            return a;
        }
        static List<Personnel> LecturePersonnel(StreamReader monStreamReader, List<Attraction>liste_attraction)
        {
            List<Personnel> liste_personnel = new List<Personnel>();
            string ligne = monStreamReader.ReadLine(); //on stock la premiere ligne 

            for (int j = 0; j < 17; j++) // tant qu'il y a pas d'espace vide
            {
                string[] temp = ligne.Split(';');
                Typesexe type_sex = Typesexe.none;
                int matricule=-1;
                try {matricule = int.Parse(temp[1]);}catch(InvalidCastException e) {Console.WriteLine(e.Message);}
                try { type_sex = (Typesexe)Enum.Parse(typeof(Typesexe), temp[4]); } catch(InvalidCastException e){Console.WriteLine(e.Message);}
                int c = -1;
                Attraction monAttraction = null ;
                if(temp[0]!="Sorcier")
                {
                    
                    try { c = int.Parse(temp[7]); } catch (FormatException e) { Console.WriteLine(e.Message); }
                    monAttraction = QuelEstAttraction(liste_attraction, c);
                }


                switch (temp[0])
                {
                    case "Sorcier":
                        grade G = grade.none;
                        try { G = (grade)Enum.Parse(typeof(grade), temp[6]); } catch(InvalidCastException e){Console.WriteLine(e.Message);}

                        List<string> liste_p = new List<string>();
                        string[] temp2 = temp[7].Split('-');
                        for (int i = 0; i < temp2.Length; i++)
                        {
                            liste_p.Add(temp2[i]);
                        }
                        Sorcier monSorcier = new Sorcier(matricule, temp[2], temp[3], type_sex, temp[5], G, liste_p);
                        liste_personnel.Add(monSorcier);
                        break;

                    case "Monstre":

                        int cagnotte_monstre = 0;
                        try {cagnotte_monstre = int.Parse(temp[6]);}catch(InvalidCastException e){Console.WriteLine(e.Message);}
                        Monstre monMonstre = new Monstre(matricule, temp[2], temp[3], type_sex, temp[5], cagnotte_monstre,monAttraction );
                        liste_personnel.Add(monMonstre);
                        break;

                    case "Demon":
                        int cagnotte_demon= int.Parse(temp[6]);
                        int force = int.Parse(temp[8]);
                        Demon monDemon = new Demon(matricule, temp[2], temp[3], type_sex, temp[5],  cagnotte_demon, monAttraction,force);
                        liste_personnel.Add(monDemon);
                        break;

                    case "Fantome":
                        int cagnotte_fantome = int.Parse(temp[6]);
                        Fantome monFantome = new Fantome(matricule, temp[2], temp[3], type_sex, temp[5], cagnotte_fantome, monAttraction);
                        liste_personnel.Add(monFantome);
                        break;
                    case "LoupGarou":
                        int cagnotte_loup = int.Parse(temp[6]);
                        float indiceCruaute = float.Parse(temp[8]);
                        LoupGarou monLoup = new LoupGarou(matricule, temp[2], temp[3], type_sex, temp[5], cagnotte_loup, monAttraction, indiceCruaute);
                        liste_personnel.Add(monLoup);
                        break;
                    case "Vampire":
                        int cagnotte_vamp = int.Parse(temp[6]);
                        float indiceLuminosite = float.Parse(temp[8]);
                        Vampire monVamp = new Vampire(matricule, temp[2], temp[3], type_sex, temp[5], cagnotte_vamp, monAttraction, indiceLuminosite);
                        liste_personnel.Add(monVamp);
                        break;
                    case "Zombie":
                        CouleurZ maCouleur = (CouleurZ)Enum.Parse(typeof(CouleurZ), temp[8]);
                        int degreDecomposition = int.Parse(temp[9]);
                        int cagnotte_zomb = int.Parse(temp[6]);
                        Zombie monZomb = new Zombie(matricule, temp[2], temp[3], type_sex, temp[5], cagnotte_zomb, monAttraction, maCouleur, degreDecomposition);
                        liste_personnel.Add(monZomb);
                        break;
                }



                ligne = monStreamReader.ReadLine();
            }
            monStreamReader.Close();
            return liste_personnel;
        }
        static List<Attraction> LectureAttraction(StreamReader monStreamReader)
        {
            List<Attraction> liste_attraction = new List<Attraction>();

            string ligne=null;
            for (int i = 0; i < 18;i++)
            {
                ligne = monStreamReader.ReadLine(); 
            }


            while (ligne != null) 
            {
                string[] temp = ligne.Split(';');
                int identifiant = int.Parse(temp[1]);
                int nbMinimMonstre = int.Parse(temp[3]);
                bool besoinSpecifique = bool.Parse(temp[4]);

                switch (temp[0])
                {
                    
                    case "Boutique":
                        typeBoutique monType = typeBoutique.none;
                        try { monType = (typeBoutique)Enum.Parse(typeof(typeBoutique), temp[6]); } catch(InvalidCastException e){Console.WriteLine(e.Message);}
                        Boutique maBoutique = new Boutique(identifiant, temp[2], nbMinimMonstre, besoinSpecifique,temp[5], monType);
                        liste_attraction.Add(maBoutique);
                        break;
                    case "DarkRide":
                        TimeSpan T = new TimeSpan(0, 0, 0);
                        try { int heure = int.Parse(temp[6]); T = new TimeSpan(heure, 0, 0); } catch (Exception e) { Console.Write(e.Message); }
                        bool vehicule = false ;try { vehicule = bool.Parse(temp[7]); }catch(InvalidCastException e){Console.WriteLine(e.Message);}

                        DarkRide monDarkRide = new DarkRide(identifiant, temp[2], nbMinimMonstre, besoinSpecifique,temp[5],T,vehicule);
                        liste_attraction.Add(monDarkRide);
                        break;
                    case "RollerCoaster":
                        int ageMinim = int.Parse(temp[7]);
                        float tailleMinim = float.Parse(temp[8]);
                        TypeCategorie MyType;
                        MyType = (TypeCategorie)Enum.Parse(typeof(TypeCategorie), temp[6]);
                        RollerCoaster monRollerCoaster = new RollerCoaster(identifiant, temp[2], nbMinimMonstre, besoinSpecifique, temp[5],MyType ,ageMinim, tailleMinim);
                        liste_attraction.Add(monRollerCoaster);
                        break;
                    case "Spectacles":
                        List<DateTime> liste_horaire = new List<DateTime>();
                        int nbPlace = int.Parse(temp[7]);
                        string[] temp2 = temp[8].Split(' ');
                        for (int i = 0; i<temp2.Length;i++)
                        {
                            DateTime m = Convert.ToDateTime(temp2[i]);
                            liste_horaire.Add(m);
                        }
                        Spectacle monSpectacle = new Spectacle(identifiant, temp[2], nbMinimMonstre, besoinSpecifique, temp[5], temp[6], nbPlace,liste_horaire);
                        liste_attraction.Add(monSpectacle);
                        break;
                }
                ligne = monStreamReader.ReadLine();

            }
            monStreamReader.Close();
            return liste_attraction;

        }
        static Administration LectureFichierExcel(string chemin )
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("Lecture du fichier....");
            Console.WriteLine("");

            Administration monAdmi = null;
            try
            {
                
                StreamReader monStreamReader = new StreamReader(chemin);
                List<Attraction> maListeAttraction = LectureAttraction(monStreamReader);
                StreamReader monStreamReader2 = new StreamReader(chemin);
                List<Personnel> maListePersonnel = LecturePersonnel(monStreamReader2, maListeAttraction);

                monAdmi = new Administration(maListeAttraction, maListePersonnel);
            }
            catch (Exception e) {  Console.WriteLine(e.Message);  }

            Console.WriteLine("");
            Console.WriteLine("Lecture du fichier réussie !");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Gray;


            return monAdmi;  
        }

        //Méthodes d'affichage
        static void AfficherPersonnel(List<Personnel>maListe)
        {
            Console.WriteLine("Voici la liste du personnel :\n");
            foreach(Personnel i in maListe)
            {
                if(i is Monstre)
                {
                    Monstre M = i as Monstre;
                    Console.WriteLine(M);
                }
                if(i is Sorcier)
                {
                    Sorcier S = i as Sorcier;
                    Console.WriteLine(S);
                }
            }
        }
        static void AfficherAttraction(List<Attraction>maListe)
        {
            Console.WriteLine("Voici la liste des attractions :\n");

            foreach(Attraction i in maListe)
            {
                if(i is Spectacle)
                {
                    Spectacle S = i as Spectacle;
                    Console.WriteLine(S);
                }
                if(i is Boutique)
                {
                    Boutique B = i as Boutique;
                    Console.WriteLine(B);
                }
                if(i is DarkRide)
                {
                    DarkRide D = i as DarkRide;
                    Console.WriteLine(D);
                }
                if(i is RollerCoaster)
                {
                    RollerCoaster R = i as RollerCoaster;
                    Console.WriteLine(R);
                }
            }
        }


        //Afficher une partie du personnel ou des attractions
        static void Selection(Administration monAdmi, string chemin)
        {

            Console.WriteLine("1- Afficher un type d'attraction\n2- Afficher un types de monstre ");
            int choix = -1;

            while (choix != 1 && choix != 2 && choix != 3 && choix != 4 && choix != 5) { try { choix = int.Parse(Console.ReadLine()); } catch (InvalidCastException e) { Console.WriteLine(e.Message); } }

            switch (choix)
            {
                case 1:
                    Console.WriteLine("");
                    List<Attraction>maliste1=monAdmi.SelectionAttraction();
                    AfficherAttraction(maliste1);

                    File.Delete(chemin + "/liste_attractions.csv");//On supprime le fichier déjà existant

                    StreamWriter nouveau_fichier1 = new StreamWriter(chemin+"/liste_attractions.csv");

                    for(int i=0; i<maliste1.Count; i++)
                    {
                        nouveau_fichier1.WriteLine(maliste1[i].ToString());
                    }

                    nouveau_fichier1.Close();
                    Console.WriteLine("");
                    break;
                    
               case 2:
                    Console.WriteLine("");
                    List<Personnel> maliste2 = monAdmi.SelectionPersonnel();
                    AfficherPersonnel(maliste2);

                    File.Delete(chemin + "/liste_personnel.csv");//On supprime le fichier déjà existant

                    StreamWriter nouveau_fichier2 = new StreamWriter(chemin+"/liste_personnel.csv");
                    
                    for (int i = 0; i < maliste2.Count; i++)
                    {
                        nouveau_fichier2.WriteLine(maliste2[i].ToString());
                    }

                    nouveau_fichier2.Close();
                    Console.WriteLine("");
                    break;
            }
        }


        //Menu
        static void Menu(Administration monAdmi, string chemin)
        {
            Console.WriteLine("");
            Console.WriteLine("-------- Bienvenu dans le logiciel de gestion du parc ZOMBELIUM --------");
            Console.WriteLine("");

            Console.WriteLine("Quel operation voulez vous effectuer ? :");
            Console.WriteLine("");

            Console.WriteLine("1- Ajouter une attraction\n2- Ajouter un membre au personnel\n3- Afficher toutes attractions du parc\n4- Afficher tout les membres du personnel du parc" +
                "\n5- Afficher un ensemble particulier\n6- Quitter le menu ");
            int choix = -1;

            while (choix != 1 && choix != 2 && choix != 3 && choix != 4 && choix != 5 && choix != 6) { try { choix = int.Parse(Console.ReadLine()); } catch (InvalidCastException e) { Console.WriteLine(e.Message); } }

            switch (choix)
            {
                case 1:
                    Console.WriteLine("");
                    monAdmi.MainAjouterAttraction();
                    Menu(monAdmi, chemin);
                    Console.WriteLine("");
                    break;
                case 2:
                    Console.WriteLine("");
                    monAdmi.MainAjouterPersonnel();
                    Menu(monAdmi, chemin);
                    Console.WriteLine("");
                    break;
                case 3:
                    Console.WriteLine("");
                    AfficherAttraction(monAdmi.Attractions);
                    Menu(monAdmi, chemin);
                    Console.WriteLine("");
                    break;
                case 4:
                    Console.WriteLine("");
                    AfficherPersonnel(monAdmi.ToutLePersonnel);
                    Menu(monAdmi, chemin);
                    Console.WriteLine("");
                    break;
                case 5:
                    Console.WriteLine("");
                    Selection(monAdmi,chemin);
                    Menu(monAdmi,chemin);
                    Console.WriteLine("");
                    break;
                case 6:
                    Console.WriteLine("");
                    Console.WriteLine("Vous quittez le menu !");
                    Console.WriteLine("");
                    break;


            }
        }

        public static void Main(string[] args)
            {

                string chemin = "/Users/johann/Documents/ProgrammationobjetetinterfaceC#/PFRPOO/PFRPOO";

                Administration monAdmi = LectureFichierExcel(chemin+"/Listing.csv");
                Menu(monAdmi,chemin);
            }



        }
    }

