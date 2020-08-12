using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace filmAPI.DTOs
{
    public class RegisterDTO : LoginDTO
    {
        [Required]
        [StringLength(20)]
        public string Voornaam { get; set; }
        [Required]
        [StringLength(20)]
        public string Achternaam { get; set; }
        [Required]
        [Compare("Password")]
        [RegularExpression("((?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%?=*&]).{8,})",
            ErrorMessage = "Passwoord moet minimum 8 karakters lang zijn, minimum 1 kleine en grote letter bevatten, minimum 1 nummer bevatten en minimim 1 speciaal karakters (vb. !@#$%^&*)")]
        public String PasswordConfirmation { get; set; }
    }
}
