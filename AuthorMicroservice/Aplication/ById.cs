
using AuthorMicroservice.DTO.Author;
using AuthorMicroservice.DTO.Response;
using AuthorMicroservice.Persistence;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AuthorMicroservice.Aplication
{
  public class ById 
  {
    public class GetAuthorById:IRequest<GenericResponse<AuthorDTO>>{
      public int id { get; set; }  
    }
    public class Handler : IRequestHandler<GetAuthorById, GenericResponse<AuthorDTO>>
    {
      private readonly AuthorContext _context;
      private readonly IMapper _mapper;
      public Handler(AuthorContext context, IMapper mapper){
        _context = context;
        _mapper = mapper;
      }
      public async Task<GenericResponse<AuthorDTO>> Handle(GetAuthorById request, CancellationToken cancellationToken){
        var author = await _context.Authors.Where( x => x.IdAuthor == request.id ).FirstOrDefaultAsync();
        if (author == null){
          throw new Exception("No se encontro el recurso solicitado");
        }
        AuthorDTO result = _mapper.Map<AuthorDTO>(author);
        GenericResponse<AuthorDTO> response = new GenericResponse<AuthorDTO>(
          data:result,
          message:"Recursos obtenidos correctamente",
          status:200
        );
        return response;
      }
    }
  }
}