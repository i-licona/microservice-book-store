using BookMicroservice.Modelo;
using BookMicroservice.Persistencia;
using FluentValidation;
using MediatR;

namespace BookMicroservice.Aplicacion
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public string Title { get; set; } = string.Empty;
            public DateTime PublishDate { get; set; }
            public Guid BookAuthor { get; set; }
        }
        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.Title).NotEmpty();
                RuleFor(x => x.PublishDate).NotEmpty();
                RuleFor(x => x.BookAuthor).NotEmpty();
            }
        }
        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly BookDBContext dBContext;
            public Manejador(BookDBContext _dBContext)
            {
                dBContext = _dBContext;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                Book book = new Book
                {
                    Title = request.Title,
                    PublishDate = request.PublishDate,
                    BookAuthor = request.BookAuthor,
                };
                dBContext.Books.Add(book);
                int result = await dBContext.SaveChangesAsync();
                if (result > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se agrego el registro");
            }
        }

    }
}
