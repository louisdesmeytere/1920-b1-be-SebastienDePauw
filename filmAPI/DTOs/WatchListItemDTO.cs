using filmAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace filmAPI.DTOs
{
    public class WatchListItemDTO
    {
        [Required]
        int Id { get; set; }

        public WatchListItemDTO(Film film) {
            Id = film.Id;
        }
    }
}
