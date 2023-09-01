using AppBibliotecaBitwise8.DAL.Interfaces;
using AppBibliotecaBitwise8.DTO;
using AppBibliotecaBitwise8.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppBibliotecaBitwise8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private readonly IGenericRepository<Comentarios> _repository;
        private readonly IMapper _mapper;

        public ComentarioController(IGenericRepository<Comentarios> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<ComentarioDTO>>> TraerAutores()
        {
            var autores = await _repository.GetAll();
            if (autores == null)
            {
                return NotFound();
            }
            var DTO = _mapper.Map<IEnumerable<ComentarioDTO>>(autores);
            return Ok(DTO);
        }

        [HttpPost]

        public async Task<ActionResult> CargarAutor(ComentarioCreacionDTO autorNew)
        {
            var autor = _mapper.Map<Comentarios>(autorNew);
            var carga = await _repository.CreateAsync(autor);
            if (!carga)
            {
                return BadRequest("Error");
            }
            return Ok("Cargado");
        }
    }
}
