using filmAPI.DTOs;
using filmAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace filmAPI.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class GebruikerController : ControllerBase
    {
        private readonly IGebruikerRepository _repository;

        public GebruikerController(IGebruikerRepository repository)
        {
            _repository = repository;
        }

        [HttpGet()]
        public ActionResult<GebruikerDTO> GetGebruiker()
        {
            Gebruiker g = _repository.GetBy(User.Identity.Name);
            return new GebruikerDTO(g);
        }
    }
}