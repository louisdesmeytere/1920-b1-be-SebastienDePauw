using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmAPI.Models
{
    public interface IRatingRepository
    {
        Rating GetBy(int id);
        IEnumerable<Rating> GetAll();
        IEnumerable<Rating> GetBy(Film film);
        IEnumerable<Rating> GetBy(Gebruiker gebruiker);
        void Add(Rating rating);
        void Remove(Rating rating);
        void Update(Rating rating);
        void SaveChanges();

    }
}
