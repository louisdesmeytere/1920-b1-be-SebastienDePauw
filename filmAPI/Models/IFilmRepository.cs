using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmAPI.Models
{
    public interface IFilmRepository
    {
        IEnumerable<Film> GetAll();
        Film GetBy(int id);
        void Update(Film film);
        void Delete(Film film);
        void SaveChanges();
    }
}
