using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmAPI.Models
{
    public class Rating
    {
        #region Properties
        public int GebruikerId { get; set; }

        public int FilmId { get; set; }

        public Gebruiker Gebruiker { get; set; }

        public Film Film { get; set; }

        public double Score { get; set; }
        #endregion
    }
}
