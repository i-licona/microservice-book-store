namespace BookMicroservice.Modelo
{
    public class Book
    {
        public Guid BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime PublishDate { get; set; }
        public Guid BookAuthor { get; set; }
    }
}
