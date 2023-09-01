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
    public class LibroController : ControllerBase
    {
        private readonly IGenericContract<Libro> _genericContract;
        private readonly ILibroRepository _libroRepository;
        private readonly IMapper _mapper;

        public LibroController(IGenericContract<Libro> genericContract, IMapper mapper, ILibroRepository libroRepository)
        {
            _genericContract = genericContract;
            _mapper = mapper;
            _libroRepository = libroRepository;
        }

        [HttpGet("DataRelacionada")]

        public async Task<ActionResult<LibroDTO>> GetLibrosRelacion(int id)
        {
            var libros = _libroRepository.ObtenerPorIdConRelacion(id);
            if (libros == null)
            {
                return NotFound();
            }
            var libroDTO = _mapper.Map<LibroDTO>(libros);    
            return Ok(libros);
            
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<LibroDTO>>> GetLibros()
        {
            var libros = await _genericContract.GetAll();
            var librosDTO = _mapper.Map<IEnumerable<LibroDTO>>(libros);
            return Ok(librosDTO);
        }

        [HttpPost]

        public async Task<ActionResult> SubirLibro(LibroCreacionDTO libroCreado)
        {
            var libroEnviable = _mapper.Map<Libro>(libroCreado);
            var resultado = await _genericContract.Post(libroEnviable);
            var libroDTO = _mapper.Map<LibroDTO>(libroEnviable);
            return CreatedAtAction(nameof(GetLibros), new {id = libroEnviable.Id}, libroDTO);
            
        }
    }
}
