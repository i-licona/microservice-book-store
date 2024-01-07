#nullable disable

using Microsoft.EntityFrameworkCore;
using AuthorMicroservice.Model;

namespace AuthorMicroservice.Persistence
{
  public class AuthorContext:DbContext   
  {
    public AuthorContext(DbContextOptions options):base(options){}

    public DbSet<Author> Authors { get; set; }
    public DbSet<AcademicGrade> AcademicGrades { get; set; }

  }
}