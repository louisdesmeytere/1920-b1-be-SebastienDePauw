using filmAPI.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace filmAPI.Data
{
    public class DataInitializer
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public DataInitializer(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task initializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                Film eg = new Film("End Game", "Beschrijving", "Korte inhoud", 2019, 181, "Actie/Sciencefiction");
                Acteur evans = new Acteur("Chris Evans", new DateTime(1981, 6, 13));
                Acteur junior = new Acteur("Robert Downey jr.", new DateTime(1965, 4, 4));
                Acteur hemsworth = new Acteur("Chris Hemsworth", new DateTime(1983, 8, 11));
                Acteur cooper = new Acteur("Bradley Cooper", new DateTime(1975, 1, 5));
                Acteur ruffalo = new Acteur("Mark Ruffalo", new DateTime(1967, 11, 22));
                Acteur johansson = new Acteur("Scarlett Johansson", new DateTime(1984, 11, 22));
                Acteur renner = new Acteur("Jeremy Renner", new DateTime(1971, 1, 7));
                Acteur rudd = new Acteur("Paul Rudd", new DateTime(1969, 4, 6));
                Regisseur ar = new Regisseur("Anthony Russo", new DateTime(1970, 2, 3));
                Regisseur jr = new Regisseur("Joe Russo", new DateTime(1971, 7, 19));
                eg.AddActeur(evans);
                eg.AddActeur(junior);
                eg.AddActeur(hemsworth);
                eg.AddActeur(cooper);
                eg.AddActeur(ruffalo);
                eg.AddActeur(johansson);
                eg.AddActeur(renner);
                eg.AddActeur(rudd);
                eg.AddRegisseur(ar);
                eg.AddRegisseur(jr);
                _dbContext.Add(eg);

                Film pf = new Film("Pulp Fiction", "Beschrijving", "Korte inhoud", 1994,154,"Misdaad");
                Acteur jackson = new Acteur("Samuel L. Jackson", new DateTime(1948, 12, 21));
                Acteur willis = new Acteur("Bruce Willis", new DateTime(1955, 3, 19));
                Acteur travolta = new Acteur("John Travolta", new DateTime(1954, 2, 18));
                Regisseur tarantino = new Regisseur("Quentin Tarantino", new DateTime(1963, 3, 27));
                pf.AddActeur(jackson);
                pf.AddActeur(willis);
                pf.AddActeur(travolta);
                pf.AddRegisseur(tarantino);
                _dbContext.Add(pf);

                Film joker = new Film("Joker", "Beschrijving", "Korte inhoud", 2019, 122, "Misdaad");
                Acteur phoenix = new Acteur("Joaquin Phoenix", new DateTime(1974, 10, 28));
                Acteur niro = new Acteur("Robert De Niro", new DateTime(1943, 8, 17));
                Regisseur phillips = new Regisseur("Todd Phillips", new DateTime(1970, 12, 5));
                joker.AddActeur(phoenix);
                joker.AddActeur(niro);
                joker.AddRegisseur(phillips);
                _dbContext.Add(joker);

                Gebruiker jan = new Gebruiker("Jan Deprof","jan@msn.com");
                _dbContext.Gebruikers.Add(jan);
                await CreateUser(jan.Email, "P@ssword1");

                Gebruiker seba = new Gebruiker("Sebastien De Pauw", "Sebastien@hotmail.be");
                seba.AddRating(eg, 7);
                seba.AddRating(joker, 9.2);
                seba.AddRating(pf, 9.6);
                _dbContext.Gebruikers.Add(seba);
                await CreateUser(seba.Email, "P@ssword1");

                Gebruiker piet = new Gebruiker("Piet Decoster", "piet@gmail.com");
                piet.AddRating(eg, 9);
                piet.AddRating(joker, 8);
                piet.AddRating(pf, 8.3);
                piet.AddFilmWatchlist(eg);
                piet.AddFilmWatchlist(joker);
                piet.AddFilmWatchlist(pf);
                _dbContext.Gebruikers.Add(piet);
                await CreateUser(piet.Email, "P@ssword1");

                Gebruiker tom = new Gebruiker("Tom Verbruggen", "tom@telenet.be");
                tom.AddFilmWatchlist(eg);
                tom.AddFilmWatchlist(joker);
                tom.AddFilmWatchlist(pf);
                _dbContext.Gebruikers.Add(tom);
                await CreateUser(tom.Email, "P@ssword1");

                _dbContext.SaveChanges();
            }
        }
        private async Task CreateUser(string email, string password)
        {
            var gebruiker = new IdentityUser { UserName = email, Email = email };
            await _userManager.CreateAsync(gebruiker, password);
        }
    }
}
