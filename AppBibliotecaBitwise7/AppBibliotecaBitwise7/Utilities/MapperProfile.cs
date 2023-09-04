using AppBibliotecaBitwise7.DTO;
using AppBibliotecaBitwise7.Models;
using AutoMapper;

namespace AppBibliotecaBitwise7.Utilities
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Autor, AutorDTO>().ForMember(e => e.FechaNac, opt => opt.MapFrom(e => e.FechaNac.ToString("dd/MM/yyyy")));
            CreateMap<AutorCreacionDTO, Autor>().ForMember(e => e.FechaNac, opt => opt.MapFrom(e => DateTime.Parse(e.FechaNac)));

            CreateMap<Libro, LibroDTO>().ForMember(e => e.FechaPublic, opt => opt.MapFrom(e => e.FechaPublic.ToString("dd/MM/yyyy"))).ForMember(e => e.nombreGenero, opt => opt.MapFrom(e => e.Genero.Nombre)).ForMember(e => e.nombreAutor, opt => opt.MapFrom(e => e.Autor.Nombre));
            CreateMap<Libro, LibroGeneroDTO>().ForMember(e => e.FechaPublic, opt => opt.MapFrom(e => e.FechaPublic.ToString("dd/MM/yyyy"))).ForMember(e => e.nombreGenero, opt => opt.MapFrom(e => e.Genero.Nombre));

            CreateMap<LibroCreacionDTO, Libro>().ForMember(e => e.FechaPublic, opt => opt.MapFrom(e => DateTime.Parse(e.FechaPublic)));

            CreateMap<ComentarioDTO, Comentario>();
            CreateMap<Comentario, ComentarioDTO>().ForMember(e => e.NombreLibro, e => e.MapFrom(e => e.Libro.Nombre));
            CreateMap<ComentarioCreacionDTO, Comentario>().ReverseMap();

            CreateMap<Genero, GeneroDTO>().ReverseMap();
            CreateMap<GeneroCreacionDTO, Genero>().ReverseMap();


            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<UsuarioRegistroDTO, Usuario>().ReverseMap();


            

        }
    }
}
