using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmAPI.Models
{
    interface IPersoon
    {
        DateTime Geboortedatum { get; set; }
        DateTime? Sterfdatum { get; set; }
        string Naam { get; set; }
        string? Geboortestad { get; set; }
    }       
}
