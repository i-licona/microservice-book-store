#nullable disable

using System.ComponentModel.DataAnnotations;

namespace AuthorMicroservice.Model
{
  public class AcademicGrade
  {
    [Key]
    public int IdAcademicGrade { get; set; }
    public string Name { get; set; }
    public string CenterAcademic { get; set; }
    public DateTime? DateGrade { get; set; }
    public int IdAuthor { get; set; }
    public Author Author { get; set; }
    public string AcademicGradeGuid { get; set; }
  }
}