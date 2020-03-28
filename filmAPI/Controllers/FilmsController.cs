using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using filmAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace filmAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly IFilmRepository _repository;

        public FilmsController(IFilmRepository context) {
            _repository = context;
        }

        // GET: api/Film
        /// <summary>
        /// Get all recipes ordered by titel
        /// </summary>
        /// <returns>array of films</returns>
        [HttpGet]
        public IEnumerable<Recipe> GetRecipes(string name = null, string chef = null, string ingredientName = null)
        {
            if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(chef) && string.IsNullOrEmpty(ingredientName))
                return _recipeRepository.GetAll();
            return _recipeRepository.GetBy(name, chef, ingredientName);
        }


    }
}