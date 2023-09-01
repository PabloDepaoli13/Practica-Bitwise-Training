using AppBibliotecaBitwise6.DAL.Interface;
using AppBibliotecaBitwise6.DTO;
using AppBibliotecaBitwise6.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XAct.Security;

namespace AppBibliotecaBitwise6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly IGenericRepository<Libro> _repository;
        private readonly IMapper _mapper;
        private readonly ILibreryRepository _libreryRepository;

        public LibroController(IGenericRepository<Libro> repository, IMapper mapper, ILibreryRepository libreryRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _libreryRepository = libreryRepository;
        }

        [Authorize(Roles = "admin")]
        [HttpGet]

        public async Task<ActionResult<IEnumerable<LibroDTO>>> GetGeneros()
        {
            var libros = await _repository.ObtenerTodos();
            var librosDTO = _mapper.Map<IEnumerable<LibroDTO>>(libros);
            return Ok(librosDTO);
        }



        [HttpPost]

        public async Task<ActionResult> SubirGenero(LibroCreacionDTO libroNew)
        {
            var libro = _mapper.Map<Libro>(libroNew);
            var result = await _repository.Subir(libro);
            if (!result)
            {
                return BadRequest();
            }
            return Ok(libroNew);
        }


        [HttpGet("{id}")]

        public async Task<ActionResult<LibroNombresDTO>> TraerConRelacion(int id)
        {
            var autor = await _libreryRepository.GetWithRelacion(id);
            if (autor == null)
            {
                return NotFound();
            }
            var autorDTO = _mapper.Map<LibroNombresDTO>(autor);
            return Ok(autorDTO);
        }
    }
}
