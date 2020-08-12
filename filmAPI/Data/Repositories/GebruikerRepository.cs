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
            Gebruiker g = _gebruiker.Include(e => e.WatchList).ThenInclude(e => e.Detail).ThenInclude(e => e.Acteurs).Include(e => e.WatchList).ThenInclude(e => e.Detail).ThenInclude(e => e.Regisseurs).SingleOrDefault(c => c.Email == email);
            return g;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Gebruiker gebruiker)
        {
            _context.Update(gebruiker);
        }


        /*

        public Film GetFilmsWatchedOpId(int id) => WatchList.Where(i => i.Id == id).FirstOrDefault();
        public Film GetFilmRatedOpId(int id) => Ratings.Select(r => r.Film).Where(i => i.Id == id).FirstOrDefault();

        public List<Film> GetAllFilmsWatchList() => WatchList.OrderBy(e => e.Titel).ToList();
        public List<Film> GetAllGeratedFilms() => Ratings.Where(e => e.GebruikerId == Id).Select(r => r.Film).OrderBy(e => e.Titel).ToList();

        
                public IEnumerable<Gebruiker> GetAll()
        {
            return _gebruiker.OrderBy(e => e.Naam).ToList();
        }

          public Gebruiker GetBy(int id)
           {
               return _gebruiker.Include(r => r.Ratings).ThenInclude(r => r.Film).Include(r => r.WatchList).ThenInclude(r => r.Film).SingleOrDefault(c => c.Id == id);
           }

         public IEnumerable<Film> GetAllFilmsWatchlist(Gebruiker gebruiker) {
            Gebruiker g = _gebruiker.Where(e => e.Id == gebruiker.Id).FirstOrDefault();
            return g.GetAllFilmsWatchList();
         }

         public Film GetFilmsWatchlist(Gebruiker gebruiker, int id)
         {
             Gebruiker g = _gebruiker.Where(e => e.Id == gebruiker.Id).FirstOrDefault();
             return g.GetFilmRatedOpId(id);
         }

         public void AddFilmsWatchlist(Gebruiker gebruiker, Film film) {
             Gebruiker g = _gebruiker.Where(e => e.Id == gebruiker.Id).FirstOrDefault();
             g.AddFilmWatchlist(film);
         }

         public void RemoveFilmsWatchlist(Gebruiker gebruiker, Film film)
         {
             Gebruiker g = _gebruiker.Where(e => e.Id == gebruiker.Id).FirstOrDefault();
             g.RemoveFilmWatchList(film);
         }

         public IEnumerable<Film> GetAllFilmsRating(Gebruiker gebruiker)
         {
             Gebruiker g = _gebruiker.Where(e => e.Id == gebruiker.Id).FirstOrDefault();
             return g.GetAllGeratedFilms();
         }

         public Film GetFilmsRating(Gebruiker gebruiker, int id)
         {
             Gebruiker g = _gebruiker.Where(e => e.Id == gebruiker.Id).FirstOrDefault();
             return g.GetFilmRatedOpId(id);
         }

         public void RemoveFilmsRating(Gebruiker gebruiker, Film film)
         {
             Gebruiker g = _gebruiker.Where(e => e.Id == gebruiker.Id).FirstOrDefault();
             g.RemoveRating(film);
         }

         public void AddFilmWatchlist(Gebruiker gebruiker, Film film)
         {
             Gebruiker g = _gebruiker.Where(e => e.Id == gebruiker.Id).FirstOrDefault();
             g.AddFilmWatchlist(film);
         }

         public void AddFilmRating(Gebruiker gebruiker, Film film)
         {
             Gebruiker g = _gebruiker.Where(e => e.Id == gebruiker.Id).FirstOrDefault();
             g.AddFilmWatchlist(film);
         }

         public IEnumerable<Film> GetFilmWatchlistBy(string titel = null, string acteurNaam = null, string regisseurNaam = null)
         {
             var films = _film.Include(r => r.Acteurs).Include(r => r.Regisseurs).AsQueryable();
             if (!string.IsNullOrEmpty(titel))
                 films = films.Where(r => r.Titel.IndexOf(titel) >= 0);
             if (!string.IsNullOrEmpty(acteurNaam))
                 films = films.Where(r => r.Acteurs.Any(i => i.Naam.Equals(acteurNaam)));
             if (!string.IsNullOrEmpty(regisseurNaam))
                 films = films.Where(r => r.Regisseurs.Any(i => i.Naam.Equals(acteurNaam)));
             return films.OrderBy(r => r.Titel).ToList();
         }*/
    }
}
