using Bitwise_5.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace Bitwise_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class alumnoController : ControllerBase
    {
        private readonly string cadenaSQL;

        private string Dni2, Nombre2, Domicilio2, Ciudad2;

        public alumnoController(IConfiguration config)
        {
            cadenaSQL = config.GetConnectionString("CadenaSQL");
        }

        [HttpGet]

        public async Task<IActionResult> PedirTablas()
        {
            List<alumno> lista = new List<alumno>();

            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    await conexion.OpenAsync();
                    var cmd = new SqlCommand("sp_lista_alumnos", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd = await cmd.ExecuteReaderAsync())
                    {
                        while (await rd.ReadAsync())
                        {
                            lista.Add(new alumno()
                            {
                                Id = Convert.ToInt32(rd["Id"]),
                                Dni = rd["Dni"].ToString(),
                                Nombre = rd["Nombre"].ToString(),
                                Domicilio = rd["Domicilio"].ToString(),
                                Ciudad = rd["Ciudad"].ToString()
                            });
                        }
                    }
                }
                return Ok(lista);
            }
            catch (Exception error)
            {
                StatusCode(StatusCodes.Status500InternalServerError, new { message = error.Message});
                throw;
            }
        }


        [HttpGet("{id}")]


        public  async Task<IActionResult> ObtenerTabla(int id)
        {
            alumno alumno = null;
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    await conexion.OpenAsync();
                    var cmd = new SqlCommand("sp_obtener_alumno", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (var rd = await cmd.ExecuteReaderAsync())
                    {
                        if (await rd.ReadAsync())
                        {
                            alumno = new alumno()
                            {
                                Id = Convert.ToInt32(rd["Id"]),
                                Dni = rd["Dni"].ToString(),
                                Nombre = rd["Nombre"].ToString(),
                                Domicilio = rd["Domicilio"].ToString(),
                                Ciudad = rd["Ciudad"].ToString()
                            };
                        }
                    }
                }
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

        [HttpPost]

        public async Task<IActionResult> EnviarTabla(alumno alumno)
        {
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    await conexion.OpenAsync();
                    var cmd = new SqlCommand("sp_guardar_alumno", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.Parameters.AddWithValue("@Dni", alumno.Dni);
                    cmd.Parameters.AddWithValue("@Nombre", alumno.Nombre);
                    cmd.Parameters.AddWithValue("@Domicilio", alumno.Domicilio);
                    cmd.Parameters.AddWithValue("@Ciudad", alumno.Ciudad);

                    await cmd.ExecuteNonQueryAsync();

                }
                return Ok(new {message = "Enviado"});
            }
            catch (Exception error)
            {
                StatusCode(StatusCodes.Status500InternalServerError, new { message = error.Message });
                throw;
            }
        }
    }
}
