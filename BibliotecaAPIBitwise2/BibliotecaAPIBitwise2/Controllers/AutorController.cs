using AutoMapper;
using BibliotecaAPIBitwise2.DAL.DataContext;
using BibliotecaAPIBitwise2.DAL.Interfaces;
using BibliotecaAPIBitwise2.Models;
using BibliotecaAPIBitwise2.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAPIBitwise2.Controllers
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

        public async Task<ActionResult<IEnumerable<AutorDTO>>> GetAll() 
        {
            var autores = await _repository.GetAllAsync();
            var autoresDTO = _mapper.Map<IEnumerable<AutorDTO>>(autores);
            return autoresDTO.ToList();
        }

        [HttpPost]

        public async Task<ActionResult> Enviar(AutorCreacionDTO autorNew)
        {
            var autorCreacion = _mapper.Map<Autor>(autorNew);
            var resultado = await _repository.Enviar(autorCreacion);
            if (!resultado)
            {
                return NotFound();
            }
            
            return Ok("Correcto");
        }

        [HttpPut]

        public async Task<ActionResult> Actualizar(AutorDTO autor)
        {
            var autorEnviable = _mapper.Map<Autor>(autor);
            var resultado =  await _repository.Update(autorEnviable);
            if (!resultado)
            {
                return NotFound();
            }
            return Ok("Correcto");
        }
    }
}
