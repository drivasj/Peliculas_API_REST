using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Peliculas_Api.DTOs;
using Peliculas_Api.Entidades;

namespace Peliculas_Api.Controllers
{
    [ApiController]
    [Route("api/generos")]
    public class GenerosController : CustomBaseController
    {
        public GenerosController(ApplicationDbContext context, IMapper mapper)
           :base(context, mapper) // pasamos a la clase base context, mapper)
        {       
        }

        /// <summary>
        /// Obtener los generos
        /// </summary>
        /// <returns></returns>
        
        [HttpGet]
        public async Task<ActionResult<List<GeneroDTO>>> Get()
        {
            return await Get<Genero,GeneroDTO>();
        }

        /// <summary>
        /// Obtener un genero especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        [HttpGet("{id:int}", Name ="ObtenerGenero")]
        public async Task<ActionResult<GeneroDTO>> Get(int id)
        {
          return await Get<Genero, GeneroDTO>(id);
        }

        /// <summary>
        /// Crear un nuevo genero
        /// </summary>
        /// <param name="generoCreacionDTO"></param>
        /// <returns></returns>
        
        [HttpPost]
        public async Task <ActionResult> Post([FromBody] GeneroCreacionDTO generoCreacionDTO)
        {
            return await Post<GeneroCreacionDTO, Genero, GeneroDTO>(generoCreacionDTO, "ObtenerGenero");
        }

        /// <summary>
        /// Editar un genero
        /// </summary>
        /// <param name="id"></param>
        /// <param name="generoCreacionDTO"></param>
        /// <returns></returns>
        
        [HttpPut("{id}")]
        public async Task <ActionResult> Put(int id, [FromBody] GeneroCreacionDTO generoCreacionDTO) // en algunos casos se puede utlizar el mismo DTO
        {
            return await Put<GeneroCreacionDTO, Genero>(id, generoCreacionDTO);
        }

        /// <summary>
        /// Eliminar un genero
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult> Delete(int id)
        {
            return await Delete<Genero>(id);
        }
    }
}
