using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProjetS6
{
    public class Personnel
    {


        private string function;
        private int matricule;
        private string nom;
        private string prenom;
        private Typesexe sexe;

        public Personnel (){}
       

        public Personnel(string function, int matricule, string nom, string prenom, Typesexe sexe)
        {
            this.Function = function;
            this.Matricule = matricule;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Sexe = sexe;
        }

        public string Function { get => function; set => function = value; }
        public int Matricule { get => matricule; set => matricule = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public Typesexe Sexe { get => sexe; set => sexe = value; }

        public override string ToString()
        {
            return string.Format("Function={0} \nMatricule={1}\nNom={2}\nPrenom={3}", Function, Matricule, Nom, Prenom);
        }

        


    }
}
