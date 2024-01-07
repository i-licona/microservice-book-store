#nullable disable
namespace AuthorMicroservice.DTO.Author{
  public class AuthorDTO{
    public int IdAuthor { get; set; }
    public string Name { get; set; }
    public string Lastname { get; set; }
    public DateTime? Birthdate { get; set; }    
    public string AuthorGuid { get; set; }   
  }
}