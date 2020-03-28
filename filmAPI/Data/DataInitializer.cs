using filmAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmAPI.Data
{
    public class DataInitializer
    {
        private readonly ApplicationDbContext _dbContext;

        public DataInitializer(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void initializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                Gebruiker tom =  new Gebruiker("Tom", "Tom@Hotmail.com");
                Gebruiker jan = new Gebruiker("Jan", "Jan@Hotmail.com");
                Gebruiker lisa = new Gebruiker("Lisa", "Lisa@Hotmail.com");
                Gebruiker jef = new Gebruiker("Jef", "Jef@Hotmail.com");
                Gebruiker bart = new Gebruiker("Bart", "Bart@Hotmail.com");
                Gebruiker geert = new Gebruiker("Geert", "Geert@Hotmail.com");
                Gebruiker julie = new Gebruiker("Julie", "Julie@Hotmail.com");
                Gebruiker lore = new Gebruiker("Lore", "Lore@Hotmail.com");

                Gebruiker[] gebr = new Gebruiker[] { tom, jan, lisa, jef, bart, geert, julie, lore };

                FilmMedewerker a = new FilmMedewerker("Jake Lloyd", new DateTime(1999, 12, 24), "Acteur",null, new DateTime(2017, 12, 24), "Anakin");
                FilmMedewerker b = new FilmMedewerker("Ewan McGregor", new DateTime(1979, 5, 1), "Acteur", "Gent", null, "Anakin");
                FilmMedewerker c = new FilmMedewerker("Jake Lloyd", new DateTime(1999, 12, 24), "Acteur", null, new DateTime(2000, 12, 24), "Anakin");
                FilmMedewerker d = new FilmMedewerker("Ewan McGregor", new DateTime(1979, 5, 1), "Acteur", null, null, "Anakin");
                FilmMedewerker e = new FilmMedewerker("Jake Lloyd", new DateTime(1999, 12, 24), "Acteur", "New York", new DateTime(1999, 12, 24), "Anakin");
                FilmMedewerker f = new FilmMedewerker("Ewan McGregor", new DateTime(1979, 5, 1), "Acteur", "Kopenhagen", null, "Anakin");
                FilmMedewerker g = new FilmMedewerker("Jake Lloyd", new DateTime(1999, 12, 24), "Acteur", null, null, "Anakin");
                FilmMedewerker h = new FilmMedewerker("Ewan McGregor", new DateTime(1979, 5, 1), "Acteur", "Denver", null, "Anakin");
                FilmMedewerker i = new FilmMedewerker("Jake Lloyd", new DateTime(1999, 12, 24), "Acteur", "Los Angeles", null, "Anakin");
                FilmMedewerker j = new FilmMedewerker("Ewan McGregor", new DateTime(1979, 5, 1), "Acteur", null, null, "Anakin");

                FilmMedewerker k = new FilmMedewerker("Jake Lloyd", new DateTime(1950, 4, 26), "Schrijver");
                FilmMedewerker l = new FilmMedewerker("Jake Lloyd", new DateTime(1950, 4, 26), "Schrijver");
                FilmMedewerker m = new FilmMedewerker("Jake Lloyd", new DateTime(1950, 4, 26), "Schrijver");
                FilmMedewerker n = new FilmMedewerker("Jake Lloyd", new DateTime(1950, 4, 26), "Schrijver");
                FilmMedewerker o = new FilmMedewerker("Jake Lloyd", new DateTime(1950, 4, 26), "Schrijver");

                FilmMedewerker p = new FilmMedewerker("Jake Lloyd", new DateTime(1969, 1, 17), "Regisseur");
                FilmMedewerker q = new FilmMedewerker("Jake Lloyd", new DateTime(1980, 10, 22), "Regisseur");
                FilmMedewerker r = new FilmMedewerker("Jake Lloyd", new DateTime(1969, 1, 17), "Regisseur");
                FilmMedewerker s = new FilmMedewerker("Jake Lloyd", new DateTime(1980, 10, 22), "Regisseur");
                FilmMedewerker t = new FilmMedewerker("Jake Lloyd", new DateTime(1969, 1, 17), "Regisseur");

                FilmMedewerker[] fm = new FilmMedewerker[] { a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t };


                Film starWars1 = new Film("Star Wars: Episode I: The Phantom Menace", "beschrijving", "story",1999,136, "siencefiction" , new List<FilmMedewerker> {a, b,c,d});
                Film starWars4 = new Film("Star Wars: Episode II: The Phantom", "beschrijving", "story", 2000, 136, "siencefiction" , new List<FilmMedewerker> { e,f,g,h });
                Film titanic = new Film("titanic", "beschrijving", "story", 2000, 136, "Avontuur", new List<FilmMedewerker> { i,j,k,l });
                Film ff = new Film("fast and furious", "beschrijving", "story", 2000, 136, "siencefiction" , new List<FilmMedewerker> {m,n,o,p });
                Film saw1 = new Film("Saw", "beschrijving", "story", 2000, 136, "Avontuur", new List<FilmMedewerker> { q,r,s,t});

                Film[] film = new Film[] { starWars1, starWars4, titanic, ff, saw1 };

                julie.AddFilmSeenList(ff);
                julie.AddFilmWatchlist(saw1);

                Rating rating = new Rating(10, julie, ff, "goede film");
                Rating rating1 = new Rating(5, tom,titanic, "saai");

                Rating[] rat = new Rating[] { rating,rating1 };

                _dbContext.Gebruikers.AddRange(gebr);
                _dbContext.FilmMedewerkers.AddRange(fm);
                _dbContext.Films.AddRange(film);
                _dbContext.Ratings.AddRange(rat);

                _dbContext.SaveChanges();
            }
        }
    }
}
