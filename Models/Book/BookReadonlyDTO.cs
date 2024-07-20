using BookStoreApp.Data;

namespace BookStoreApp.Models
{
    public class BookReadonlyDTO : BaseDTO
    {
         public string? Title { get; set; }


        public string? Image { get; set; }

        public double? Price { get; set; }

        public int? AuthorId { get; set; }

        public string? AuthorName { get; set; }

        public virtual Author? Author { get; set; }
    }
}