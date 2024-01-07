#nullable disable

using System.ComponentModel.DataAnnotations;

namespace AuthorMicroservice.Model
{
  public class Author
  {
    [Key]
    public int IdAuthor { get; set; }
    public string Name { get; set; }
    public string Lastname { get; set; }
    public DateTime Birthdate { get; set; }    
    public List<AcademicGrade> AcademicGrades { get; set; }
    public string AuthorGuid { get; set; }
  }
}