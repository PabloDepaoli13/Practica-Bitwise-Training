using AppBibliotecaBitwise6.DAL.DataContext;
using AppBibliotecaBitwise6.DAL.Interface;
using AppBibliotecaBitwise6.DTO;
using AppBibliotecaBitwise6.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using XSystem.Security.Cryptography;

namespace AppBibliotecaBitwise6.DAL.Implementation
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuariosRepository
    {
         private readonly AplicationDbContext _context;
        private string claveSecreta;
        
        public UsuarioRepository(AplicationDbContext context, IConfiguration config) : base(context)
        {
            _context = context;
            claveSecreta = config.GetValue<string>("APIRespuesta:ClaveSecreta");
        }

        public async Task<bool> CargarUsuario(UsuarioRegistroDTO usuarioRegistroDTO)
        {
            var result = false;
            var passwordEncriptado = MD5password(usuarioRegistroDTO.Password);

            var usuarioNuevo = new Usuario() 
            { 
                NombreUsuario = usuarioRegistroDTO.NombreUsuario,
                Nombre = usuarioRegistroDTO.Nombre,
                Password= passwordEncriptado,
                Role= usuarioRegistroDTO.Role
            };

            _context.Usuarios.Add(usuarioNuevo);
            usuarioNuevo.Password = passwordEncriptado;
            result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<bool> isUnique(string usuario)
        {
            var usuarioNew = await _context.Usuarios.FirstOrDefaultAsync(e => e.NombreUsuario == usuario);
            if (usuarioNew == null) return true;
            return false;
        }

        public async Task<UsuarioLoginRespuestaDTO> LoginUsuario(UsuarioLoginDTO usuarioA) 
        { 
              var passwordEncriptado = MD5password(usuarioA.Password);

            var usuarioEncontrado = await _context.Usuarios.FirstOrDefaultAsync(e => e.NombreUsuario == usuarioA.NombreUsuario && passwordEncriptado == e.Password);

            if(usuarioEncontrado == null)
            {
                return new UsuarioLoginRespuestaDTO()
                {
                    Token = "",
                    usuario = null
                };
            }
            var manejadorToken = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(claveSecreta);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuarioEncontrado.ToString()),
                    new Claim(ClaimTypes.Role, usuarioEncontrado.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };

            var token = manejadorToken.CreateToken(tokenDescriptor);

            UsuarioLoginRespuestaDTO usuarioLoginRespuestaDTO = new UsuarioLoginRespuestaDTO()
            {
                Token = manejadorToken.WriteToken(token),
                usuario = usuarioEncontrado
            };
            return usuarioLoginRespuestaDTO;

        }

        public static string MD5password(string pass)
        {
            MD5CryptoServiceProvider a = new MD5CryptoServiceProvider();
            byte[] data = Encoding.ASCII.GetBytes(pass);
            data = a.ComputeHash(data);
            var stringNuevo = "";

            for (int i = 0; i < data.Length; i++)
            {
                stringNuevo += data[i].ToString("x2").ToLower(); 
            }
            return stringNuevo; 
        }
    }
}
