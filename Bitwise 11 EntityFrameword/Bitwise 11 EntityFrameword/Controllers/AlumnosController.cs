using Bitwise_11_EntityFrameword.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bitwise_11_EntityFrameword.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnosController : ControllerBase
    {
        private readonly AlumnosDeudoresContext _context;

        public AlumnosController(AlumnosDeudoresContext context)
        {
            _context= context;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Alumno>>> GetAll()
        { 
            try
            {
                var lista = new List<Alumno>();
                lista = await _context.Alumnos.ToListAsync();
                return Ok(lista);
            }
            catch (Exception error)
            {
                StatusCode(StatusCodes.Status500InternalServerError, new {message = error.Message});
                throw;
            }
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<IEnumerable<Alumno>>> GetID(int id)
        {
            try
            {
                
                var alumno = await _context.Alumnos.FirstOrDefaultAsync(e => e.Id == id);
                if(alumno == null)return NotFound();
                return Ok(alumno);
            }
            catch (Exception error)
            {
                StatusCode(StatusCodes.Status500InternalServerError, new { message = error.Message });
                throw;
            }
        }
        [HttpGet("filtro")]

        public async Task<ActionResult<IEnumerable<Alumno>>> GetID(string nombre = null)
        {
            try
            {
                var lista = new List<Alumno>();
                lista = await _context.Alumnos.ToListAsync();
                if (nombre == null) return Ok(lista);
                var resultado = lista.Where(e => e.Nombre.ToLower().Contains(nombre.ToLower()));
                if(resultado.Count() == 0)return NotFound();
                return Ok(resultado);
            }
            catch (Exception error)
            {
                StatusCode(StatusCodes.Status500InternalServerError, new { message = error.Message });
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(Alumno alumno)
        {
            try
            {
                _context.Alumnos.Add(alumno);
                await _context.SaveChangesAsync();
                return Ok("Cargado");
            }
            catch (Exception error)
            {
                StatusCode(StatusCodes.Status500InternalServerError, new { message = error.Message });
                throw;
            }
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> Update(int id, Alumno alumno)
        {
            try
            {
                var alumnoExistente = _context.Alumnos.FirstOrDefault(a => a.Id == id);
                if (alumnoExistente == null) return NotFound();
                alumnoExistente.Nombre= alumno.Nombre is null ? alumnoExistente.Nombre: alumno.Nombre;
                alumnoExistente.Telefono = alumno.Telefono is null ? alumnoExistente.Telefono : alumno.Telefono;
                alumnoExistente.Direccion = alumno.Direccion is null ? alumnoExistente.Direccion : alumno.Direccion;
                alumnoExistente.Ciudad = alumno.Ciudad is null ? alumnoExistente.Ciudad : alumno.Ciudad;
                alumnoExistente.Deudor = alumno.Deudor is null ? alumnoExistente.Deudor : alumno.Deudor;
                alumnoExistente.MontoDeuda = alumno.MontoDeuda is null ? alumnoExistente.MontoDeuda : alumno.MontoDeuda;
                _context.Alumnos.Update(alumnoExistente);
                await _context.SaveChangesAsync();
                return Ok("Cargado");
            }
            catch (Exception error)
            {
                StatusCode(StatusCodes.Status500InternalServerError, new { message = error.Message });
                throw;
            }
        }

        [HttpDelete]

        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var alumnoExistente = await _context.Alumnos.FirstOrDefaultAsync(e => e.Id == id);
                _context.Alumnos.Remove(alumnoExistente);
                await _context.SaveChangesAsync();
                return Ok("Cargado");
            }
            catch (Exception error)
            {
                StatusCode(StatusCodes.Status500InternalServerError, new { message = error.Message });
                throw;
            }
        }

    }
}
