
namespace AuthorMicroservice.DTO.Response
{
  public class GenericResponse<T>
  {
    public GenericResponse(T? data, string message, int status)
    {
      Data = data;
      Message = message;
      Status = status;
    }
    public GenericResponse(T? data, string message, int status, string? error)
    {
      Data = data;
      Message = message;
      Status = status;
      Error = error;
    }
    public T? Data { get; set; } 
    public int Status { get; set; }
    public string Message { get; set; } 
    public string? Error { get; set; }
  }
}