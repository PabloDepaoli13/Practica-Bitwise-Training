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
    public class GeneroController : ControllerBase
    {
        private readonly IGenericRepository<Genero> _dbContext;
        private readonly IMapper _mapper;
        private readonly IGeneroRepository _generoRepository;

        public GeneroController(IGenericRepository<Genero> dbContext, IMapper mapper, IGeneroRepository generoRepository)
        {
            _generoRepository= generoRepository;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<GeneroDTO>>> getAllAutors()
        {
            var autores = await _dbContext.GetAll();
            var autorDTO = _mapper.Map<IEnumerable<GeneroDTO>>(autores);
            return Ok(autorDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GeneroDTO>> GetWithAutors(int id)
        {
            var genero = await _generoRepository.GeneroWithList(id);
            var generoDTO = _mapper.Map<GeneroDTO>(genero);
            return Ok(generoDTO);
        }

        [HttpPost]

        public async Task<ActionResult> PostAutor(GeneroCreacionDTO autorNuevo)
        {
            var autor = _mapper.Map<Genero>(autorNuevo);
            await _dbContext.PostAsync(autor);
            return Ok(autorNuevo);
        }
    }
}
