using System.ComponentModel.DataAnnotations;

namespace CentroAdopcion.Models
{
    public class Adopcion
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La fecha de adopción es obligatoria")]
        public DateTime FechaAdopcion { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio")]
        [StringLength(50, ErrorMessage = "El estado no puede exceder 50 caracteres")]
        public string Estado { get; set; } = string.Empty;

        [Required(ErrorMessage = "Las observaciones son obligatorias")]
        [StringLength(500, ErrorMessage = "Las observaciones no pueden exceder 500 caracteres")]
        public string Observaciones { get; set; } = string.Empty;

        [Required(ErrorMessage = "El usuario es obligatorio")]
        public string UserId { get; set; } = string.Empty;

        [Required(ErrorMessage = "El animal es obligatorio")]
        public int AnimalId { get; set; }

        public ApplicationUser User { get; set; } = null!;
        public Animal Animal { get; set; } = null!;
    }
}
