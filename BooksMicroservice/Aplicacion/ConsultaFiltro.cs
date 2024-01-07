using AutoMapper;
using BookMicroservice.Modelo;
using BookMicroservice.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookMicroservice.Aplicacion
{
    public class ConsultaFiltro
    {
        public class GetBook : IRequest<BookDTO>
        {
            public Guid? BookId { get; set; }
        }

        public class Manejador : IRequestHandler<GetBook, BookDTO>
        {
            private readonly BookDBContext dBContext;
            private readonly IMapper mapper;
            public Manejador(BookDBContext _bookDBContext, IMapper _mapper)
            {
                dBContext= _bookDBContext;
                mapper= _mapper;
            }
            public async Task<BookDTO> Handle(GetBook request, CancellationToken cancellationToken)
            {
                if (string.IsNullOrEmpty(request.BookId.ToString())) throw new Exception("No se ha enviado un filtrado por Id");
                Book book = await dBContext.Books.FirstOrDefaultAsync( x => x.BookId == request.BookId );
                if (book == null) throw new Exception("No se ha encontrado el libro");
                BookDTO result = mapper.Map<BookDTO>(book);
                return result;
            }
        }
    }
}
