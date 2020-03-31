using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmAPI.Models
{
    public interface IGebruikerRepository
    {
        IEnumerable<Gebruiker> GetAll();
        Gebruiker GetBy(string email);
        Gebruiker GetBy(int id);
        void Add(Gebruiker gebruiker);
        void Update(Gebruiker gebruiker);
        public IEnumerable<Film> GetAllFilmsWatchlist(Gebruiker gebruiker);
        public Film GetFilmsWatchlist(Gebruiker gebruiker, int id);
        public void RemoveFilmsWatchlist(Gebruiker gebruiker, Film film);
        public IEnumerable<Film> GetAllFilmsRating(Gebruiker gebruiker);
        public Film GetFilmsRating(Gebruiker gebruiker, int id);
        public void RemoveFilmsRating(Gebruiker gebruiker, Film film);
        void SaveChanges();
    }
}
