using AutoMapper;
using BibliotecaAPIBitwise2.Models;
using BibliotecaAPIBitwise2.DTO;

namespace BibliotecaAPIBitwise2.Utilidades
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Autor, AutorDTO>().ForMember(e => e.FechaNacimiento, e => e.MapFrom(opt => opt.FechaNacimiento.ToString()));

            CreateMap<AutorCreacionDTO,Autor>().ForMember(e => e.FechaNacimiento, opt => opt.MapFrom(e => DateTime.Parse(e.FechaNacimiento)));

            CreateMap<AutorDTO, Autor >().ForMember(e => e.FechaNacimiento, opt => opt.MapFrom(e => DateTime.Parse(e.FechaNacimiento)));
        }
    }
}
