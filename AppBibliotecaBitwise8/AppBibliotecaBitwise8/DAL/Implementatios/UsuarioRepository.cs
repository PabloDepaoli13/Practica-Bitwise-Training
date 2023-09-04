using AppBibliotecaBitwise8.DAL.DataContext;
using AppBibliotecaBitwise8.DAL.Interfaces;
using AppBibliotecaBitwise8.DTO;
using AppBibliotecaBitwise8.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using XSystem.Security.Cryptography;

namespace AppBibliotecaBitwise8.DAL.Implementatios
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        private readonly AplicationDataContext _dataContext;
        private string claveSecreta;
        public UsuarioRepository(AplicationDataContext dataContext, IConfiguration config) : base(dataContext)
        {
            _dataContext = dataContext;
            claveSecreta = config.GetValue<string>("APIConfig:ClaveSecreta");
        }

        public async Task<bool> isUnique(string nombreUser)
        {
            
            var user = await _dataContext.usuarios.FirstOrDefaultAsync(e => e.NombreUsuario == nombreUser);
            if (user == null) return true;
            return false;
        }

        public async Task<UsuarioLoginRespuestaDTO> LoginUser(UsuarioLoginDTO usuario)
        {
            var contraseñaEncriptada = MD5pass(usuario.Password);

            var userEncontrado = _dataContext.usuarios.FirstOrDefault(e => e.NombreUsuario == usuario.NombreUsuario && e.Password == contraseñaEncriptada);

            if (userEncontrado == null)
            {
                return new UsuarioLoginRespuestaDTO()
                {
                    Token = "",
                    usuario = null
                };
            }

            var manejadorToken = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(claveSecreta);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name , userEncontrado.NombreUsuario.ToString()),
                    new Claim(ClaimTypes.Role , userEncontrado.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = manejadorToken.CreateToken(tokenDescriptor);

            UsuarioLoginRespuestaDTO usuarioLoginRespuestaDTO = new UsuarioLoginRespuestaDTO()
            {
                Token = manejadorToken.WriteToken(token),
                usuario = userEncontrado

            };
            return usuarioLoginRespuestaDTO;


        }

        public async Task<bool> RegisterUser(UsuarioRegistroDTO usuario)
        {
            var contraseñaNew = MD5pass(usuario.Password);
            var result = false;
            
            var usuarioNew = new Usuario()
            {
                NombreUsuario = usuario.NombreUsuario,
                Password = contraseñaNew,
                Nombre = usuario.Nombre,
                Role = usuario.Role
            };

            _dataContext.usuarios.Add(usuarioNew);
            usuarioNew.Password = contraseñaNew;
            result = await _dataContext.SaveChangesAsync() > 0;
            return result;
            
        }

        public static string MD5pass(string pass)
        {
            MD5CryptoServiceProvider a = new MD5CryptoServiceProvider();
            byte[] data = Encoding.UTF8.GetBytes(pass);
            data = a.ComputeHash(data);
            var datos = "";

            for (int i = 0; i < data.Length; i++)
            {
                datos += data[i].ToString("x2").ToLower();
            }

            return datos;
        }


    }
}
