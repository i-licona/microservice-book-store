#nullable disable
namespace AuthorMicroservice.DTO.Author{
  public class CreateAuthor{
    public string Name { get; set; }
    public string Lastname { get; set; }
    public DateTime? Birthdate { get; set; }    
  }
}