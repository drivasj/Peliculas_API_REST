using Microsoft.AspNetCore.Identity;
using Peliculas_Api.Entidades;
using System.ComponentModel.DataAnnotations;

namespace Peliculas_Api.DTOs
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public string Comentario { get; set; }
        public int Puntuacion { get; set; }
        public int PeliculaId { get; set; }
        public string UsuarioId { get; set; }
        public string NombreUsuario { get; set; }
    }
}
