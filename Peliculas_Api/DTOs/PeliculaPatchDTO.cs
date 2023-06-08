using System.ComponentModel.DataAnnotations;

namespace Peliculas_Api.DTOs
{
    public class PeliculaPatchDTO
    {
     
        [Required]
        [StringLength(300)]
        public string Titulo { get; set; }
        public bool EnCines { get; set; }
        public DateTime FechaEstreno { get; set; }
        public string Poster { get; set; }
    }
}
