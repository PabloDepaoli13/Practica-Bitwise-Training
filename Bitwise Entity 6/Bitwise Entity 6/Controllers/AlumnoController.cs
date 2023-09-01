using Bitwise_Entity_6.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bitwise_Entity_6.Controllers
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
        
        public async Task<ActionResult<IEnumerable<Alumno>>>GetAll()
        {
            try
            {
                var lista = await _context.Alumnos.ToListAsync();
                return Ok(lista);
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, error.Message);
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
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = error.Message});
                throw;
            }
        }
    }
}
