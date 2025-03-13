using System.ComponentModel.DataAnnotations;

namespace CentroAdopcion.Models
{
    public class Animal
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 50 caracteres")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La edad es obligatoria")]
        [Range(0, 30, ErrorMessage = "La edad debe estar entre 0 y 30 años")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El estado de salud es obligatorio")]
        [StringLength(100, ErrorMessage = "El estado de salud no puede exceder 100 caracteres")]
        public string EstadoSalud { get; set; } = string.Empty;

        [Required(ErrorMessage = "El estado de adopción es obligatorio")]
        public bool Adoptado { get; set; }

        [Required(ErrorMessage = "La especie es obligatoria")]
        public int EspecieId { get; set; }

        [Required(ErrorMessage = "El refugio es obligatorio")]
        public int RefugioId { get; set; }

        public Especie Especie { get; set; } = null!;
        public Refugio Refugio { get; set; } = null!;
        public ICollection<Adopcion> Adopciones { get; set; } = new List<Adopcion>();
    }
}

