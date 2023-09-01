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
    public class AutorController : ControllerBase
    {
        private readonly IGenericContract<Autor> _genericContract;
        private readonly IMapper _mapper;

        public AutorController(IGenericContract<Autor> genericContract, IMapper mapper)
        {
            _genericContract = genericContract;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<AutorDTO>>> TraerAutores()
        {
            var autores = await _genericContract.GetAll();
            if(autores == null)
            {
                return NotFound();
            }
            var autorDTO = _mapper.Map<IEnumerable<AutorDTO>>(autores);
            return Ok(autorDTO);

        }

        [HttpPost]

        public async Task<ActionResult> CargarAutor(AutorCreacionDTO autorCreacion)
        {
            var autor = _mapper.Map<Autor>(autorCreacion);
            var resultado = await _genericContract.Post(autor);
            if (!resultado)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok("Cargado con Exito");
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Autor>> TraerAutor(int id)
        {
            
            var autor = await _genericContract.Get(id);
            if (autor == null)
            {
                return NotFound("No se encontró");
            }
            var autorDTO = _mapper.Map<AutorDTO>(autor);
            return Ok(autorDTO);

        }

        [HttpPut]

        public async Task<ActionResult> ActualizarAutor(AutorDTO autor)
        {
            var autorEnviable = _mapper.Map<Autor>(autor);
            var resultado = await _genericContract.Update(autorEnviable);
            if (!resultado)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok("Actualizado");
        }

        [HttpDelete]

        public async Task<ActionResult> BorrarAutor(int id)
        {
            var resultado = await _genericContract.Delete(id);
            if (!resultado)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok("Borrado");
        }
    }
}
