using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmAPI.Models
{
    public class WatchListItem
    {
        #region Properties
        public int GebruikerId { get; set; }

        public int FilmId { get; set; }

        public Film Film { get; set; }

        public Gebruiker Gebruiker { get; set; } 
        #endregion

    }
}
