using AppBibliotecaBitwise6.DTO;
using AppBibliotecaBitwise6.Models;
using AutoMapper;

namespace AppBibliotecaBitwise6.Utilidades
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Autor, AutorDTO>().ForMember(e => e.FechaNacimiento, opt => opt.MapFrom(e => e.FechaNacimiento.ToString("dd/MM/yyyy")));
            CreateMap<AutorCreacionDTO, Autor>().ForMember(e => e.FechaNacimiento, opt => opt.MapFrom(e => DateTime.Parse(e.FechaNacimiento)));

            CreateMap<Libro, LibroDTO>().ForMember(e => e.FechaPublicacion, opt => opt.MapFrom(e => e.FechaPublicacion.ToString("dd/MM/yyyy")));
            CreateMap<Libro, LibroNombresDTO>().ForMember(e => e.NombreGenero, opt => opt.MapFrom(e => e.Genero.Nombre)).ForMember(e => e.NombreAutor, opt => opt.MapFrom(e => e.Autor.Nombre)).ForMember(e => e.FechaPublicacion, opt => opt.MapFrom(e => e.FechaPublicacion.ToString("dd/MM/yyyy")));


            CreateMap<LibroCreacionDTO, Libro>().ForMember(e => e.FechaPublicacion, opt => opt.MapFrom(e => DateTime.Parse(e.FechaPublicacion)));

            CreateMap<Genero, GeneroDTO>().ReverseMap();
            CreateMap<GeneroCreacionDTO, Genero>().ReverseMap();

            CreateMap<Comentario, ComentarioDTO>().ReverseMap();
            CreateMap<ComentarioCreacionDTO, Comentario>().ReverseMap();

            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioRegistroDTO>().ReverseMap();
            
        }
    }
}
