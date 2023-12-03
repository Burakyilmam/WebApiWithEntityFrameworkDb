namespace BookAPI.Models
{
    public class BookWriter
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int WriterId { get; set; }
        public Writer Writer { get; set; }
    }
}
