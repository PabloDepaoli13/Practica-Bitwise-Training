using AppBibliotecaBitwise7.DAL.Interfaces;
using AppBibliotecaBitwise7.DTO;
using AppBibliotecaBitwise7.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppBibliotecaBitwise7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IGenericRepository<Autor> _dbContext;
        private readonly IMapper _mapper;

        public AutorController(IGenericRepository<Autor> dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [Authorize(Roles = "admin")]
        [HttpGet]

        public async Task<ActionResult<IEnumerable<AutorDTO>>> getAllAutors()
        {
            var autores = await _dbContext.GetAll();
            var autorDTO = _mapper.Map<IEnumerable<AutorDTO>>(autores);
            return Ok(autorDTO);
        }

        [HttpPost]

        public async Task<ActionResult> PostAutor(AutorCreacionDTO autorNuevo)
        {
            var autor = _mapper.Map<Autor>(autorNuevo);
            await _dbContext.PostAsync(autor);
            return Ok(autorNuevo);
        }
    }
}
