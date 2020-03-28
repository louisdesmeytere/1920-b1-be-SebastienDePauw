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

        public Gebruiker GetBy(int id)
        {
           return _gebruiker.Include(r => r.Ratings).Include(r => r.Seenlist).Include(r => r.Watchlist).SingleOrDefault(e => e.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Gebruiker gebruiker)
        {
            _context.Update(gebruiker);
        }
    }
}
