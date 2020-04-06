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
                Film eg1 = new Film("End Game", "Beschrijving", "Korte inhoud", 2019, 181, "Actie/Sciencefiction",8.9);
                Acteur evans1 = new Acteur("Chris Evans", new DateTime(1981, 6, 13));
                Acteur junior1 = new Acteur("Robert Downey jr.", new DateTime(1965, 4, 4));
                Acteur hemsworth1 = new Acteur("Chris Hemsworth", new DateTime(1983, 8, 11));
                Acteur cooper1 = new Acteur("Bradley Cooper", new DateTime(1975, 1, 5));
                Acteur ruffalo1 = new Acteur("Mark Ruffalo", new DateTime(1967, 11, 22));
                Acteur johansson1 = new Acteur("Scarlett Johansson", new DateTime(1984, 11, 22));
                Acteur renner1 = new Acteur("Jeremy Renner", new DateTime(1971, 1, 7));
                Acteur rudd1 = new Acteur("Paul Rudd", new DateTime(1969, 4, 6));
                Regisseur ar1 = new Regisseur("Anthony Russo", new DateTime(1970, 2, 3));
                Regisseur jr1 = new Regisseur("Joe Russo", new DateTime(1971, 7, 19));
                eg1.AddActeur(evans1);
                eg1.AddActeur(junior1);
                eg1.AddActeur(hemsworth1);
                eg1.AddActeur(cooper1);
                eg1.AddActeur(ruffalo1);
                eg1.AddActeur(johansson1);
                eg1.AddActeur(renner1);
                eg1.AddActeur(rudd1);
                eg1.AddRegisseur(ar1);
                eg1.AddRegisseur(jr1);

                Film eg2 = new Film("End Game", "Beschrijving", "Korte inhoud", 2019, 181, "Actie/Sciencefiction",7.5);
                Acteur evans2 = new Acteur("Chris Evans", new DateTime(1981, 6, 13));
                Acteur junior2 = new Acteur("Robert Downey jr.", new DateTime(1965, 4, 4));
                Acteur hemsworth2 = new Acteur("Chris Hemsworth", new DateTime(1983, 8, 11));
                Acteur cooper2 = new Acteur("Bradley Cooper", new DateTime(1975, 1, 5));
                Acteur ruffalo2 = new Acteur("Mark Ruffalo", new DateTime(1967, 11, 22));
                Acteur johansson2 = new Acteur("Scarlett Johansson", new DateTime(1984, 11, 22));
                Acteur renner2 = new Acteur("Jeremy Renner", new DateTime(1971, 1, 7));
                Acteur rudd2 = new Acteur("Paul Rudd", new DateTime(1969, 4, 6));
                Regisseur ar2 = new Regisseur("Anthony Russo", new DateTime(1970, 2, 3));
                Regisseur jr2 = new Regisseur("Joe Russo", new DateTime(1971, 7, 19));
                eg2.AddActeur(evans2);
                eg2.AddActeur(junior2);
                eg2.AddActeur(hemsworth2);
                eg2.AddActeur(cooper2);
                eg2.AddActeur(ruffalo2);
                eg2.AddActeur(johansson2);
                eg2.AddActeur(renner2);
                eg2.AddActeur(rudd2);
                eg2.AddRegisseur(ar2);
                eg2.AddRegisseur(jr2);

                Film pf1 = new Film("Pulp Fiction", "Beschrijving", "Korte inhoud", 1994,154,"Misdaad",6.5);
                Acteur jackson1 = new Acteur("Samuel L. Jackson", new DateTime(1948, 12, 21));
                Acteur willis1 = new Acteur("Bruce Willis", new DateTime(1955, 3, 19));
                Acteur travolta1 = new Acteur("John Travolta", new DateTime(1954, 2, 18));
                Regisseur tarantino1 = new Regisseur("Quentin Tarantino", new DateTime(1963, 3, 27));
                pf1.AddActeur(jackson1);
                pf1.AddActeur(willis1);
                pf1.AddActeur(travolta1);
                pf1.AddRegisseur(tarantino1);

                Film pf2 = new Film("Pulp Fiction", "Beschrijving", "Korte inhoud", 1994, 154, "Misdaad");
                Acteur jackson2 = new Acteur("Samuel L. Jackson", new DateTime(1948, 12, 21));
                Acteur willis2 = new Acteur("Bruce Willis", new DateTime(1955, 3, 19));
                Acteur travolta2 = new Acteur("John Travolta", new DateTime(1954, 2, 18));
                Regisseur tarantino2 = new Regisseur("Quentin Tarantino", new DateTime(1963, 3, 27));
                pf2.AddActeur(jackson2);
                pf2.AddActeur(willis2);
                pf2.AddActeur(travolta2);
                pf2.AddRegisseur(tarantino2);

                Film joker1 = new Film("Joker", "Beschrijving", "Korte inhoud", 2019, 122, "Misdaad");
                Acteur phoenix1 = new Acteur("Joaquin Phoenix", new DateTime(1974, 10, 28));
                Acteur niro1 = new Acteur("Robert De Niro", new DateTime(1943, 8, 17));
                Regisseur phillips1 = new Regisseur("Todd Phillips", new DateTime(1970, 12, 5));
                joker1.AddActeur(phoenix1);
                joker1.AddActeur(niro1);
                joker1.AddRegisseur(phillips1);

                Film joker2 = new Film("Joker", "Beschrijving", "Korte inhoud", 2019, 122, "Misdaad");
                Acteur phoenix2 = new Acteur("Joaquin Phoenix", new DateTime(1974, 10, 28));
                Acteur niro2 = new Acteur("Robert De Niro", new DateTime(1943, 8, 17));
                Regisseur phillips2 = new Regisseur("Todd Phillips", new DateTime(1970, 12, 5));
                joker2.AddActeur(phoenix2);
                joker2.AddActeur(niro2);
                joker2.AddRegisseur(phillips2);

                Gebruiker jan = new Gebruiker("Jan Deprof","jan@msn.com");
                jan.AddFilmWatchlist(eg1);
                jan.AddFilmWatchlist(pf1);
                jan.AddFilmWatchlist(joker1);
                _dbContext.Gebruikers.Add(jan);
                await CreateUser(jan.Email, "P@ssword1");

                Gebruiker seba = new Gebruiker("Sebastien De Pauw", "sebastien@hotmail.be");
                seba.AddFilmWatchlist(eg2);
                seba.AddFilmWatchlist(pf2);
                seba.AddFilmWatchlist(joker2);
                _dbContext.Gebruikers.Add(seba);
                await CreateUser(seba.Email, "P@ssword1");

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
