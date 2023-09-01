using AppBibliotecaBitwise4.DAL.Interface;
using AppBibliotecaBitwise4.DTO;
using AppBibliotecaBitwise4.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppBibliotecaBitwise4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IGenericInterface<Autor> _genericInterface;
        private readonly IMapper _mapper;

        public AutorController(IGenericInterface<Autor> genericInterface, IMapper mapper)
        {
            _genericInterface = genericInterface;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<IEnumerable<AutorDTO>> GetAutores() 
        {
            var autores = await _genericInterface.GetAll();
            var autoresDTO = _mapper.Map<IEnumerable<AutorDTO>>(autores);
            return autoresDTO;
        }

        [HttpPost]

        public async Task<ActionResult> EnviarAutor(AutorCreacionDTO autorCreacion)
        {
            var autor = _mapper.Map<Autor>(autorCreacion);
            var resultado = await _genericInterface.Post(autor);
            if (!resultado)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok("Enviado");

        }
    }
}
