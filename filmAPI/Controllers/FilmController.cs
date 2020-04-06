using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using filmAPI.DTOs;
using filmAPI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace filmAPI.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IGebruikerRepository _gebruikerRepo;
        private readonly IFilmRepository _filmRepo;

        public FilmController(IGebruikerRepository gebruikerRepo, IFilmRepository filmRepository)
        {
            _gebruikerRepo = gebruikerRepo;
            _filmRepo = filmRepository;
        }

        // GET: api/Films/1
        /// <summary>
        /// Geeft de details van een film in uw watchlist terug
        /// </summary>
        /// /// <param name="id">de id van de film waarvan de details getoond moeten worden</param>
        /// <returns>een film</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Film GetFilmsWatchlist(int id)
        {
            Gebruiker g = _gebruikerRepo.GetBy(User.Identity.Name);

            Film f = g.GetFilmWatchlistBy(id);
            if (f == null)
                NotFound();
            return f;
        }

        // GET: api/Films
        /// <summary>
        /// Geef alle films in watchlist terug geordend op titel
        /// </summary>
        /// <returns>array van films</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<Film> GetFilmsWatchlist(string titel = null, string acteurNaam = null, string regisseurNaam = null)
        {
            Gebruiker g = _gebruikerRepo.GetBy(User.Identity.Name);
            if (string.IsNullOrWhiteSpace(titel) && string.IsNullOrWhiteSpace(acteurNaam) && string.IsNullOrWhiteSpace(regisseurNaam))
                return g.GetAllFilms();
            return g.GetFilmWatchlistBy(titel, acteurNaam, regisseurNaam);
        }

        // PUT: api/Films/1
        /// <summary>
        /// Een film aanpassen
        /// </summary>
        /// <param name="id">id van de film die moet aangepast worden</param>
        /// <param name="film">de herziene film</param>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PutFilm(int id, Film film)
        {
            if (id != film.Id) return BadRequest();
            _filmRepo.Update(film);
            _filmRepo.SaveChanges();
            return NoContent();
        }

        // POST: api/Films
        /// <summary>
        /// Voegt een film toe aan uw watchlist
        /// </summary>
        /// <param name="film">de nieuwe film</param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Film> PostFilm(FilmDTO film)
        {
            Gebruiker g = _gebruikerRepo.GetBy(User.Identity.Name);
            Film filmToCreate = new Film() { Titel = film.Titel, Beschrijving = film.Beschrijving, Storyline = film.Storyline, Jaar = film.Jaar, Minuten = film.Minuten, Categorie = film.Categorie };
            foreach (var i in film.Acteurs)
            {
                if (i.Sterfdatum == null) { filmToCreate.AddActeur(new Acteur(i.Naam, i.Geboortedatum)); }
                else { filmToCreate.AddActeur(new Acteur(i.Naam, i.Geboortedatum, i.Sterfdatum.Value)); }
            }
            foreach (var i in film.Regisseurs)
            {
                if (i.Sterfdatum == null) { filmToCreate.AddRegisseur(new Regisseur(i.Naam, i.Geboortedatum)); }
                else { filmToCreate.AddRegisseur(new Regisseur(i.Naam, i.Geboortedatum, i.Sterfdatum.Value)); }
            }
            g.AddFilmWatchlist(filmToCreate);
            _filmRepo.SaveChanges();
            _gebruikerRepo.SaveChanges();

            return CreatedAtAction(nameof(GetFilmsWatchlist), new { id = filmToCreate.Id }, filmToCreate);
        }

          // DELETE: api/Films/
          /// <summary>
          /// Een film deleten
          /// </summary>
          /// <param name="id">het id van de film die je wil deleten</param>
          [HttpDelete("{id}")]
          [ProducesResponseType(StatusCodes.Status200OK)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          [ProducesResponseType(StatusCodes.Status404NotFound)]
          public ActionResult<Film> DeleteMovie(int id)
          {
              Film film = _filmRepo.GetBy(id);
              if (film == null)
              {
                  return NotFound();
              }
              _filmRepo.Delete(film);
              _filmRepo.SaveChanges();
              return film;
          }

        /* // GET: api/Films/1
         /// <summary>
         /// Geeft de film terug met het opgegeven id
         /// </summary>
         /// <param name="id">id van de film</param>
         /// <returns>een film</returns>
         [HttpGet("{id}")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status404NotFound)]
         public ActionResult<Film> GetFilmsWatchlist(int id)
         {
             Film f = _huidigeGebruiker.GetFilmWatchlistBy(id);
             if (f == null) return NotFound();
             return f;
         }
         //

         // PUT: api/Films/Watchlist
         /// <summary>
         /// Geef alle films terug in watchlist geordend op titel
         /// </summary>
         /// <returns>array van films</returns>
         [HttpPut]
         [ProducesResponseType(StatusCodes.Status200OK)]
         public IEnumerable<Film> PutFilmWatchlist()
         {
             _gebruikerRepo;
         }

         // DELETE: api/Films/Watchlist/1
         /// <summary>
         /// Delete een film uit watchlists
         /// </summary>
         /// <returns>array van films</returns>
         [HttpDelete]
         [ProducesResponseType(StatusCodes.Status200OK)]
         public IEnumerable<Film> DeleteFilmWatchlist(string titel = null, string acteurNaam = null, string regisseurNaam = null)
         {
             if (string.IsNullOrWhiteSpace(titel) && string.IsNullOrWhiteSpace(acteurNaam) && string.IsNullOrWhiteSpace(regisseurNaam))
                 return _filmRepo.GetAll();
             return _filmRepo.GetBy(titel, acteurNaam, regisseurNaam);
         }
         #endregion
         */
    }
}