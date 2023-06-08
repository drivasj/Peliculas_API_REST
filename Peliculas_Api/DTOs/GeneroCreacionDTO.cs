using System.ComponentModel.DataAnnotations;

namespace Peliculas_Api.DTOs
{
    public class GeneroCreacionDTO
    {
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
    }
}
