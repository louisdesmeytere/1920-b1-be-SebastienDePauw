using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmAPI.Models
{
    public interface IFilmRepository
    {
        #region Film
        Film GetBy(int id);
        bool TryGetFilm(int id, out Film film);
        IEnumerable<Film> GetAll();
        IEnumerable<Film> GetBy(string titel = null);
        void Add(Film film);
        void Delete(Film film);
        void Update(Film film);
        #endregion

        #region Acteur
        IEnumerable<Acteur> GetAllActeurs(int id);
        IEnumerable<Acteur> GetActeurBy(string acteurNaam = null);
        Acteur GetActeurBy(int id);
        void Add(Acteur acteur);
        void Delete(Acteur acteur);
        #endregion

        void SaveChanges();
    }
}
