namespace Peliculas_Api.Entidades
{
    public class PeliculasGeneros
    {
        // Relacion Pelicula - Genero
        public int GeneroId { get; set; }
        public int PeliculaId { get; set; }
        public Genero Genero { get; set; }
        public Pelicula Pelicula { get; set; }
    }
}
