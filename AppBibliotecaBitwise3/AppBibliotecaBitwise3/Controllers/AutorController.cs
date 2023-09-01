using AppBibliotecaBitwise3.DAL.Interfaces;
using AppBibliotecaBitwise3.DTO;
using AppBibliotecaBitwise3.Models;
using AppBibliotecaBitwise3.Utilidades;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppBibliotecaBitwise3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IGenericInterface<Autor> _repository;
        private readonly IMapper _mapper;

        public AutorController(IGenericInterface<Autor> respository, IMapper mapper)
        {
            _repository = respository; 
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<IEnumerable<AutorDTO>> GetAutor()
        {
            var autores = await _repository.GetAllAsync();
            var autoresDTO = _mapper.Map<IEnumerable<AutorDTO>>(autores).ToList();
            return autoresDTO;

        }

        [HttpPost]

        public async Task<ActionResult> PostAutor(AutorCreacionDTO entity)
        {
            var autor = _mapper.Map<Autor>(entity);
            var resultado = await _repository.Post(autor);
            if (!resultado)
            {
                StatusCode(StatusCodes.Status500InternalServerError, new {message = "Error"});
            }
            return Ok(entity);
        }

        [HttpPut]

        public async Task<ActionResult> UpdateAutor(AutorDTO autorUpdate)
        {
            var autorNuevo = _mapper.Map<Autor>(autorUpdate);
            var resultado = await _repository.Update(autorNuevo);
            if (!resultado)
            {
                StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error" });
            }
            return Ok("Cargado");
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteAutor(int id)
        {
            var resultado = await _repository.Delete(id);
            if (!resultado)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error" });
            }
            return Ok("Borrado");
        }
    }
}
