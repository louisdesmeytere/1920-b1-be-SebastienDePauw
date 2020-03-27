using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmAPI.Models
{
    interface IGebruikerRepository
    {
        Gebruiker GetBy(int id);
        void Add(Gebruiker gebruiker);
        void Update(Gebruiker gebruiker);
        void SaveChanges();
    }
}
