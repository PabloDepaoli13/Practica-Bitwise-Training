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
    public class AutorController : ControllerBase
    {
        private readonly IGenericRepository<Autor> _repository;
        private readonly IMapper _mapper;

        public AutorController(IGenericRepository<Autor> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<AutorDTO>>> TraerAutores()
        {
            var autores = await _repository.GetAll();
            if (autores == null)
            {
                return NotFound();
            }
            var DTO = _mapper.Map<IEnumerable<AutorDTO>>(autores);
            return Ok(DTO);
        }

        [HttpPost]

        public async Task<ActionResult> CargarAutor(AutorCreacionDTO autorNew)
        {
            var autor = _mapper.Map<Autor>(autorNew);
            var carga = await _repository.CreateAsync(autor);
            if (!carga)
            {
                return BadRequest("Error");
            }
            return Ok("Cargado");
        }
    }
}
