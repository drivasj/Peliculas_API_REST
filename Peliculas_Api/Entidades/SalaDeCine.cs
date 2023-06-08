using System.ComponentModel.DataAnnotations;
using System.Drawing;
using NetTopologySuite.Geometries;
using Point = NetTopologySuite.Geometries.Point;

namespace Peliculas_Api.Entidades
{
    public class SalaDeCine: IId
    {
        // Relacion mucho a muchos con peliculas

        public int Id { get; set; }
        [Required]
        [StringLength(120)]
        public string Nombre { get; set;}
        public Point Ubicacion { get; set; }
        public List<PeliculasSalasDeCine> PeliculasSalasDeCines { get; set; }
    }
}
