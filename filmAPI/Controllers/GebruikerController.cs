using filmAPI.DTOs;
using filmAPI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace filmAPI.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class GebruikerController : ControllerBase
    {
        private readonly IGebruikerRepository _gebruikerRepo;
        private readonly IFilmRepository _filmRepo;

        public GebruikerController(IFilmRepository filmRepo, IGebruikerRepository gebruikerRepo)
        {
            _filmRepo = filmRepo;
            _gebruikerRepo = gebruikerRepo;
        }

        // GET: api/Gebruiker
        /// <summary>
        /// Geef alle gebruikers terug geordend op naam
        /// </summary>
        /// <returns>array van gebruiker</returns>
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IEnumerable<Gebruiker> GetGebruikers()
        {
                return _gebruikerRepo.GetAll();
        }



    }
}