using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmAPI.Models
{
    public class WatchListItem
    {
        public Film Film{ get; set; }
        public Gebruiker Gebruiker { get; set; }
        public int GebruikerId { get; set; }
        public int FilmId { get; set; }
    }
}
