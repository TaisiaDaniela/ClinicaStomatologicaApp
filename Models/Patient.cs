using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ClinicaStomatologicaApp.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campul este obligatoriu.")]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Campul este obligatoriu.")]
        [RegularExpression(@"^07\d{8}$", ErrorMessage = "Telefonul trebuie sa fie format din 10 cifre și să înceapă cu '07'.")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Campul este obligatoriu.")]
        [EmailAddress(ErrorMessage = "Adresa de email nu este valida.")]
        public string Email { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "Campul este obligatoriu.")]

        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Campul este obligatoriu.")]
        [RegularExpression(@"^(Male|Female)$", ErrorMessage = "Genul trebuie sa fie 'Male' sau 'Female'.")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Campul este obligatoriu.")]

        public string Allergies { get; set; }

        public int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
    }
}
