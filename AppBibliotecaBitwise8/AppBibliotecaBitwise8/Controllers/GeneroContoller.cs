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
    public class GeneroContoller : ControllerBase
    {
        private readonly IGenericRepository<Genero> _repository;
        private readonly IMapper _mapper;

        public GeneroContoller(IGenericRepository<Genero> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<GeneroDTO>>> TraerAutores()
        {
            var autores = await _repository.GetAll();
            if (autores == null)
            {
                return NotFound();
            }
            var DTO = _mapper.Map<IEnumerable<GeneroDTO>>(autores);
            return Ok(DTO);
        }

        [HttpPost]

        public async Task<ActionResult> CargarAutor(GeneroCreacionDTO autorNew)
        {
            var autor = _mapper.Map<Genero>(autorNew);
            var carga = await _repository.CreateAsync(autor);
            if (!carga)
            {
                return BadRequest("Error");
            }
            return Ok("Cargado");
        }
    }
}
