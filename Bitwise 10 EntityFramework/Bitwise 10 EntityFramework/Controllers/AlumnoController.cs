using Bitwise_10_EntityFramework.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bitwise_10_EntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private readonly AlumnosDeudoresContext _context;

        public AlumnoController(AlumnosDeudoresContext context)
        {
            _context = context;
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
                StatusCode(StatusCodes.Status500InternalServerError, new { message = error.Message });
                throw;
            }
        }
        [HttpGet("{id}")]

        public async Task<ActionResult<IEnumerable<Alumno>>> GetAlumno(int id)
        {
            try
            {
                var alumno = await _context.Alumnos.FirstOrDefaultAsync(e => e.Id == id);
                if (alumno == null) return NotFound("No se encontro");
                return Ok(alumno);
            }
            catch (Exception error)
            {
                StatusCode(StatusCodes.Status500InternalServerError, new { message = error.Message });
                throw;
            }
        }


        [HttpGet("filtro")]

        public async Task<ActionResult<IEnumerable<Alumno>>> GetFiltro(string nombre = null)
        {
            try
            {
                var alumno = new List<Alumno>();
                alumno = await _context.Alumnos.ToListAsync();
                return Ok(alumno.Where(e => e.Nombre.ToLower().Contains(nombre.ToLower())));
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

        public async Task<ActionResult> Update(int id, Alumno alumnno)
        {
            try
            {
                var alumnoExistente = await _context.Alumnos.FirstOrDefaultAsync(e => e.Id == id);
                if (alumnoExistente == null) return NotFound("El alumno no se encuentra");
                alumnoExistente.Nombre = alumnno.Nombre is null ? alumnoExistente.Nombre : alumnno.Nombre;
                alumnoExistente.Direccion = alumnno.Direccion is null ? alumnoExistente.Direccion : alumnno.Direccion;
                alumnoExistente.Ciudad = alumnno.Ciudad is null ? alumnoExistente.Ciudad : alumnno.Ciudad;
                alumnoExistente.Telefono = alumnno.Telefono is null ? alumnoExistente.Telefono : alumnno.Telefono;
                alumnoExistente.Deudor = alumnno.Deudor is null ? alumnoExistente.Deudor : alumnno.Deudor;
                alumnoExistente.MontoDeuda = alumnno.MontoDeuda is null ? alumnoExistente.MontoDeuda : alumnno.MontoDeuda;
                _context.Alumnos.Update(alumnoExistente);
                await _context.SaveChangesAsync();
                return Ok("Editado");
            }
            catch (Exception error)
            {
                StatusCode(StatusCodes.Status500InternalServerError, new { message = error.Message });
                throw;
            }
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Borrar(int id)
        {
            try
            {
                var alumnoExistente = await _context.Alumnos.FirstOrDefaultAsync(e => e.Id == id);
                _context.Alumnos.Remove(alumnoExistente);
                await _context.SaveChangesAsync();
                return Ok("Editado");
            }
            catch (Exception error)
            {
                StatusCode(StatusCodes.Status500InternalServerError, new { message = error.Message });
                throw;
            }
        }
    }
}
