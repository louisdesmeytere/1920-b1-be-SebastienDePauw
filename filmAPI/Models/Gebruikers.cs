using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace filmAPI.Models
{
    public class Gebruikers
    {
        private string _naam;
        private MailAddress _email;
        private List<Film> _watchlist;
        private List<Film> _seenlist;

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
                try
                {
                    _watchlist = value;
                }
                catch (Exception e) {
                    Console.Out.WriteLine(e.Message);
                }
            }
        }
        public List<Film> Seenlist {
            get { return _seenlist; }
            set
            {
                if (value == null) {
                    value = new List<Film>();
                }
                try
                {
                    _seenlist = value;
                }
                catch (Exception e)
                {
                    Console.Out.WriteLine(e.Message);
                }
            }
        }

        public Gebruikers(string naam, string email,  List<Film>? watchlist = null, List<Film>? seenlist = null)
        {
            Naam = naam;
            Email = email;
            Watchlist = watchlist;
            Seenlist = seenlist;
        }
    }
}
