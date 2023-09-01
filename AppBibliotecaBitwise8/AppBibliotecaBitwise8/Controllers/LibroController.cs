using AppBibliotecaBitwise8.DAL.Implementatios;
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
    public class LibroController : ControllerBase
    {
        private readonly IGenericRepository<Libro> _repository;
        private readonly ILibraryRepository _libraryRepository;
        private readonly IMapper _mapper;

        public LibroController(IGenericRepository<Libro> repository, IMapper mapper, ILibraryRepository libraryRepository)
        {
            _libraryRepository= libraryRepository;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<LibroDTO>>> TraerAutores()
        {
            var autores = await _repository.GetAll();
            if (autores == null)
            {
                return NotFound();
            }
            var DTO = _mapper.Map<IEnumerable<LibroDTO>>(autores);
            return Ok(DTO);
        }

        [HttpPost]

        public async Task<ActionResult> CargarAutor(LibroCreacionDTO autorNew)
        {
            var autor = _mapper.Map<Libro>(autorNew);
            var carga = await _repository.CreateAsync(autor);
            if (!carga)
            {
                return BadRequest("Error");
            }
            return Ok("Cargado");
        }

        [HttpGet("ConRelacion/{id}")]

        public async Task<ActionResult<LibroDTO>> GetWithRelacion(int id)
        {
            var autor = await _libraryRepository.GetWithRelacion(id);
            var DTO = _mapper.Map<LibroDTO>(autor);
            return Ok(DTO);
        }
    }
}
