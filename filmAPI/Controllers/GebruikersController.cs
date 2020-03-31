using filmAPI.DTOs;
using filmAPI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace filmAPI.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class GebruikersController : ControllerBase
    {
        private readonly IGebruikerRepository _gebruikerRepo;
        private readonly IFilmRepository _filmRepo;

        public GebruikersController(IFilmRepository filmRepo, IGebruikerRepository gebruikerRepo)
        {
            _filmRepo = filmRepo;
            _gebruikerRepo = gebruikerRepo;
        }

        // GET: api/Gebruikers/sebastien@hotmail.be
        /// <summary>
        /// Geef een gebruiker op email
        /// </summary>
        /// <param name="email">email van een gebruiker</param>
        /// <returns>een gebruiker</returns>
        [HttpGet("{email}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Gebruiker> GetGebruikersBy(string email)
        {
            Gebruiker g = _gebruikerRepo.GetBy(email);
            if (g == null) return NotFound();
            return g;
        }

        // GET: api/Gebruikers/Watchlist
        /// <summary>
        /// Geef alle gebruikers terug geordend op naam
        /// </summary>
        /// <returns>array van gebruiker</returns>
        [HttpGet]
        public IEnumerable<Gebruiker> GetWatchlist()
        {
            return _gebruikerRepo.GetAll();
        }

        // GET: api/Gebruikers/Watchlist/1
        /// <summary>
        /// Geef een gebruiker op id
        /// </summary>
        /// <param name="id">id van een gebruiker </param>
        /// <returns>een gebruiker</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Gebruiker> GetGebruikersById(int id)
        {
            Gebruiker g = _gebruikerRepo.GetBy(id);
            if (g == null) return NotFound();
            return g;
        }


        // PUT: api/Gebruikers/Watchlist
        /// <summary>
        /// Voeg een film toe aan de watchlist
        /// </summary>
        /// <param name="film">de film die moet worden toegevoegd</param>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult PutFilmWatchlist(Film film)
        {
            Gebruiker g = ;
            if (g == null) return NotFound();
            _gebruikerRepo.Update(g);
            _gebruikerRepo.SaveChanges();
            return NoContent();
        }
    }
}