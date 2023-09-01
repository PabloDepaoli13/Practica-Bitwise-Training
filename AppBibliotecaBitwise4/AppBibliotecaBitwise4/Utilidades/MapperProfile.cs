using AutoMapper;
using AppBibliotecaBitwise4.Models;
using AppBibliotecaBitwise4.DTO;

namespace AppBibliotecaBitwise4.Utilidades
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateMap<Autor,AutorDTO>().ForMember(e => e.FechaNacimiento, opt => opt.MapFrom(e => e.FechaNacimiento.ToString("dd/MM/yyyy")));

            CreateMap<AutorCreacionDTO, Autor>().ForMember(e => e.FechaNacimiento, opt => opt.MapFrom(e => DateTime.Parse(e.FechaNacimiento)));

            CreateMap<AutorDTO, Autor>().ForMember(e => e.FechaNacimiento, opt => opt.MapFrom(e => DateTime.Parse(e.FechaNacimiento)));


        }
    }
}
