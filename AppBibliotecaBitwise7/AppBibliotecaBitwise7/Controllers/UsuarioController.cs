using AppBibliotecaBitwise7.DAL.Interfaces;
using AppBibliotecaBitwise7.DTO;
using AppBibliotecaBitwise7.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AppBibliotecaBitwise7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IGenericRepository<Usuario> _repository;
        private readonly IUsuaryRepository _usuarioRepository;
        private readonly IMapper _mapper;
        protected RespuestaApi respuestaApi;

        public UsuarioController(IGenericRepository<Usuario> repository, IUsuaryRepository usuarioRepository, IMapper mapper)
        {
            _repository = repository;
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            this.respuestaApi = new RespuestaApi();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> ObtenerTodos()
        {
            var usuarios = await _usuarioRepository.GetAll();
            var usuariosDTO = _mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);
            return Ok(usuariosDTO);
        }

        [HttpPost]

        public async Task<ActionResult> RegistrarUsuario(UsuarioRegistroDTO usuarioRegistro)
        {
            var isUnique = await _usuarioRepository.IsUniqueUser(usuarioRegistro.NombreUsuario);
            if (isUnique == false)
            {
                respuestaApi.StatusCode = HttpStatusCode.BadRequest;
                respuestaApi.IsSuccess = false;
                respuestaApi.ErrorMenssages.Add("Problema: El usuario ya esta en uso");
                return BadRequest(respuestaApi);
            }
            var resultado = await _usuarioRepository.Register(usuarioRegistro);
            if (!resultado)
            {
                respuestaApi.StatusCode = HttpStatusCode.BadRequest;
                respuestaApi.IsSuccess = false;
                respuestaApi.ErrorMenssages.Add("Problema: El usuario no pudo ser cargado");
                return BadRequest(respuestaApi);
            }
            respuestaApi.StatusCode = HttpStatusCode.Created;
            respuestaApi.IsSuccess = true;
            respuestaApi.ErrorMenssages.Add("Cargado con exito");
            respuestaApi.Result = usuarioRegistro;
           
            return Ok(respuestaApi);
        }

        [HttpPost("Login")]

        public async Task<IActionResult> Login([FromBody] UsuarioLoginDTO usuarioLoginDTO)
        {
            var respuestaLogin = await _usuarioRepository.Login(usuarioLoginDTO);
            if(respuestaLogin.usuario == null || string.IsNullOrEmpty(respuestaLogin.Token)) 
            {
                respuestaApi.StatusCode=HttpStatusCode.BadRequest;
                respuestaApi.IsSuccess = false;
                respuestaApi.ErrorMenssages.Add("El usuario o contraseña incorrectos");
                return BadRequest(respuestaApi);
            }
            respuestaApi.StatusCode = HttpStatusCode.OK;
            respuestaApi.IsSuccess = true;
            respuestaApi.Result= respuestaLogin;
            return Ok(respuestaApi);
        }

    }

}
