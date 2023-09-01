using Bitwise_9_EntityFramework.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bitwise_9_EntityFramework.Controllers
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

        public async Task<ActionResult<IEnumerable<Alumno>>> GetTables()
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

        public async Task<ActionResult<IEnumerable<Alumno>>> getAlumno(int id)
        {
            try
            {
                var alumno = await _context.Alumnos.FirstOrDefaultAsync(e => e.Id == id);
                if (alumno == null) return NotFound();
                return Ok(alumno);
            }
            catch (Exception error)
            {
                StatusCode(StatusCodes.Status500InternalServerError, new { message = error.Message });
                throw;
            }
        }

        [HttpGet("filtro")]

        public async Task<ActionResult<IEnumerable<Alumno>>> getFiltro(string nombre = null)
        {
            try
            {
                var alumno = await _context.Alumnos.ToListAsync();
                if (alumno == null) return NotFound();
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

        public async Task<ActionResult> Update(int id, Alumno alumno)
        {
            var alumnoExistente = await _context.Alumnos.FirstOrDefaultAsync(e => e.Id == id);

            if (alumnoExistente == null) return NotFound("No existe el cliente solicitado");
            try
            {

                alumnoExistente.Nombre = alumno.Nombre is null ? alumnoExistente.Nombre : alumno.Nombre;
                alumnoExistente.Direccion = alumno.Direccion is null ? alumnoExistente.Direccion : alumno.Direccion;
                alumnoExistente.Ciudad = alumno.Ciudad is null ? alumnoExistente.Ciudad : alumno.Ciudad;
                alumnoExistente.Telefono = alumno.Telefono is null ? alumnoExistente.Telefono : alumno.Telefono;
                alumnoExistente.Deudor = alumno.Deudor is null ? alumnoExistente.Deudor : alumno.Deudor;
                alumnoExistente.MontoDeuda = alumno.MontoDeuda is null ? alumnoExistente.MontoDeuda : alumno.MontoDeuda;
                _context.Alumnos.Update(alumnoExistente);
                await _context.SaveChangesAsync();

                return Ok("Actualizado");
            }
            catch (Exception error)
            {
                StatusCode(StatusCodes.Status500InternalServerError, new { message = error.Message });
                throw;
            }
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var alumno = await _context.Alumnos.FirstOrDefaultAsync(e => e.Id == id);
                if (alumno == null) return NotFound("El alumno no existe");
                _context.Alumnos.Remove(alumno);
                await _context.SaveChangesAsync();
                
                return Ok("Borrado");
            }
            catch (Exception error)
            {
                StatusCode(StatusCodes.Status500InternalServerError, new { message = error.Message });
                throw;
            }
        }

    }
}
