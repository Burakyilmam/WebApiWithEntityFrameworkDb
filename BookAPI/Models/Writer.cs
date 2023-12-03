using System.Reflection.Metadata;

namespace BookAPI.Models
{
    public class Writer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Book> books { get; set; }

    }
}
