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

        public Gebruiker GetBy(string email)
        {
            return _gebruiker.Include(c => c.Ratings).ThenInclude(f => f.Film).ThenInclude(r => r.Acteurs).SingleOrDefault(c => c.Email == email);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
