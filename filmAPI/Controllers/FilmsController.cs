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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly IFilmRepository _filmRepo;
        private readonly IGebruikerRepository _gebruikerRepo;
        private readonly Gebruiker _huidigeGebruiker;

        public FilmsController(IFilmRepository context, IGebruikerRepository gebruikerRepo)
        {
            _filmRepo = context;
            _gebruikerRepo = gebruikerRepo;
            _huidigeGebruiker = _gebruikerRepo.GetBy(User.Identity.Name);
        }

        #region All
        // GET: api/Films
        /// <summary>
        /// Geef alle films terug geordend op titel
        /// </summary>
        /// <returns>array van films</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<Film> GetFilms(string titel = null, string acteurNaam = null, string regisseurNaam = null)
        {
            if (string.IsNullOrWhiteSpace(titel) && string.IsNullOrWhiteSpace(acteurNaam) && string.IsNullOrWhiteSpace(regisseurNaam))
                return _filmRepo.GetAll();
            return _filmRepo.GetBy(titel, acteurNaam, regisseurNaam);
        }

        // GET: api/Films/1
        /// <summary>
        /// Geeft de film terug met het opgegeven id
        /// </summary>
        /// <param name="id">id van de film</param>
        /// <returns>een film</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Film> GetFilm(int id)
        {
            Film f = _filmRepo.GetBy(id);
            if (f == null) return NotFound();
            return f;
        }

        // POST: api/Films
        /// <summary>
        /// Voegt een film toe
        /// </summary>
        /// <param name="film">de nieuwe film</param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Film> PostFilm(FilmDTO film)
        {
            Film f = new Film() { Titel = film.Titel, Beschrijving = film.Beschrijving, Storyline = film.Storyline, Jaar = film.Jaar, Minuten = film.Minuten, Categorie = film.Categorie };
            foreach (var i in film.Acteurs) { f.AddActeur(new Acteur(i.Naam, i.Geboortedatum, i.Sterfdatum)); }
            foreach (var i in film.Regisseurs) { f.AddRegisseur(new Regisseur(i.Naam, i.Geboortedatum, i.Sterfdatum)); }

            _filmRepo.Add(f);
            _filmRepo.SaveChanges();

            return CreatedAtAction("GetFilm", new { id = f.Id }, f);
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult PutFilm(int id, Film film)
        {
            if (film.Id != id) return BadRequest();
            _filmRepo.Update(film);
            _filmRepo.SaveChanges();
            return NoContent();
        }

        // DELETE: api/Films/1
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
            Film movie = _filmRepo.GetBy(id);
            if (movie == null)
            {
                return NotFound();
            }
            _filmRepo.Delete(movie);
            _filmRepo.SaveChanges();
            return movie;
        }
        #endregion

        #region Watchlist
        // GET: api/Films/Watchlist
        /// <summary>
        /// Geef alle films terug in watchlist geordend op titel
        /// </summary>
        /// <returns>array van films</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<Film> GetAllFilmsWatchlist()
        {
            return _gebruikerRepo.GetAllFilmsWatchlist(_huidigeGebruiker);
        }

        // GET: api/Films/Watchlist/1
        /// <summary>
        /// Geef alle films terug in watchlist geordend op titel
        /// </summary>
        /// <returns>array van films</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Film GetFilmsWatchlistById(int filmId)
        {
            return _gebruikerRepo.GetFilmsWatchlist(_huidigeGebruiker, filmId);
        }

        // PUT: api/Films/Watchlist
        /// <summary>
        /// Geef alle films terug in watchlist geordend op titel
        /// </summary>
        /// <returns>array van films</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<Film> PutFilmWatchlist()
        {
            _gebruikerRepo.
        }

        // DELETE: api/Films/Watchlist/1
        /// <summary>
        /// Geef alle films terug in watchlist geordend op titel
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
    }
}