using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using filmAPI.Models;

namespace filmAPI.Data.Repositories
{
    public class FilmRepository : IFilmRepository
    {
        public void Add(Film film)
        {
            throw new NotImplementedException();
        }

        public void Delete(Film film)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Film> GetAll()
        {
            throw new NotImplementedException();
        }

        public Film GetBy(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Film> GetByTitel(string titel = null)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public bool TryGetFilm(int id, out Film film)
        {
            throw new NotImplementedException();
        }

        public void Update(Film film)
        {
            throw new NotImplementedException();
        }
    }
}
