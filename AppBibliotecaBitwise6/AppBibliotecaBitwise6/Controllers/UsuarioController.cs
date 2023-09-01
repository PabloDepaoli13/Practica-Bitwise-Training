using AppBibliotecaBitwise6.DAL.Interface;
using AppBibliotecaBitwise6.DTO;
using AppBibliotecaBitwise6.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AppBibliotecaBitwise6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IGenericRepository<Usuario> _repository;
        private readonly IUsuariosRepository _usuariosRepository;
        private readonly IMapper _mapper;
        private RespuestaAPI _respuestaAPI;
        public UsuarioController(IGenericRepository<Usuario> repository, IUsuariosRepository usuariosRepository , IMapper mapper)
        {
            _repository= repository;    
            _usuariosRepository= usuariosRepository;
            _mapper= mapper;
            this._respuestaAPI = new RespuestaAPI();
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> GetUsuarios()
        {
            var usuarios = await _repository.ObtenerTodos();
            var usuariosDTO = _mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);

            return Ok(usuariosDTO);
        }

        [HttpPost]

        public async Task<ActionResult> CargarUsuario(UsuarioRegistroDTO usuario)
        {
            var user = await _usuariosRepository.isUnique(usuario.NombreUsuario);
            if (!user)
            {
                _respuestaAPI.ErrorMessage.Add("El nombre de usuario ya esta en uso");
                _respuestaAPI.StatusCode = HttpStatusCode.NotAcceptable;
                _respuestaAPI.isSucces = false;
                return BadRequest(_respuestaAPI);
            }
           var reslt = await _usuariosRepository.CargarUsuario(usuario);
            if (!reslt) 
            {
                _respuestaAPI.ErrorMessage.Add("Error al cargar al servidor");
                _respuestaAPI.StatusCode = HttpStatusCode.ServiceUnavailable;
                _respuestaAPI.isSucces = false;
                return BadRequest(_respuestaAPI);
            }
            _respuestaAPI.StatusCode = HttpStatusCode.OK;
            _respuestaAPI.ErrorMessage.Add("Cargado con exito");
            _respuestaAPI.isSucces = true;
            _respuestaAPI.Resultado= usuario;
            return Ok(_respuestaAPI);
        }

       [HttpPost("Login")]

        public async Task<IActionResult> LoginUsuario([FromBody]UsuarioLoginDTO usuarioLogin)
        {
            try
            {
                var respuestaLogin = await _usuariosRepository.LoginUsuario(usuarioLogin);
                if (respuestaLogin.usuario == null || respuestaLogin.Token == "")
                {
                    _respuestaAPI.StatusCode = HttpStatusCode.BadRequest;
                    _respuestaAPI.isSucces = false;
                    _respuestaAPI.ErrorMessage.Add("El usuario o contraseña incorrectos");
                    return BadRequest(_respuestaAPI);
                }
                _respuestaAPI.StatusCode = HttpStatusCode.OK;
                _respuestaAPI.ErrorMessage.Add("Loggeado con Exito");
                _respuestaAPI.isSucces = true;
                _respuestaAPI.Resultado = respuestaLogin;
                return Ok(_respuestaAPI);
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = error.Message });    
               
            }
            
        }
       
    }
}
