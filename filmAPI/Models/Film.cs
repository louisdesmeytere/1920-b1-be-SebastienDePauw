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
        
        public int Jaar { get; set; }
        public int Minuten { get; set; }
        public string Categorie {get;set;}
        public Detail Detail { get; set; }

        public Film() { }

        public Film(string titel, int jaar, int minuten, string categorie, Detail detail) : this()
        {  
            Titel = titel;
            Jaar = jaar;
            Minuten = minuten;
            Categorie = categorie;
            Detail = detail;
        }

        public void AddActeur(Acteur acteur) => Detail.AddActeur(acteur);
        public void RemoveActeur(Acteur acteur) => Detail.RemoveActeur(acteur);
        public void UpdateActeur(Acteur acteur) => Detail.UpdateActeur(acteur);
        public Acteur GetActeurById(int id) => Detail.GetActeurById(id);

        public void AddRegisseur(Regisseur regisseur) => Detail.AddRegisseur(regisseur);
        public void RemoveRegisseur(Regisseur regisseur) => Detail.RemoveRegisseur(regisseur);
        public void UpdateRegisseur(Regisseur regisseur) => Detail.UpdateRegisseur(regisseur);
        public Regisseur GetRegisseurById(int id) => Detail.GetRegisseurById(id);

        public void AddRating(double rating) => Detail.AddRating(rating);

        internal void Update(Film film)
        {
            Titel = film.Titel;
            Jaar = film.Jaar;
            Minuten = film.Minuten;
            Categorie = film.Categorie;
            Detail.Update(film);
        }
    }
}
