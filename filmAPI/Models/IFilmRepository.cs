using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmAPI.Models
{
    public interface IFilmRepository
    {
        bool TryGetFilm(int id, out Film film);
        IEnumerable<Film> GetAll();
        Film GetBy(int id);
        IEnumerable<Film> GetBy(string titel = null, string acteurNaam = null, string RegisseurNaam = null);
        void Add(Film film);
        void Delete(Film film);
        void Update(Film film);
        void SaveChanges();
    }
}
