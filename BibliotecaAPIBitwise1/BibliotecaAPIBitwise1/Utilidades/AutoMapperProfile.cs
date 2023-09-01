using AutoMapper;
using BibliotecaAPIBitwise1.DTO;
using BibliotecaAPIBitwise1.Models;

namespace BibliotecaAPIBitwise1.Utilidades
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Autor, AutorDTO>().ForMember(d => d.FechaNacimiento, opt => opt.MapFrom(o => o.FechaNacimiento.ToString("dd/MM/yyyy")));

            CreateMap<AutorCreacionDTO, Autor>().ForMember(d => d.FechaNacimiento, opt => opt.MapFrom(e => DateTime.Parse(e.FechaNacimiento)));
        }
    }
}
