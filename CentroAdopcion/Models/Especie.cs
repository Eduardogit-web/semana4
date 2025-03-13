using System.ComponentModel.DataAnnotations;

namespace CentroAdopcion.Models
{
    public class Especie
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 50 caracteres")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(200, ErrorMessage = "La descripción no puede exceder 200 caracteres")]
        public string Descripcion { get; set; } = string.Empty;

        [Required(ErrorMessage = "Los cuidados especiales son obligatorios")]
        [StringLength(200, ErrorMessage = "Los cuidados no pueden exceder 200 caracteres")]
        public string CuidadosEspeciales { get; set; } = string.Empty;

        [Required(ErrorMessage = "La vida promedio es obligatoria")]
        [Range(1, 100, ErrorMessage = "La vida promedio debe estar entre 1 y 100 años")]
        public int VidaPromedio { get; set; }

        public ICollection<Animal> Animales { get; set; } = new List<Animal>();
    }
}
