using System.ComponentModel.DataAnnotations;

namespace CentroAdopcion.Models
{
    public class Refugio
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La dirección es obligatoria")]
        [StringLength(200, ErrorMessage = "La dirección no puede exceder 200 caracteres")]
        public string Direccion { get; set; } = string.Empty;

        [Required(ErrorMessage = "La capacidad es obligatoria")]
        [Range(1, 1000, ErrorMessage = "La capacidad debe estar entre 1 y 1000")]
        public int Capacidad { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [Phone(ErrorMessage = "Formato de teléfono inválido")]
        public string Telefono { get; set; } = string.Empty;

        public ICollection<Animal> Animales { get; set; } = new List<Animal>();
    }
}
