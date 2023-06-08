using System.ComponentModel.DataAnnotations;

namespace Peliculas_Api.DTOs
{
    public class GeneroDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
    }
}
