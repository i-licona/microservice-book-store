using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorMicroservice.DTO.Author;
using AuthorMicroservice.DTO.Response;
using AuthorMicroservice.Model;
using AuthorMicroservice.Persistence;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AuthorMicroservice.Aplication
{ 
  public class List
  {
    public class ListAuthor: IRequest<GenericListResponse<AuthorDTO>>{
      public int currentPage;
      public int rowsPerPage;
    }
    public class Handler : IRequestHandler<ListAuthor, GenericListResponse<AuthorDTO>>
    {
      private readonly AuthorContext _context;
      private readonly IMapper _mapper;
      public Handler(AuthorContext context, IMapper mapper)
      {
        _mapper = mapper;
        _context = context;        
      }
      public async Task<GenericListResponse<AuthorDTO>> Handle(ListAuthor request, CancellationToken cancellationToken)
      {
        int totalRows = await _context.Authors.CountAsync(); 
        double totalPage = Math.Ceiling(Convert.ToDouble(totalRows) / request.rowsPerPage );

        List<Author> data = await _context.Authors
          .OrderByDescending(x => x.IdAuthor)
          .Skip((request.currentPage - 1) * request.rowsPerPage)
          .Take(request.rowsPerPage)
          .ToListAsync();
        List<AuthorDTO> result = _mapper.Map<List<AuthorDTO>>(data);
        GenericListResponse<AuthorDTO> response = new GenericListResponse<AuthorDTO>(
          data:result,
          message:"Recursos obtenidos correctamente",
          status:200,
          currentPage:request.currentPage,
          rowsPerPage:request.rowsPerPage,
          totalPage:Convert.ToInt32(totalPage)
        );
        return response;
      }
    }
  }
}