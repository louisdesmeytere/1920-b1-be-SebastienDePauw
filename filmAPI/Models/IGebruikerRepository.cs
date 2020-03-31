using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmAPI.Models
{
    public interface IGebruikerRepository
    {
        IEnumerable<Gebruiker> GetAll();
        Gebruiker GetBy(string email);
        Gebruiker GetBy(int id);
        void Add(Gebruiker gebruiker);
        void SaveChanges();
    }
}
