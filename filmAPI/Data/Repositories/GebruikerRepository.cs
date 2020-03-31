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
    }
}
