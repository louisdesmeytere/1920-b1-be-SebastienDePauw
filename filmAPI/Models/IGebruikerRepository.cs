using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmAPI.Models
{
    public interface IGebruikerRepository
    {
        IEnumerable<Gebruiker> GetAll();
        IEnumerable<Gebruiker> GetAllRatings();
        IEnumerable<Gebruiker> GetAllFilms();
        Gebruiker GetBy(string email);
        void Add(Gebruiker gebruiker);
        void SaveChanges();
    }
}
