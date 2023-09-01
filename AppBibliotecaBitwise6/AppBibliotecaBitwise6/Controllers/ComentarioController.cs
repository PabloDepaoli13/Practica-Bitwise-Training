using AppBibliotecaBitwise6.DAL.Interface;
using AppBibliotecaBitwise6.DTO;
using AppBibliotecaBitwise6.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppBibliotecaBitwise6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private readonly IGenericRepository<Comentario> _repository;
        private readonly IMapper _mapper;

        public ComentarioController(IGenericRepository<Comentario> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<ComentarioDTO>>> GetComentarios()
        {
            var resultado = await _repository.ObtenerTodos();
            var resultadoDTO = _mapper.Map<IEnumerable<ComentarioDTO>>(resultado);
            return Ok(resultadoDTO);
        }

        [HttpPost]

        public async Task<ActionResult> CargarComentario(ComentarioCreacionDTO comentarioN)
        {
            var DTO = _mapper.Map<Comentario>(comentarioN);   
            var result = await _repository.Subir(DTO);
            if (!result)
            {
                return BadRequest();
            }
            return Ok(comentarioN);
        }
    }

}
