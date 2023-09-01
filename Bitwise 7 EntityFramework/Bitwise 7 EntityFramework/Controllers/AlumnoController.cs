using Bitwise_7_EntityFramework.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bitwise_7_EntityFramework.Controllers
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
                var lista = await _context.Alumnos.ToListAsync();
                return Ok(lista);
            }
            catch (Exception error)
            {
                StatusCode(StatusCodes.Status500InternalServerError, new { message = error.Message });
                throw;
            }
        }

        [HttpGet("{id - GetAlumno}")]

        public async Task<ActionResult<Alumno>> GetById(int id)
        {
            try
            {
                var alumno = await _context.Alumnos.FirstOrDefaultAsync(a => a.Id == id);

                if (alumno == null)
                {
                    return NotFound();
                }

                return Ok(alumno);
            }
            catch (Exception error)
            {
                StatusCode(StatusCodes.Status500InternalServerError, new { message = error.Message });
                throw;
            }
        }

        [HttpGet("filtro")]

        public async Task<ActionResult<IEnumerable<Alumno>>> Filtro(string nombre = null)
        {
            try
            {
                var lista = new List<Alumno>();
                lista = await _context.Alumnos.ToListAsync();

                if (string.IsNullOrEmpty(nombre))
                {
                    return Ok(lista);
                }
                else
                {
                    return Ok(lista.Where(c => c.Nombre.ToLower().Contains(nombre.ToLower())));
                }
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
                if (alumno.MontoDeuda == null) alumno.MontoDeuda = 0;
                _context.Alumnos.Add(alumno);
                await _context.SaveChangesAsync();

                return new CreatedAtRouteResult("GetAlumno", alumno);
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
            var clienteExistente = await _context.Alumnos.FirstOrDefaultAsync(e => e.Id == id);

            if (clienteExistente == null)
            
                return NotFound("No existe el cliente solicitado");
            

            try
            {
                clienteExistente.Nombre = alumno.Nombre is null ? clienteExistente.Nombre : alumno.Nombre;
                clienteExistente.Direccion = alumno.Direccion is null ? clienteExistente.Direccion : alumno.Direccion;
                clienteExistente.Ciudad = alumno.Ciudad is null ? clienteExistente.Ciudad : alumno.Ciudad;
                clienteExistente.Telefono = alumno.Telefono is null ? clienteExistente.Telefono : alumno.Telefono;
                clienteExistente.Deudor = alumno.Deudor is null ? clienteExistente.Deudor : alumno.Deudor;
                clienteExistente.MontoDeuda = alumno.MontoDeuda is null ? clienteExistente.MontoDeuda : alumno.MontoDeuda;

                _context.Alumnos.Update(clienteExistente);
                await _context.SaveChangesAsync();
                return Ok(clienteExistente);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
                throw;
            }
        }

        [HttpDelete("{id}")]        
        public async Task<ActionResult> Delete(int id)
        {
            var alumno = await _context.Alumnos.FirstOrDefaultAsync(e => e.Id == id);
            if (alumno == null) NotFound();
            try
            {
                _context.Alumnos.Remove(alumno);
                await _context.SaveChangesAsync();
                return Ok( new {message = "Borrado"});
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });
                throw;
            }
        }
    }
}
