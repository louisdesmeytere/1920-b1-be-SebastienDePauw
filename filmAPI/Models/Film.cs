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
        public double? Rating { get; set; }
        [Required]
        public ICollection<Acteur> Acteurs { get; private set; }
        [Required]
        public ICollection<Regisseur> Regisseurs { get; set; }


        public Film() {
            Acteurs = new List<Acteur>();
            Regisseurs = new List<Regisseur>();
        }

        public Film(string titel, string beschrijving, string storyline, int jaar, int minuten, string categorie) : this()
        {
            Titel = titel;
            Beschrijving = beschrijving;
            Storyline = storyline;
            Jaar = jaar;
            Minuten = minuten;
            Categorie = categorie;
        }

        public Film(string titel, string beschrijving, string storyline, int jaar, int minuten, string categorie, double rating) : this(titel,beschrijving, storyline, jaar, minuten, categorie)
        {
            Rating = rating;
        }

        public void AddActeur(Acteur acteur) => Acteurs.Add(acteur);
        public void RemoveActeur (Acteur acteur) => Acteurs.Remove(acteur);
        public void UpdateActeur(Acteur acteur) => Acteurs.Where(a => a.Id == acteur.Id).ToList().ForEach(s => s = acteur);
        public Acteur GetActeurById(int id) => Acteurs.SingleOrDefault(i => i.Id == id);

        public void AddRegisseur(Regisseur regisseur) => Regisseurs.Add(regisseur);
        public void RemoveRegisseur(Regisseur regisseur) => Regisseurs.Remove(regisseur);
        public void UpdateRegisseur(Regisseur regisseur) => Regisseurs.Where(a => a.Id == regisseur.Id).ToList().ForEach(s => s = regisseur);
        public Regisseur GetRegisseurById(int id) => Regisseurs.SingleOrDefault(i => i.Id == id);
        
        public void AddRating(double rating) =>  Rating = rating;
    }
}
