using AppBibliotecaBitwise7.DAL.Interfaces;
using AppBibliotecaBitwise7.DTO;
using AppBibliotecaBitwise7.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppBibliotecaBitwise7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly IGenericRepository<Libro> _dbContext;
        private readonly IMapper _mapper;
        private readonly ILibreryReposity _libreryReposity;

        public LibroController(IGenericRepository<Libro> dbContext, IMapper mapper, ILibreryReposity libreryReposity)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _libreryReposity = libreryReposity;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<LibroDTO>>> getAllAutors()
        {
            var autores = await _dbContext.GetAll();
            var autorDTO = _mapper.Map<IEnumerable<LibroDTO>>(autores);
            return Ok(autorDTO);
        }


        //[ResponseCache(Duration = 30)]
        [ResponseCache(CacheProfileName = "PorDefecto")]
        //[ResponseCache(Location = ResponseCacheLocation.None, NoStore = true )] Otra manera en el caso de que haya error no guardar

        [HttpGet("Relacion/{id}")]

        public async Task<ActionResult<LibroDTO>> getAllAutorsWithRelacion(int id)
        {
            var autores = await _libreryReposity.GetWithRelacion(id);
            var autorDTO = _mapper.Map<LibroDTO>(autores);
            return Ok(autorDTO);
        }

        [HttpPost]

        public async Task<ActionResult> PostAutor(LibroCreacionDTO autorNuevo)
        {
            var autor = _mapper.Map<Libro>(autorNuevo);
            await _dbContext.PostAsync(autor);
            return Ok(autorNuevo);
        }
    }
}
