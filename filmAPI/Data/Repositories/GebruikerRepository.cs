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

        public IEnumerable<Gebruiker> GetAllRatings() {
            return _gebruiker.OrderBy(e => e.Naam).Include(c => c.Ratings).ThenInclude(f => f.Film).ThenInclude(e => e.Acteurs).ToList();
        }

        public IEnumerable<Gebruiker> GetAllFilms()
        {
            return _gebruiker.OrderBy(e => e.Naam).Include(c => c.WatchList).ThenInclude(f => f.Film).ThenInclude(e => e.Acteurs).ToList();
        }

        public Gebruiker GetBy(string email)
        {
            return _gebruiker.Include(c => c.Ratings).ThenInclude(f => f.Film).Include(c => c.WatchList).ThenInclude(f => f.Film).SingleOrDefault(c => c.Email == email);
        }


        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
