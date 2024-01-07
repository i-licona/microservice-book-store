using AuthorMicroservice.DTO.Author;
using AuthorMicroservice.Model;
using AutoMapper;

namespace AuthorMicroservice.Helpers
{
  public class AutoMapperHelper:Profile
  {
    public AutoMapperHelper()
    {
      //Parametro 1: El objeto origen
      //Parametro 2: El objeto resultado
      CreateMap<CreateAuthor, Author>();
      CreateMap<Author, AuthorDTO>();
    }
  }
}