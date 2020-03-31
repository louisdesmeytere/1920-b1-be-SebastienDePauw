using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using filmAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace filmAPI.Data.Repositories
{
    public class GebruikerRepository : IGebruikerRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Gebruiker> _gebruiker;

        public GebruikerRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _gebruiker = dbContext.Gebruikers;
        }
        public void Add(Gebruiker gebruiker)
        {
            _context.Add(gebruiker);
        }

        public IEnumerable<Gebruiker> GetAll()
        {
            return _gebruiker.OrderBy(e => e.Naam).ToList();
        }

        public Gebruiker GetBy(string email)
        {
            return _gebruiker.Include(r => r.Ratings).ThenInclude(r => r.Film).Include(r => r.WatchList).ThenInclude(r => r.Film).SingleOrDefault(c => c.Email == email);
        }

        public Gebruiker GetBy(int id)
        {
            return _gebruiker.Include(r => r.Ratings).ThenInclude(r => r.Film).Include(r => r.WatchList).ThenInclude(r => r.Film).SingleOrDefault(c => c.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Gebruiker gebruiker)
        {
            _context.Update(gebruiker);
        }

        public IEnumerable<Film> GetAllFilmsWatchlist(Gebruiker gebruiker) {
           Gebruiker g = _gebruiker.Where(e => e.Id == gebruiker.Id).FirstOrDefault();
           return g.GetAllFilmsWatchList();
        }

        public Film GetFilmsWatchlist(Gebruiker gebruiker, int id)
        {
            Gebruiker g = _gebruiker.Where(e => e.Id == gebruiker.Id).FirstOrDefault();
            return g.GetFilmRatedOpId(id);
        }

        public void AddFilmsWatchlist(Gebruiker gebruiker, Film film) {
            Gebruiker g = _gebruiker.Where(e => e.Id == gebruiker.Id).FirstOrDefault();
            g.AddFilmWatchlist(film);
        }

        public void RemoveFilmsWatchlist(Gebruiker gebruiker, Film film)
        {
            Gebruiker g = _gebruiker.Where(e => e.Id == gebruiker.Id).FirstOrDefault();
            g.RemoveFilmWatchList(film);
        }

        public IEnumerable<Film> GetAllFilmsRating(Gebruiker gebruiker)
        {
            Gebruiker g = _gebruiker.Where(e => e.Id == gebruiker.Id).FirstOrDefault();
            return g.GetAllGeratedFilms();
        }

        public Film GetFilmsRating(Gebruiker gebruiker, int id)
        {
            Gebruiker g = _gebruiker.Where(e => e.Id == gebruiker.Id).FirstOrDefault();
            return g.GetFilmRatedOpId(id);
        }

        public void RemoveFilmsRating(Gebruiker gebruiker, Film film)
        {
            Gebruiker g = _gebruiker.Where(e => e.Id == gebruiker.Id).FirstOrDefault();
            g.RemoveRating(film);
        }
    }
}
