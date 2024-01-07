using BookMicroservice.Aplicacion;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator mediator;
        public BookController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Add(Nuevo.Ejecuta request)
        {
            return await mediator.Send(request);
        }

        [HttpGet]
        public async Task<ActionResult<List<BookDTO>>> Get()
        {
            return await mediator.Send(new Consulta.Ejecuta());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDTO>> GetById(Guid id)
        {
            return await mediator.Send(new ConsultaFiltro.GetBook { BookId = id });
        }
    }
}
