namespace BookStoreApp.Models
{
    public class BookDetailsDTO : BaseDTO
    {
        public string? Title { get; set; }

        public int? Year { get; set; }

        public string Isbn { get; set; } = null!;

        public string Summary { get; set; } = null!;

        public string? Image { get; set; }

        public double? Price { get; set; }

        public int? AuthorId { get; set; }

        public string? AuthorName { get; set; }
    }
}