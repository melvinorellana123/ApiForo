
using ApiForo.Models;
using ApiForo.Models.Dto;
using ApiForo.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ApiForo.Controllers
{
    [Route("api/comentarios")]
    [ApiController]
    public class ComentariosController : ControllerBase
    {
        private readonly IComentarioRepositorio _ctRepo;
        private readonly IMapper _mapper;
        
        public ComentariosController(IComentarioRepositorio ctRepo, IMapper mapper)
        {
            _ctRepo = ctRepo;
            _mapper = mapper;
        }
        
        ////////////////////////obtener todas los comentarios ////////////////////////////
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetComentarios()
        {
            var listaComentarios = _ctRepo.GetComentarios();
            var listaComentariosDto = _mapper.Map<List<ComentarioDto>>(listaComentarios);
        
            return Ok(listaComentariosDto);
        }
        
        ////////////////////////obtener un comentario segun su id////////////////////////////
        [HttpGet("{id:int}", Name = "id")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetComentario(int id)
        {
            var itemComentario = _ctRepo.GetComentario(id);
            if (itemComentario == null)
            {
                return NotFound();
            }
 
            var itemComentarioDto = _mapper.Map<ComentarioDto>(itemComentario);
        
            return Ok(itemComentarioDto);
        }
        
        ////////////////////////crear comentario post////////////////////////////
        [HttpPost]
        public IActionResult CrearComentario([FromBody] ComentarioDto comentarioDto)
        {
            if (comentarioDto == null)
            {
                return BadRequest(ModelState);
            }
 
            if (_ctRepo.ExisteComentario(comentarioDto.Id))
            {
                ModelState.AddModelError("", "El comentario ya existe");
                return StatusCode(404, ModelState);
            }
 
            var comentario = _mapper.Map<Comentario>(comentarioDto);
 
            if (!_ctRepo.CrearComentario(comentario))
            {
                ModelState.AddModelError("", $"Algo salio mal guardando el registro {comentario.Id}");
                return StatusCode(500, ModelState);
            }
 
            return CreatedAtRoute("id", new {id = comentario.Id}, comentario);
        }
        
        ////////////////////////actualizar comentario put////////////////////////////
        [HttpPut("{id:int}", Name = "Actualizar")]
        public IActionResult ActualizarComentario(int id, [FromBody] ComentarioDto comentarioDto)
        {
            comentarioDto.Id = id;
            if (!_ctRepo.ExisteComentario(id))
            {
                return NotFound();
            }
            if (comentarioDto.Contenido.IsNullOrEmpty())
         
            {
                return BadRequest(ModelState);
            }
 
            var comentario = _mapper.Map<Comentario>(comentarioDto);
 
            if (!_ctRepo.ActualizarComentario(comentario))
            {
                ModelState.AddModelError("", $"Algo salio mal actualizando el registro {comentario.Id}");
                return StatusCode(500, ModelState);
            }
 
            return NoContent();
        }
        
        ////////////////////////borrar comentario delete////////////////////////////
        [HttpDelete("{id:int}", Name = "Borrar")]
        public IActionResult BorrarComentario(int id)
        {
            
          
            var comentario = _ctRepo.GetComentario(id);

            if (comentario == null)
            {
                return NotFound();
            }

            if (comentario.Hijos.Count > 0)
            {
                return UnprocessableEntity("No se puede borrar el comentario porque tiene hijos asociados");
            }
            
            
            if (!_ctRepo.BorrarComentario(comentario))
            {
                ModelState.AddModelError("", $"Algo salio mal borrando el registro {comentario.Id}");
                return StatusCode(500, ModelState);
            }
 
            return NoContent();
        }
   
    }
}
