using AppBibliotecaBitwise7.DAL.DataContext;
using AppBibliotecaBitwise7.DAL.Interfaces;
using AppBibliotecaBitwise7.DTO;
using AppBibliotecaBitwise7.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using XSystem.Security.Cryptography;

namespace AppBibliotecaBitwise7.DAL.Implementations
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuaryRepository
    {
        private readonly DataDbContext _dbContext;
        private string claveSecreta;
        public UsuarioRepository(DataDbContext dbContext, IConfiguration config) : base(dbContext)
        {
            _dbContext = dbContext;
            claveSecreta = config.GetValue<string>("ApiSettings:Secreta");
        }

        public async Task<bool> IsUniqueUser(string usuario)
        {
            var user = await _dbContext.Usuarios.FirstOrDefaultAsync(e => e.NombreUsuario == usuario);
            if (user == null) return true;
            return false;
            
        }

        public async Task<UsuarioLoginRespuestaDTO> Login(UsuarioLoginDTO usuarioLogin)
        {
            var passwordEncriptado = ObtenerMD5(usuarioLogin.Password);

            var key = Encoding.ASCII.GetBytes(claveSecreta);

            var EncontrarUser = await _dbContext.Usuarios.FirstOrDefaultAsync(e => e.NombreUsuario == usuarioLogin.NombreUsuario && passwordEncriptado == e.Password);

            if (EncontrarUser == null)
            {
                return new UsuarioLoginRespuestaDTO()
                {
                    Token = "",
                    usuario = null
                };
            }

            var manejadorToken = new JwtSecurityTokenHandler();
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, EncontrarUser.NombreUsuario.ToString()),
                    new Claim(ClaimTypes.Role, EncontrarUser.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new (new SymmetricSecurityKey(key), 
                SecurityAlgorithms.HmacSha256Signature)

            };

            var token = manejadorToken.CreateToken(tokenDescriptor);

            UsuarioLoginRespuestaDTO usuarioLoginRespuestaDTO = new UsuarioLoginRespuestaDTO()
            {
                Token = manejadorToken.WriteToken(token),
                usuario = EncontrarUser
            };

            return usuarioLoginRespuestaDTO; 


        }

        public async Task<bool> Register(UsuarioRegistroDTO usuarioRegistroDTO)
        {
            var result = false;
            var passwordEnriptado = ObtenerMD5(usuarioRegistroDTO.Password);

            var usuarioNuevo = new Usuario()
            {
                NombreUsuario = usuarioRegistroDTO.NombreUsuario,
                Password = passwordEnriptado,
                Nombre = usuarioRegistroDTO.Nombre,
                Role = usuarioRegistroDTO.Role
            };

            _dbContext.Usuarios.Add(usuarioNuevo);
            usuarioNuevo.Password = passwordEnriptado;
            result = await _dbContext.SaveChangesAsync() > 0;
            
            return result;
        }

        public static string ObtenerMD5(string contrasena)
        {
            MD5CryptoServiceProvider a = new MD5CryptoServiceProvider();
            byte[] data = Encoding.UTF8.GetBytes(contrasena);
            data = a.ComputeHash(data);
            string respuesta = "";


            for (int i = 0; i < data.Length; i++)
            {
                respuesta += data[i].ToString("x2").ToLower();
            }
            return respuesta;
        }
    }
}
