namespace BookMicroservice.Aplicacion
{
    public class BookDTO
    {
        public Guid BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime PublishDate { get; set; }
        public Guid BookAuthor { get; set; }
    }
}
