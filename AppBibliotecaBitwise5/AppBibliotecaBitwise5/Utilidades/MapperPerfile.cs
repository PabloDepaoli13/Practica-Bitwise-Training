using AppBibliotecaBitwise5.DTO;
using AppBibliotecaBitwise5.Models;
using AutoMapper;

namespace AppBibliotecaBitwise5.Utilidades
{
    public class MapperPerfile : Profile
    {
        public MapperPerfile() 
        {
            CreateMap<AutorDTO, Autor >().ForMember(e => e.FechaNacimiento, opt => opt.MapFrom(e => DateTime.Parse(e.FechaNacimiento)));
            CreateMap<AutorCreacionDTO, Autor>().ForMember(e => e.FechaNacimiento, opt => opt.MapFrom(e => DateTime.Parse(e.FechaNacimiento)));
            CreateMap<Autor, AutorDTO>().ForMember(e => e.FechaNacimiento, opt => opt.MapFrom(e => e.FechaNacimiento.ToString("dd/MM/yyyy")));


            CreateMap<GeneroCreacionDTO, Genero>().ForMember(e => e.Nombre, opt => opt.MapFrom(e => e.Nombre.ToString()));
            CreateMap<Genero, GeneroDTO>().ForMember(e => e.Nombre, opt => opt.MapFrom(e => e.Nombre));

            CreateMap<ComentarioCreacionDTO, ComentarioDTO>().ReverseMap();
            CreateMap<Comentarios, ComentarioDTO>().ReverseMap();

            CreateMap<Libro, LibroDTO>().
                ForMember(e => e.nombreGenero, opt => opt.MapFrom(e => e.Genero.Nombre)).
                ForMember(e => e.nombreAutor, opt => opt.MapFrom(e => e.Autor.Nombre)).
                ForMember(e => e.FechaPublicacion, opt => opt.MapFrom(e => e.FechaPublicacion.ToString("dd/MM/yyyy")));

            CreateMap<LibroCreacionDTO, Libro >().ForMember(e => e.FechaPublicacion, opt => opt.MapFrom(e => DateTime.Parse(e.FechaPublicacion)));




        }
    }
}
