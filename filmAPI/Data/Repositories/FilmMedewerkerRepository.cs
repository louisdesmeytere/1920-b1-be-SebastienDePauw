using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using filmAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace filmAPI.Data.Repositories
{
    public class FilmMedewerkerRepository : IFilmMedewerkerRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<FilmMedewerker> _filmmw;

        public FilmMedewerkerRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _filmmw = dbContext.FilmMedewerkers;
        }

        public void Add(FilmMedewerker filmMedewerker)
        {
            _filmmw.Add(filmMedewerker);
        }

        public void Remove(FilmMedewerker filmMedewerker)
        {
            _filmmw.Remove(filmMedewerker);
        }

        public IEnumerable<FilmMedewerker> GetAll()
        {
            return _filmmw.ToList();
        }

        public FilmMedewerker GetBy(int id)
        {
            return _filmmw.SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<FilmMedewerker> GetByType(string type)
        {
            return _filmmw.Where(r => r.Type == type).ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public bool TryGetFilm(int id, out FilmMedewerker filmMedewerker)
        {
            filmMedewerker = _context.FilmMedewerkers.FirstOrDefault(t => t.Id == id);
            return filmMedewerker != null;
        }

        public void Update(FilmMedewerker filmMedewerker)
        {
            _context.Update(filmMedewerker);
        }
    }
}
