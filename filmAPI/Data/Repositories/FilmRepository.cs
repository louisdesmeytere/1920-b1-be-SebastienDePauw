using filmAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmAPI.Data.Repositories
{
    public class FilmRepository : IFilmRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Film> _film;
        public FilmRepository(ApplicationDbContext dbContext) {
            _context = dbContext;
            _film = dbContext.Films;
        }

        public Film GetBy(int id)
        {
            Film f = _film.Include(e => e.Detail).ThenInclude(e => e.Acteurs).Include(e => e.Detail).ThenInclude(e => e.Regisseurs).SingleOrDefault(c => c.Id == id);
            return f;
        }

        public IEnumerable<Film> GetAll() {
            return _film.Include(e => e.Detail).ThenInclude(e => e.Acteurs).Include(e => e.Detail).ThenInclude(e => e.Regisseurs);
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
    }
}
