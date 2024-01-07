using AutoMapper;
using BookMicroservice.Modelo;

namespace BookMicroservice.Aplicacion
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDTO>().ReverseMap();
        }
    }
}
