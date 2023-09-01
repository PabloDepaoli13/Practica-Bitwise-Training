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
    public class GeneroController : ControllerBase
    {
        private readonly IGenericRepository<Genero> _repository;
        private readonly IMapper _mapper;

        public GeneroController(IGenericRepository<Genero> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<GeneroDTO>>> GetGeneros()
        {
            var generos = await _repository.ObtenerTodos();
            var generosDTO = _mapper.Map<IEnumerable<GeneroDTO>>(generos);
            return Ok(generosDTO);
        }

        [HttpPost]

        public async Task<ActionResult> SubirGenero(GeneroCreacionDTO generoNew)
        {
            var genero = _mapper.Map<Genero>(generoNew);
            var result = await _repository.Subir(genero);
            if (!result)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(generoNew);
        }
    }
}
