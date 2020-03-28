using filmAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmAPI.Data.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Rating> _rating;

        public RatingRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _rating = dbContext.Ratings;
        }
        public void Add(Rating rating)
        {
            _context.Add(rating);
        }

        public IEnumerable<Rating> GetAll()
        {
            throw new NotImplementedException();
        }

        public Rating GetBy(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Rating> GetBy(Film film)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Rating> GetBy(Gebruiker gebruiker)
        {
            throw new NotImplementedException();
        }

        public void Remove(Rating rating)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Rating rating)
        {
            _context.Update(rating);
        }
    }
}
