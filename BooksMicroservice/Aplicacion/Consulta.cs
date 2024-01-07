using AutoMapper;
using BookMicroservice.Modelo;
using BookMicroservice.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookMicroservice.Aplicacion
{
    public class Consulta
    {
        public class Ejecuta : IRequest<List<BookDTO>> { }

        public class Manejador : IRequestHandler<Ejecuta, List<BookDTO>>
        {
            private readonly BookDBContext dBContext;
            private readonly IMapper mapper;
            public Manejador(BookDBContext _dBContext, IMapper _mapper)
            {
                dBContext = _dBContext;
                mapper = _mapper;
            }

            public async Task<List<BookDTO>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                List<Book> books = await dBContext.Books.ToListAsync();                
                List<BookDTO> result = mapper.Map<List<BookDTO>>(books);
                return result;
            }
        }
    }
}
