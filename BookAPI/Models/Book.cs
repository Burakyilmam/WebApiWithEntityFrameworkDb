using System.Reflection.Metadata;

namespace BookAPI.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category categories { get; set; }
        public List<BookWriter> BookWriters { get; set; }
    }
}
