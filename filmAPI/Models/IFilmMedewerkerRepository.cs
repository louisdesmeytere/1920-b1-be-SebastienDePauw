using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmAPI.Models
{
    public interface IFilmMedewerkerRepository
    {
        FilmMedewerker GetBy(int id);
        bool TryGetFilm(int id, out FilmMedewerker filmMedewerker);
        IEnumerable<FilmMedewerker> GetAll();
        IEnumerable<FilmMedewerker> GetByType(string type);
        void Add(FilmMedewerker filmMedewerker);
        void Remove(FilmMedewerker filmMedewerker);
        void Update(FilmMedewerker filmMedewerker);
        void SaveChanges();
    }
}
