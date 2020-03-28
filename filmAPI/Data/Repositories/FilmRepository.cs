using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using filmAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace filmAPI.Data.Repositories
{
    public class FilmRepository : IFilmRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Film> _film;

        public FilmRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _film = dbContext.Films;
        }

        public void Add(Film film)
        {
            _film.Add(film);
        }

        public void Remove(Film film)
        {
            _film.Remove(film);
        }

        public IEnumerable<Film> GetAll()
        {
            return _film.Include(r => r.FilmMedewerker).Include(r => r.Ratings).ToList();
        }

        public Film GetBy(int id)
        {
            return _film.Include(r => r.FilmMedewerker).Include(r => r.Ratings).SingleOrDefault(e => e.Id == id) ;
        }

        public IEnumerable<Film> GetByTitel(string titel)
        {
            return _film.Where(e => e.Titel.Contains(titel.Trim())).Include(r => r.FilmMedewerker).Include(r => r.Ratings).ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public bool TryGetFilm(int id, out Film film)
        {
            film = _context.Films.Include(r => r.FilmMedewerker).Include(r => r.Ratings).FirstOrDefault(t => t.Id == id);
            return film != null;
        }

        public void Update(Film film)
        {
            _context.Update(film);
        }
    }
}

