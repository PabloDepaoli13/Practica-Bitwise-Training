using AppBibliotecaBitwise3.DTO;
using AppBibliotecaBitwise3.Models;
using AutoMapper;

namespace AppBibliotecaBitwise3.Utilidades
{
    public class AutoMapperClass : Profile
    {
        public AutoMapperClass()
        {
            CreateMap<Autor, AutorDTO>().ForMember(e => e.FechaNacimiento, opt => opt.MapFrom(e => e.FechaNacimiento.ToString("dd/MM/yyyy")));
            CreateMap<AutorCreacionDTO, Autor>().ForMember(e => e.FechaNacimiento, opt => opt.MapFrom(e => DateTime.Parse(e.FechaNacimiento)));
            CreateMap<AutorDTO, Autor>().ForMember(e => e.FechaNacimiento, opt => opt.MapFrom(e => DateTime.Parse(e.FechaNacimiento)));

        }
    }
}
