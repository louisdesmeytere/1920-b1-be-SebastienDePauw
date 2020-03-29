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

        public void Delete(Film film)
        {
            _film.Remove(film);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public void Update(Film film)
        {
            _context.Update(film);
        }

        public IEnumerable<Film> GetAll()
        {
            return _film.OrderBy(e => e.Titel).Include(r => r.Acteurs).Include(r => r.Regisseurs).ToList();
        }

        public Film GetBy(int id)
        {
            return _film.Include(r => r.Acteurs).Include(r => r.Regisseurs).SingleOrDefault(e => e.Id == id);
        }

        public IEnumerable<Film> GetBy(string titel = null, string acteurNaam = null, string regisseurNaam = null)
        {
            var films = _film.Include(r => r.Acteurs).Include(r => r.Regisseurs).AsQueryable();
            if (!string.IsNullOrEmpty(titel))
                films = films.Where(r => r.Titel.IndexOf(titel) >= 0);
            if (!string.IsNullOrEmpty(acteurNaam))
                films = films.Where(r => r.Acteurs.Any(i => i.Naam.Equals(acteurNaam)));
            if (!string.IsNullOrEmpty(regisseurNaam))
                films = films.Where(r => r.Regisseurs.Any(i => i.Naam.Equals(acteurNaam)));
            return films.OrderBy(r => r.Titel).ToList();
        }

        public bool TryGetFilm(int id, out Film film)
        {
            film = _context.Films.Include(r => r.Acteurs).FirstOrDefault(t => t.Id == id);
            return film != null;
        }

        public IEnumerable<Film> GetBy(string titel = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Acteur> GetAllActeurs(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Acteur> GetActeurBy(string acteurNaam = null)
        {
            throw new NotImplementedException();
        }

        public Acteur GetActeurBy(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(Acteur acteur)
        {
            throw new NotImplementedException();
        }

        public void Delete(Acteur acteur)
        {
            throw new NotImplementedException();
        }
    }
}

