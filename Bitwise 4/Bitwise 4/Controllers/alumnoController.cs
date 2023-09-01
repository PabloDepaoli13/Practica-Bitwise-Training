using Bitwise_4.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;

namespace Bitwise_4.Controllers
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

        public async Task<IActionResult> ObtenerTablas()
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
                            lista.Add(new alumno(){
                                Id = Convert.ToInt32(rd["Id"]),
                                Dni = rd["Dni"].ToString(),
                                Nombre = rd["Nombre"].ToString(),
                                Domicilio = rd["Domicilio"].ToString(),
                                Ciudad = rd["Ciudad"].ToString(),
                            });
                        }
                    }
                }
                return Ok(new { message = "Ok", lista});
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = error.Message});
                throw;
            }

        }

        [HttpGet("{id}")]

        public async Task<IActionResult> BuscarTabla(int id)
        {
            alumno alumno = null;
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    await conexion.OpenAsync();
                    var cmd = new SqlCommand("sp_obtener_alumno", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Id", id);
                    using (var rd = await cmd.ExecuteReaderAsync())
                    {
                        if (await rd.ReadAsync())
                        {
                            alumno = new alumno() {

                                Id = Convert.ToInt32(rd["Id"]),
                                Dni = rd["Dni"].ToString(),
                                Nombre = rd["Nombre"].ToString(),
                                Domicilio = rd["Domicilio"].ToString(),
                                Ciudad = rd["Ciudad"].ToString()


                            };
                        }
                    }
                    if (alumno == null)
                    {
                        return NotFound();
                    }
                    return Ok(alumno);
                }
                

            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = error.Message });
                throw;
            }
        }

        [HttpPost]

        public async Task<IActionResult> GuardarAlumno(alumno alumno)
        {
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    await conexion.OpenAsync();
                    var cmd = new SqlCommand("sp_guardar_alumno", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Dni", alumno.Dni);
                    cmd.Parameters.AddWithValue("Nombre", alumno.Nombre);
                    cmd.Parameters.AddWithValue("Domicilio", alumno.Domicilio);
                    cmd.Parameters.AddWithValue("Ciudad", alumno.Ciudad);

                    await cmd.ExecuteNonQueryAsync();
                }
                return StatusCode(StatusCodes.Status200OK, new { message = "Guardado"});
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = error.Message });
                throw;
            }
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> EditarAlumno(int id, alumno alumno)
        {
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
                            Dni2 = rd["Dni"].ToString();
                            Nombre2 = rd["Nombre"].ToString();
                            Domicilio2 = rd["Domicilio"].ToString();
                            Ciudad2 = rd["Ciudad"].ToString();
                        }
                    }
                    cmd = new SqlCommand("sp_editar_alumno", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("Dni", alumno.Dni is null ? Dni2 : alumno.Dni);
                    cmd.Parameters.AddWithValue("Nombre", alumno.Nombre is null ? Nombre2 : alumno.Nombre);
                    cmd.Parameters.AddWithValue("Domicilio", alumno.Domicilio is null ? Domicilio2 : alumno.Domicilio);
                    cmd.Parameters.AddWithValue("Ciudad", alumno.Ciudad is null ? Ciudad2 : alumno.Ciudad);

                    await cmd.ExecuteNonQueryAsync();
                }
                return Ok( new {message = "Ok"});
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = error.Message });
                throw;
            }
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> EliminarAlumno(int id)
        {
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    await conexion.OpenAsync();
                    var cmd = new SqlCommand("sp_eliminar_alumno", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    await cmd.ExecuteNonQueryAsync();
                }
                return StatusCode(StatusCodes.Status200OK, new { message = "Eliminado" });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = error.Message });
                throw;
            }
        }


    }
}
