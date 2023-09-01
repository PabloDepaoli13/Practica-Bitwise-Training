using AppBibliotecaBitwise5.DAL.Interface;
using AppBibliotecaBitwise5.DTO;
using AppBibliotecaBitwise5.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppBibliotecaBitwise5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private readonly IGenericContract<Comentarios> _genericContract;
        private readonly IMapper _mapper;

        public ComentarioController(IGenericContract<Comentarios> genericContract, IMapper mapper)
        {
            _genericContract = genericContract;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<ComentarioDTO>>> GetComentarios()
        {
            var comentarios = await  _genericContract.GetAll();
            var comDTO = _mapper.Map<IEnumerable<ComentarioDTO>>(comentarios);
            return Ok(comDTO);
        }

        [HttpPost]

        public async Task<ActionResult> SubirComentario(ComentarioCreacionDTO comentario)
        {
            var comentarioNuevo = _mapper.Map<Comentarios>(comentario);
            var resultado = await _genericContract.Post(comentarioNuevo);
            if (!resultado)
            {
                return BadRequest();
            }
            return Ok(resultado);
        }
    }
}
