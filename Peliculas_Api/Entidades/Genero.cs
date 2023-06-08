using System.ComponentModel.DataAnnotations;

namespace Peliculas_Api.Entidades
{
    public class Genero: IId
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        //
        public List<PeliculasGeneros> PeliculasGeneros { get; set; }
    }
}
