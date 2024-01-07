#nullable enable
namespace AuthorMicroservice.DTO.Response
{
  public class GenericListResponse<T>
  {
    public GenericListResponse(List<T>? data, string message, int status, int currentPage, int rowsPerPage, int totalPage)
    {
      Data = data;
      Message = message;
      Status = status;
      CurrentPage = currentPage;
      RowsPerPage = rowsPerPage;
      TotalPage = totalPage;
    }
    public GenericListResponse(List<T>? data, string message, int status, string? error)
    {
      Data = data;
      Message = message;
      Status = status;
      Error = error;
    }
    public List<T>? Data { get; set; } 
    public int Status { get; set; }
    public string Message { get; set; } 
    public string? Error { get; set; }
    public int? CurrentPage { get; set; }
    public int? RowsPerPage { get; set; }
    public int? TotalPage { get; set; }
  }
}