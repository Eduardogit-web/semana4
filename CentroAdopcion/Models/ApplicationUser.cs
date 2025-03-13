using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CentroAdopcion.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 50 caracteres")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El apellido debe tener entre 2 y 50 caracteres")]
        public string Apellido { get; set; } = string.Empty;

        [Required(ErrorMessage = "La dirección es obligatoria")]
        [StringLength(200, ErrorMessage = "La dirección no puede exceder 200 caracteres")]
        public string Direccion { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de registro es obligatoria")]
        public DateTime FechaRegistro { get; set; }

        public ICollection<Adopcion> Adopciones { get; set; } = new List<Adopcion>();
    }
}
