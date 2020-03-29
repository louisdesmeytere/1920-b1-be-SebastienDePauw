using filmAPI.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
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
                await InitUser();

                Acteur acteur1 = new Acteur("Tom", new DateTime(1990,12,1));
                Acteur acteur2 = new Acteur("Bart", new DateTime(1980, 11, 1));
                Acteur acteur3 = new Acteur("Jef",new DateTime(1970, 10, 1));
                Acteur acteur4 = new Acteur("Julie", new DateTime(1960, 1, 1), new DateTime(2017, 12, 1));
                Acteur acteur5 = new Acteur("Lore", new DateTime(1950, 5, 20), new DateTime(2019, 9, 17));

                Console.WriteLine(acteur1.Naam);

                Regisseur regisseur1 = new Regisseur("Geert", new DateTime(1950, 5, 20), new DateTime(2019, 9, 17));
                Regisseur regisseur2 = new Regisseur("Lotte", new DateTime(1945, 4, 30));

                Film film1 = new Film("Star Wars", "beschrijving", "story", 2000, 135, "Sciencefiction");
                film1.AddActeur(acteur1);
                film1.AddActeur(acteur2);
                film1.AddActeur(acteur3);
                film1.AddRegisseur(regisseur1);
                

                Film film2 = new Film("Pulp Fiction", "beschrijving", "story",1990,120,"Actie");
                film2.AddActeur(acteur3);
                film2.AddActeur(acteur4);
                film2.AddActeur(acteur5);
                film2.AddRegisseur(regisseur2);
                

                Gebruiker gebruiker1 = new Gebruiker("Piet","piet@hotmail.com");
                gebruiker1.AddRating(film1, 9);
                gebruiker1.AddFilmWatchlist()
                _dbContext.Gebruikers.Add(gebruiker1);
                await CreateUser(gebruiker1.Email, "P@ssword1");
                Gebruiker gebruiker2 = new Gebruiker("Sebastien", "Sebastien@hotmail.com");
                _dbContext.Gebruikers.Add(gebruiker2);
                await CreateUser(gebruiker2.Email, "P@ssword1");

                _dbContext.Add(film1);
                _dbContext.Add(film2);
                _dbContext.SaveChanges();
            }
        }
        private async Task CreateUser(string email, string password)
        {
            var gebruiker = new IdentityUser { UserName = email, Email = email };
            await _userManager.CreateAsync(gebruiker, password);
        }

        public async Task InitUser() {
            string email = "admin@msn.be";
            IdentityUser gebruiker = new IdentityUser { UserName = email, Email = email };
            await _userManager.CreateAsync(gebruiker, "P@ssword1");
        }
    }
}
