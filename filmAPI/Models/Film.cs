using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace filmAPI.Models
{
    public class Film
    {
        public int Id { get; set; }
        [Required]
        public string Titel { get; set; }
        public string Beschrijving { get; set; }
        public string Storyline { get; set; }
        public int Jaar { get; set; }
        public int Minuten { get; set; }
        public string Categorie {get;set;}
        public ICollection<Acteur> Acteurs { get; private set; }
        public Regisseur Regisseur { get; set; }

        public Film() {
            Acteurs = new List<Acteur>();
        }

        public Film(string titel, string beschrijving, string storyline, int jaar, int minuten, string categorie)
        {
            Titel = titel;
            Beschrijving = beschrijving;
            Storyline = storyline;
            Jaar = jaar;
            Minuten = minuten;
            Categorie = categorie;
        }

        public void AddActeur(Acteur acteur) => Acteurs.Add(acteur);

        public void RemoveActeur (Acteur acteur) => Acteurs.Remove(acteur);

        public Acteur GetActeurById(int id) => Acteurs.SingleOrDefault(i => i.Id == id);

        public void SetRegisseur(Regisseur regisseur) {
            Regisseur = regisseur;
        }

    }
}
