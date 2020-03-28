using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmAPI.Models
{
    public interface IFilmRepository
    {
        Film GetBy(int id);
        bool TryGetFilm(int id, out Film film);
        IEnumerable<Film> GetAll();
        IEnumerable<Film> GetByTitel(string titel);
        void Add(Film film);
        void Remove(Film film);
        void Update(Film film);
        void SaveChanges();
    }
}
