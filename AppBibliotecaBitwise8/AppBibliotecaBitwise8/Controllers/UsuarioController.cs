using AppBibliotecaBitwise8.DAL.Interfaces;
using AppBibliotecaBitwise8.DTO;
using AppBibliotecaBitwise8.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AppBibliotecaBitwise8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        protected RespuestaAPI _respuestaApi;

        public UsuarioController(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository= usuarioRepository;
            _mapper=mapper;
            this._respuestaApi=new RespuestaAPI();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> MostrarUsuarios()
        {
            var usuarios = await _usuarioRepository.GetAll();
            var usuariosNew = _mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);
            return Ok(usuariosNew);
        }

        [Authorize(Roles ="admin")]
        [HttpPost]

        public async Task<ActionResult> CargarUsuario(UsuarioRegistroDTO usuario)
        {
            var isUnic = await _usuarioRepository.isUnique(usuario.NombreUsuario);
            if (!isUnic)
            {
                _respuestaApi.StatusCode = HttpStatusCode.BadRequest;
                _respuestaApi.ErrorMessages.Add("El nombre de usuario ya esta en uso");
                _respuestaApi.isSucces = false;
                return BadRequest(_respuestaApi);
            }
            var result = await _usuarioRepository.RegisterUser(usuario);
            if (!result)
            {
                _respuestaApi.StatusCode = HttpStatusCode.NotImplemented;
                _respuestaApi.ErrorMessages.Add("Problema con la carga del usuario");
                _respuestaApi.isSucces=false;
                return BadRequest(_respuestaApi);
            }
            _respuestaApi.StatusCode=HttpStatusCode.OK;
            _respuestaApi.ErrorMessages.Add("Cargado con exito");
            _respuestaApi.isSucces = true;
            _respuestaApi.Result= result;
            return Ok(_respuestaApi);

        }

        [HttpPost("login")]

        public async Task<IActionResult> SubirUsuario(UsuarioLoginDTO usuarioLogin)
        {
            var usuarioToken = await _usuarioRepository.LoginUser(usuarioLogin);
            if (usuarioToken.Token == "" || usuarioToken.usuario == null)
            {
                _respuestaApi.StatusCode = HttpStatusCode.BadRequest;
                _respuestaApi.ErrorMessages.Add("El usuario o contrseña son incorrectos");
                _respuestaApi.isSucces = false;
                return BadRequest(_respuestaApi);
            }
            _respuestaApi.StatusCode = HttpStatusCode.OK;
            _respuestaApi.ErrorMessages.Add("Inicio de sesion correcto");
            _respuestaApi.isSucces = true;
            _respuestaApi.Result = usuarioToken;
            return Ok(_respuestaApi);
        }
    }
}
