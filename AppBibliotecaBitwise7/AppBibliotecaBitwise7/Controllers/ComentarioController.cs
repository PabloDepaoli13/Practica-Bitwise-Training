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
    public class ComentarioController : ControllerBase
    {
        private readonly IGenericRepository<Comentario> _dbContext;
        private readonly IMapper _mapper;
        private readonly IComentaryRepository _comentaryRepository;

        public ComentarioController(IGenericRepository<Comentario> dbContext, IMapper mapper, IComentaryRepository comentaryRepository)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _comentaryRepository = comentaryRepository;
        }


        [HttpGet]

        public async Task<ActionResult<IEnumerable<ComentarioDTO>>> getAllAutors()
        {
            var autores = await _dbContext.GetAll();
            var autorDTO = _mapper.Map<IEnumerable<ComentarioDTO>>(autores);
            return Ok(autorDTO);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<ComentarioDTO>> GetComentarioId(int id)
        {
            var coment = await _comentaryRepository.GetComentaryWithName(id);
            var comentDTO = _mapper.Map<ComentarioDTO>(coment);
            return Ok(comentDTO);
        }

        [HttpPost]

        public async Task<ActionResult> PostAutor(ComentarioCreacionDTO autorNuevo)
        {
            var autor = _mapper.Map<Comentario>(autorNuevo);
            await _dbContext.PostAsync(autor);
            return Ok(autorNuevo);
        }
    }
}
