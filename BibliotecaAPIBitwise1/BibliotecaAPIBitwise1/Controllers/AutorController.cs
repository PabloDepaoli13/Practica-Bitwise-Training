using BibliotecaAPIBitwise1.DAL.Interfaces;
using AutoMapper;
using BibliotecaAPIBitwise1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BibliotecaAPIBitwise1.DTO;

namespace BibliotecaAPIBitwise1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IGenericRepository<Autor> _generic;
        private readonly IMapper _mapper;

        public AutorController(IGenericRepository<Autor> generic, IMapper mapper)
        {
            _generic = generic;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<AutorDTO>>> GetAll()
        {
            var autores = await _generic.GetAll();
            var autoresDTO = _mapper.Map<IEnumerable<AutorDTO>>(autores);
            return Ok(autoresDTO); 
        }


        [HttpPost]

        public async Task<ActionResult> Crear(AutorCreacionDTO autorCreacion)
        {
            var autor = _mapper.Map<Autor>(autorCreacion);
            var resultado = await _generic.Post(autor);
            if (!resultado)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new {message = "Error"});
            }
            var DTO = _mapper.Map<AutorDTO>(autor);
            return Ok(DTO);
        }

    }
}
