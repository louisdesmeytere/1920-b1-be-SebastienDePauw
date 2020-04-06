using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace filmAPI.Models
{
    public class Gebruiker
    {
        private string _naam;
        private MailAddress _email;

        public int Id {get;set;}
        public DateTime Created { get; set; }
        public string Naam {
            get { return _naam; }
            set {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _naam = value;
                } else {
                    throw new ArgumentException("Naam mag niet leeg zijn.");
                }
            }
        }
        public string Email { 
            get { return _email.Address; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    try
                    {
                        _email = new MailAddress(value);
                    }
                    catch (FormatException)
                    {
                        throw new ArgumentException("Email addres heeft een verkeerd formaat.");
                    }
                }
                else
                {
                    throw new ArgumentException("Naam mag niet leeg zijn.");
                }
            }
        }
        public List<Film> WatchList { get;set; }

        public Gebruiker() {
            WatchList = new List<Film>();
            Created = DateTime.Now;
        }

        public Gebruiker(string naam, string email) : this()
        {
            Naam = naam;
            Email = email;
        }

        #region Methods
        public void AddFilmWatchlist(Film film) => WatchList.Add(film);

        public void RemoveFilmWatchList(Film film)
        {
            Film f = WatchList.Where(e => e.Id == film.Id).FirstOrDefault();
            if (f != null) WatchList.Remove(f);
        }

        public IEnumerable<Film> GetFilmWatchlistBy(string titel = null, string acteurNaam = null, string regisseurNaam = null)
        {
            var movies = WatchList.AsQueryable();
            if (!string.IsNullOrEmpty(titel))
                movies = movies.Where(r => r.Titel.IndexOf(titel, System.StringComparison.OrdinalIgnoreCase) >= 0);
            if (!string.IsNullOrEmpty(acteurNaam))
                movies = movies.Where(r => r.Acteurs.Any(i => i.Naam.Equals(acteurNaam, System.StringComparison.OrdinalIgnoreCase)));
            if (!string.IsNullOrEmpty(regisseurNaam))
                movies = movies.Where(r => r.Regisseurs.Any(i => i.Naam.Equals(regisseurNaam, System.StringComparison.OrdinalIgnoreCase)));
            return movies.OrderBy(r => r.Titel).ToList();
        }

        public IEnumerable<Film> GetAllFilms()
        {
            return WatchList;
        }

        public Film GetFilmWatchlistBy(int id)
        {
            return WatchList.FirstOrDefault(e => e.Id == id);
        }

        public void SetWatchlistFilm(int id, Film film) {
            int i = WatchList.IndexOf(WatchList.FirstOrDefault(e => e.Id == id));
            WatchList.RemoveAt(i);
            WatchList.Insert(i, film);
            //Film f = WatchList.FirstOrDefault(e => e.Id == id);
            //f.Update(film);
        }
        #endregion


    }
}
