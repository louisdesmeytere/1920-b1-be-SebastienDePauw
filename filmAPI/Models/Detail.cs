using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace filmAPI.Models
{
    public class Detail
    {
        public int Id { get; private set; }
        public string Beschrijving { get; set; }
        public string Storyline { get; set; }
        public double Rating { get; set; }
        [Required]
        public List<Acteur> Acteurs { get; private set; }
        [Required]
        public List<Regisseur> Regisseurs { get; private set; }

        public Detail (){
            Acteurs = new List<Acteur>();
            Regisseurs = new List<Regisseur>();
        }

        public Detail(string beschrijving, string storyline) : this()
        {
            Beschrijving = beschrijving;
            Storyline = storyline;
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

        internal void Update(Film film)
        {
            Beschrijving = film.Detail.Beschrijving;
            Storyline = film.Detail.Storyline;
            Rating = film.Detail.Rating;
            film.Detail.Acteurs.ForEach(e => UpdateActeur(e));
            film.Detail.Regisseurs.ForEach(e => UpdateRegisseur(e));
        }
    }
}
