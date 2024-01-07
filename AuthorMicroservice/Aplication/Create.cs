#nullable disable

using AuthorMicroservice.DTO.Author;
using AuthorMicroservice.DTO.Response;
using AuthorMicroservice.Model;
using AuthorMicroservice.Persistence;
using AutoMapper;
using FluentValidation;
using MediatR;
namespace AuthorMicroservice.Aplication
{
  public class Create
  {
    public class AuthorData:IRequest<GenericResponse<AuthorDTO>>{
      public string Name { get; set; }
      public string Lastname { get; set; }
      public DateTime Birthdate { get; set; }    
    }
    
    public class AuthorDataValidation:AbstractValidator<AuthorData>{
      public AuthorDataValidation(){
        RuleFor( x => x.Name ).NotEmpty();
        RuleFor( x => x.Lastname ).NotEmpty();  
        RuleFor( x => x.Birthdate ).NotEmpty();  
      }
    }

    public class Handler : IRequestHandler<AuthorData, GenericResponse<AuthorDTO>>
    {
      private readonly AuthorContext _context;
      private readonly IMapper _mapper;

      public Handler(AuthorContext context, IMapper mapper )
      {
        _mapper = mapper;
        _context = context;
      }
      public async Task<GenericResponse<AuthorDTO>> Handle(AuthorData request, CancellationToken cancellationToken)
      {
        // Author author = _mapper.Map<Author>(request);
        Author author = new Author {
          Name = request.Name,
          Lastname = request.Lastname,
          Birthdate = request.Birthdate
        };
         // get local timezone
        TimeZoneInfo localTimeZone = TimeZoneInfo.Local;
        author.AuthorGuid = Guid.NewGuid().ToString();
        // conver datetime to utc
        DateTime utcDateTime = TimeZoneInfo.ConvertTimeToUtc(author.Birthdate, localTimeZone);
        author.Birthdate = utcDateTime;
        _context.Authors.Add(author);
        int rowsAfected = await _context.SaveChangesAsync();
        if(rowsAfected > 0) {
          var result = _mapper.Map<AuthorDTO>(author);
          return new GenericResponse<AuthorDTO>(
            data:result, 
            message:"Datos insertados correctamente", 
            status:201
          );
        }
        throw new Exception("No se inserto el autor del libro");
      }
    }
  }
}