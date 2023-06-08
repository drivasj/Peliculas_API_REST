using AutoMapper;
using Microsoft.AspNetCore.Identity;
using NetTopologySuite.Geometries;
using NetTopologySuite.Utilities;
using Peliculas_Api.DTOs;
using Peliculas_Api.Entidades;

namespace Peliculas_Api.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles(GeometryFactory geometryFactory)
        {
            //Crear mapeo desde - hasta 

            // Review
            CreateMap<ReviewDTO, Review>();
            CreateMap<ReviewCreacionDTO, Review>();

            // Usuario
            CreateMap<IdentityUser, UsuarioDTO>();

            // sala de cine 

            CreateMap<SalaDeCine, SalaDeCineDTO>() // -> mapear un punto hacia una latitud y un punto hacia una longitud
                .ForMember(x => x.Latitud, x => x.MapFrom(y => y.Ubicacion.Y))
                .ForMember(x => x.Longitud, x => x.MapFrom(y => y.Ubicacion.X));

            CreateMap<SalaDeCineDTO, SalaDeCine>()
                 .ForMember(x => x.Ubicacion, x => x.MapFrom(y =>
                geometryFactory.CreatePoint(new Coordinate(y.Longitud, y.Latitud))));

            CreateMap<SalaDeCineCreacionDTO, SalaDeCine>()
                .ForMember(x => x.Ubicacion, x => x.MapFrom(y =>
                geometryFactory.CreatePoint(new Coordinate(y.Longitud, y.Latitud))));


            // Genero
            CreateMap <Genero, GeneroDTO>().ReverseMap(); // Metodo GET
            CreateMap<GeneroCreacionDTO, Genero>(); // Metodo POST

            //Actor 
            CreateMap<Actor, ActorDTO>().ReverseMap(); // Metodo GET
            CreateMap<ActorCreacionDTO, Actor>().ForMember(x => x.Foto, options => options.Ignore()); // Metodo POST -> ignorar el campo foto
            CreateMap<ActorPatchDTO, Actor>().ReverseMap(); // Metodo PATCH

            //Pelicula
            CreateMap<Pelicula, PeliculaDTO>().ReverseMap(); // Metodo GET
                
            CreateMap<PeliculaCreacionDTO, Pelicula>()
                .ForMember(x => x.Poster, options => options.Ignore()) // Metodo POST -> ignorar el campo foto
                .ForMember(x => x.PeliculasGeneros, options => options.MapFrom(MapPeliculasGeneros)) // Mapeo personalizado
                .ForMember(x => x.PeliculasActores, options => options.MapFrom(MapPeliculasActores));


            CreateMap<Pelicula, PeliculaDetallesDTO>() // Detalles
                .ForMember(x => x.Generos, options => options.MapFrom(MapPeliculasGeneros))
                .ForMember(x => x.Actores, options => options.MapFrom(MapPeliculasActores));



            CreateMap<PeliculaPatchDTO, Pelicula>().ReverseMap(); // Metodo PATCH


        }

        /// <summary>
        /// Detalle actores
        /// </summary>
        /// <param name="pelicula"></param>
        /// <param name="peliculaDetallesDTO"></param>
        /// <returns></returns>
        private List<ActorPeliculaDetalleDTO> MapPeliculasActores(Pelicula pelicula, PeliculaDetallesDTO peliculaDetallesDTO)
        {
            var resultado = new List<ActorPeliculaDetalleDTO>();
            if (pelicula.PeliculasActores == null) { return resultado; }
            foreach (var actorPelicula in pelicula.PeliculasActores)
            {
                resultado.Add(new ActorPeliculaDetalleDTO
                {
                    ActorId = actorPelicula.ActorId,
                    Personaje = actorPelicula.Personaje,
                    NombrePersona = actorPelicula.Actor.Nombre
                });
            }

            return resultado;
        }
        /// <summary>
        /// Detalles genero
        /// </summary>
        /// <param name="pelicula"></param>
        /// <param name="peliculaDetallesDTO"></param>
        /// <returns></returns>
        private List<GeneroDTO> MapPeliculasGeneros(Pelicula pelicula, PeliculaDetallesDTO peliculaDetallesDTO)
        {
            var resultado = new List<GeneroDTO>();
            if (pelicula.PeliculasGeneros == null) { return resultado; }
            foreach (var generoPelicula in pelicula.PeliculasGeneros)
            {
                resultado.Add(new GeneroDTO() { Id = generoPelicula.GeneroId, Nombre = generoPelicula.Genero.Nombre });
            }

            return resultado;
        }


        /// <summary>
        /// Mapeo personalizado PeliculasGeneros
        /// </summary>
        /// <param name="peliculaCreacionDTO"></param>
        /// <param name="pelicula"></param>
        /// <returns></returns>
        private List<PeliculasGeneros> MapPeliculasGeneros(PeliculaCreacionDTO peliculaCreacionDTO, Pelicula pelicula)
        {
            var resultado = new List<PeliculasGeneros>();
            if (peliculaCreacionDTO.GenerosIDs == null) { return resultado; }
            foreach (var id in peliculaCreacionDTO.GenerosIDs)
            {
                resultado.Add(new PeliculasGeneros() { GeneroId = id });
            }

            return resultado;
        }

        /// <summary>
        /// Mapeo personalizado MapPeliculasActores
        /// </summary>
        /// <param name="peliculaCreacionDTO"></param>
        /// <param name="pelicula"></param>
        /// <returns></returns>
        private List<PeliculasActores> MapPeliculasActores(PeliculaCreacionDTO peliculaCreacionDTO, Pelicula pelicula)
        {
            var resultado = new List<PeliculasActores>();
            if (peliculaCreacionDTO.Actores == null) { return resultado; }

            foreach (var actor in peliculaCreacionDTO.Actores)
            {
                resultado.Add(new PeliculasActores() { ActorId = actor.ActorId, Personaje = actor.Personaje });
            }

            return resultado;
        }
    }
}
