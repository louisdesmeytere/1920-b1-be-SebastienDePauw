﻿using System;
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
        public List<WatchListItem> WatchList { get;set; }
        public ICollection<Rating> Ratings { get; set; }

        public Gebruiker() {
            WatchList = new List<WatchListItem>();
            Ratings = new List<Rating>();
            Created = DateTime.Now;
        }

        public Gebruiker(string naam, string email) : this()
        {
            Naam = naam;
            Email = email;
        }

        public Dictionary<Film, double> GetMijnRatings() {
            var map = new Dictionary<Film, double>();
            List<Rating> ratings = new List<Rating>(Ratings);
            ratings.ForEach(e => map.Add(e.Film, e.Score));
            return map;
        }

        public List<Film> GetMijnWatchList()
        {
            List<Film> watchlist = new List<Film>();
            WatchList.ForEach(e => watchlist.Add(e.Film));
            return watchlist;
        }

        public void AddFilmWatchlist(Film film) => WatchList.Add(new WatchListItem() { FilmId = film.Id, GebruikerId = Id, Film = film, Gebruiker = this});
        public void AddRating(Film film, double score) =>  Ratings.Add(new Rating() { FilmId = film.Id, GebruikerId = Id, Film = film, Gebruiker = this, Score = score });

        public void RemoveFilmWatchList(Film film) => WatchList.Where(e => e.GebruikerId == Id && e.FilmId == film.Id).ToList().ForEach(e => WatchList.Remove(e));
        public void RemoveRating(Film film) => Ratings.Where(e => e.GebruikerId == Id && e.FilmId == film.Id).ToList().ForEach(e => Ratings.Remove(e)); 

        public Film GetFilmsWatchedOpId(int id) => WatchList.Select(r => r.Film).Where(i => i.Id == id).FirstOrDefault();
        public Film GetFilmRatedOpId(int id) => Ratings.Select(r => r.Film).Where(i => i.Id == id).FirstOrDefault();

        public List<Film> GetAllFilmsWatchList() => WatchList.Where(e => e.GebruikerId == Id).Select(r => r.Film).ToList();
        public List<Film> GetAllGeratedFilms() => Ratings.Where(e => e.GebruikerId == Id).Select(r => r.Film).ToList();


    }
}
