using Bitwise_8_EntityFramework.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Bitwise_8_EntityFramework.Controllers
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

        [HttpGet("{id}")]

        public async Task<ActionResult> getAlumno(int id)
        {
            try
            {
                var alumno = await _context.Alumnos.FirstOrDefaultAsync(e => e.Id == id);
                if (alumno == null) return NotFound("Alumno no encontrado");
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
                var lista = new List<Alumno>();
                lista = await _context.Alumnos.ToListAsync();

                if (string.IsNullOrEmpty(nombre))
                {
                    return Ok(lista);
                }
                return Ok(lista.Where(e => e.Nombre.ToLower().Contains(nombre.ToLower())));

            }
            catch (Exception error)
            {
                StatusCode(StatusCodes.Status500InternalServerError, new { message = error.Message });
                throw;
            }
        }
        [HttpGet("DeudorMayor")]

        public async Task<ActionResult<IEnumerable<Alumno>>> GetFiltro(int deuda = 0)
        {
            try
            {
                var lista = new List<Alumno>();
                lista = await _context.Alumnos.ToListAsync();

                if (deuda == 0)
                {
                    return Ok(lista);
                }
                var resultados = lista.Where(e => e.MontoDeuda > deuda).ToList();
                if (resultados.Count == 0)
                {
                    return NotFound("No se encontro ningun deudor mayor a la suma");
                }
                return Ok(resultados);

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

        public async Task<ActionResult> Update(int id,Alumno alumno)
        {
            try
            {
                var AlumnoExistente = await _context.Alumnos.FirstOrDefaultAsync(e => e.Id == id);
                if (AlumnoExistente == null) return NotFound("No se encontro el alumno");
                AlumnoExistente.Nombre = alumno.Nombre is null ? AlumnoExistente.Nombre : alumno.Nombre;
                AlumnoExistente.Direccion = alumno.Direccion is null ? AlumnoExistente.Direccion : alumno.Direccion;
                AlumnoExistente.Ciudad = alumno.Ciudad is null ? AlumnoExistente.Ciudad : alumno.Ciudad;
                AlumnoExistente.Telefono = alumno.Telefono is null ? AlumnoExistente.Telefono : alumno.Telefono;
                AlumnoExistente.Deudor = alumno.Deudor is null ? AlumnoExistente.Deudor : alumno.Deudor;
                AlumnoExistente.MontoDeuda = alumno.MontoDeuda is null ? AlumnoExistente.MontoDeuda : alumno.MontoDeuda;
                _context.Alumnos.Update(AlumnoExistente);
                await _context.SaveChangesAsync();
                return Ok("Editado");
            }
            catch (Exception error)
            {
                StatusCode(StatusCodes.Status500InternalServerError, new { message = error.Message });
                throw;
            }
        }

        [HttpDelete]

        public async Task<ActionResult> Eliminar(int id)
        {
            try
            {
                var alumno = await _context.Alumnos.FirstOrDefaultAsync(e => e.Id == id);
                if (alumno == null) return NotFound("No se encontro el alumno");
                _context.Alumnos.Remove(alumno);
                await _context.SaveChangesAsync();
                return Ok("Eliminado");
            }
            catch (Exception error)
            {
                StatusCode(StatusCodes.Status500InternalServerError, new { message = error.Message });
                throw;
            }
        }
    }
}
