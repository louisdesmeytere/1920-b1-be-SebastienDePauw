using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace filmAPI.Models
{
    public class Gebruiker
    {
        private int _id;
        private string _naam;
        private MailAddress _email;
        private List<Film> _watchlist;
        private List<Film> _seenlist;
        private DateTime _created;
        private ICollection<Rating> _ratings;

        public int Id {
            get { return _id; }
            set {
                _id = value;
            }
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
        public List<Film> Watchlist {
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
        public List<Film> Seenlist {
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

        public Gebruiker(string naam, string email, List<Film>? watchlist = null, List<Film>? seenlist = null, ICollection<Rating>? ratings = null)
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

        public List<Film> GetFilmWatchedOpTitel(String titel) => Watchlist.FindAll(i => i.Titel.Equals(titel));
        public List<Film> GetFilmSeenOpTitel(String titel) => Seenlist.FindAll(i => i.Titel.Equals(titel));
    }
}
