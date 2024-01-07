using AuthorMicroservice.Aplication;
using AuthorMicroservice.DTO.Author;
using AuthorMicroservice.DTO.Response;
using AuthorMicroservice.Model;
using AuthorMicroservice.Persistence;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuthorMicroservice.Controllers{
  [ApiController]
  [Route("api/author")]
  public class AuthorController : Controller{
    private readonly AuthorContext _context;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    public AuthorController(AuthorContext context,IMapper mapper, IMediator mediator){
      _mediator = mediator;
      _context = context;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<GenericListResponse<AuthorDTO>>> Get([FromQuery] int currentPage = 1, int rowsPerPage = 10 ){
      List.ListAuthor request = new List.ListAuthor{
        currentPage = currentPage,
        rowsPerPage = rowsPerPage
      };
      try{
        return await _mediator.Send(request); 
      }
      catch (Exception e){
        return BadRequest(new GenericResponse<AuthorDTO>
          (null, "Ha ocurrido un error", 400,e.Message)
        );
      }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<GenericResponse<AuthorDTO>>> GetById(int id){
      ById.GetAuthorById request = new ById.GetAuthorById{
        id = id
      };
      try{
        return await _mediator.Send(request);
      }
      catch (Exception e) 
      {
        return BadRequest(new GenericResponse<AuthorDTO>
          (null, "Ha ocurrido un error", 400,e.Message)
        );
      }
    }

    [HttpPost]
    public async Task<ActionResult<GenericResponse<AuthorDTO>>> Post([FromBody] Create.AuthorData authorDTO)
    {
      try{
        return await _mediator.Send(authorDTO);
      }
      catch (Exception e)
      {
        return BadRequest(new GenericResponse<AuthorDTO>
          (null, "Ha ocurrido un error", 400,e.Message)
        );
      }
    }
  }
}