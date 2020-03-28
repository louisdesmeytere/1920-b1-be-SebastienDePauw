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
        private ICollection<Film> _watchlist;
        private ICollection<Film> _seenlist;
        private DateTime _created;
        private ICollection<Rating> _ratings;

        public int Id {
            get;set;
        }
        public DateTime Created {
            get { return _created; }
            set {
                if (value == null) {
                    _created = DateTime.Today;
                }
            }
        }
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
        public ICollection<Film> Watchlist {
            get { return _watchlist; }
            set
            {
                if (value == null)
                {
                    value = new List<Film>();
                }
                    _watchlist = value;
            }
        }
        public ICollection<Film> Seenlist {
            get { return _seenlist; }
            set
            {
                if (value == null) {
                    value = new List<Film>();
                }
                    _seenlist = value;
            }
        }
        public ICollection<Rating> Ratings {
            get { return _ratings; }
            set {
                if (value == null) {
                    value = new List<Rating>();
                }
                _ratings = value;
            }
        }

        public Gebruiker() {
        
        }

        public Gebruiker(string naam, string email, ICollection<Film>? watchlist = null, ICollection<Film>? seenlist = null, ICollection<Rating>? ratings = null)
        {
            Naam = naam;
            Email = email;
            Watchlist = watchlist;
            Seenlist = seenlist;
            Ratings = ratings;
            Created = DateTime.Now;
        }

        public void AddFilmWatchlist(Film film) => Watchlist.Add(film);
        public void AddFilmSeenList(Film film) => Seenlist.Add(film);
        public void AddRating(Rating rating) => Ratings.Add(rating);

        public void RemoveFilmWatchList(Film film) => Watchlist.Remove(film);
        public void RemoveFilmSeenList(Film film) => Seenlist.Remove(film);
        public void RemoveRating(Rating rating) => Ratings.Remove(rating);

        public IEnumerable<Film> GetFilmWatchedOpTitel(string titel) => Watchlist.Where(i => i.Titel.Equals(titel));
        public IEnumerable<Film> GetFilmSeenOpTitel(string titel) => Seenlist.Where(i => i.Titel.Equals(titel));
        public List<Film> GetAllRatingFilms() => Ratings.Select(r => r.Film).ToList();
    }
}
