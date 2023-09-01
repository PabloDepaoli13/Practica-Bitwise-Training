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
    public class GeneroController : ControllerBase
    {
        private readonly IGenericContract<Genero> _genericContract;
        private readonly IMapper _mapper;

        public GeneroController(IGenericContract<Genero> genericContract, IMapper mapper)
        {
            _genericContract = genericContract;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<GeneroDTO>>> TraerAutores()
        {
            var generos = await _genericContract.GetAll();
            var generosDTO = _mapper.Map<IEnumerable<GeneroDTO>>(generos).ToList();

            if (generos == null)
            {
                return NotFound();
            }
        
            return Ok(generosDTO);

        }

        [HttpPost]

        public async Task<ActionResult> CargarGenero(GeneroCreacionDTO genero)
        {
            var genero2 = _mapper.Map<Genero>(genero);
            var resultado = await _genericContract.Post(genero2);
            if (!resultado)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(resultado);
        }

    }
}

