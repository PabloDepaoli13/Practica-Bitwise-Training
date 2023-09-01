using BitwiseAlumnosJulio.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace BitwiseAlumnosJulio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private readonly string cadenaSQL;

        public AlumnoController(IConfiguration config)
        {
            cadenaSQL = config.GetConnectionString("CadenaSQL");

        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            List<Alumno> lista = new List<Alumno>();

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
                            lista.Add(new Alumno()
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
                return Ok(new { mensaje = "ok", response = lista });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message, response = lista });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            try
            {
                Alumno alumno = null;
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                     await conexion.OpenAsync();
                    var cmd = new SqlCommand("sp_obtener_alumno", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);

                    using (var rd = cmd.ExecuteReader())
                    {
                        if ( await rd.ReadAsync())
                        {
                            alumno = new Alumno()
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

                return Ok(new { mensaje = "ok", response = alumno });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Guardar(Alumno alumno)
        {
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    await conexion.OpenAsync();
                    var cmd = new SqlCommand("sp_guardar_alumno", conexion);
                    cmd.Parameters.AddWithValue("Dni", alumno.Dni);
                    cmd.Parameters.AddWithValue("Nombre", alumno.Nombre);
                    cmd.Parameters.AddWithValue("Domicilio", alumno.Domicilio);
                    cmd.Parameters.AddWithValue("Ciudad", alumno.Ciudad);
                    cmd.CommandType = CommandType.StoredProcedure;

                    await cmd.ExecuteNonQueryAsync();
                }

                return Ok(new { mensaje = "ok" });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Editar(int id, Alumno alumno)
        {
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    await conexion.OpenAsync();
                    var cmd = new SqlCommand("sp_obtener_alumno", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);

                    using (var rd = cmd.ExecuteReader())
                    {
                        if (await rd.ReadAsync())
                        {
                            alumno = new Alumno()
                            {
                                Dni = rd["Dni"].ToString(),
                                Nombre = rd["Nombre"].ToString(),
                                Domicilio = rd["Domicilio"].ToString(),
                                Ciudad = rd["Ciudad"].ToString()
                            };
                        }
                    }
                    cmd = new SqlCommand("sp_editar_alumno", conexion);
                    cmd.Parameters.AddWithValue("Id", id);
                    cmd.Parameters.AddWithValue("Dni", alumno.Dni is null ? alumno.Dni : alumno.Dni);
                    cmd.Parameters.AddWithValue("Nombre", alumno.Nombre is null ? alumno.Nombre : alumno.Nombre);
                    cmd.Parameters.AddWithValue("Domicilio", alumno.Domicilio is null ? alumno.Domicilio : alumno.Domicilio);
                    cmd.Parameters.AddWithValue("Ciudad", alumno.Ciudad is null ? alumno.Ciudad : alumno.Ciudad);
                    cmd.CommandType = CommandType.StoredProcedure;

                    await cmd.ExecuteNonQueryAsync();
                }

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "editado" });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Eliminar(int id)
        {
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    await conexion.OpenAsync();
                    var cmd = new SqlCommand("sp_eliminar_alumno", conexion);
                    cmd.Parameters.AddWithValue("Id", id);
                    cmd.CommandType = CommandType.StoredProcedure;

                    await cmd.ExecuteNonQueryAsync();
                }

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Eliminado" });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });
            }
        }
    }
}
