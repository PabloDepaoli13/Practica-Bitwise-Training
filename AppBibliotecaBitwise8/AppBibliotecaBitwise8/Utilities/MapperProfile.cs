using AppBibliotecaBitwise8.DTO;
using AppBibliotecaBitwise8.Models;
using AutoMapper;

namespace AppBibliotecaBitwise8.Utilities
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {

            CreateMap<Autor, AutorDTO>().ForMember(e => e.FechaNacimiento, opt => opt.MapFrom(e => e.FechaNacimiento.ToString("dd/MM/yyyy")));
            CreateMap<AutorCreacionDTO, Autor>().ForMember(e => e.FechaNacimiento, opt => opt.MapFrom(e => DateTime.Parse(e.FechaNacimiento)));

            CreateMap<Libro, LibroDTO>().ForMember(e => e.FechaPublic, opt => opt.MapFrom(e => e.FechaPublic.ToString("dd/MM/yyyy"))).ForMember(e => e.nombreAutor, opt => opt.MapFrom(e => e.Autor.Nombre)).ForMember(e => e.nombreGenero, opt => opt.MapFrom(e => e.Generos.Nombre));
            CreateMap<LibroCreacionDTO, Libro>().ForMember(e => e.FechaPublic, opt => opt.MapFrom(e => DateTime.Parse(e.FechaPublic)));
            

            CreateMap<Genero, GeneroDTO>().ReverseMap();
            CreateMap<Genero, GeneroCreacionDTO>().ReverseMap();

            CreateMap<Comentarios, ComentarioDTO>().ReverseMap();
            CreateMap<Comentarios, ComentarioCreacionDTO>().ReverseMap();

            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioRegistroDTO>().ReverseMap();
            
        }
    }

}