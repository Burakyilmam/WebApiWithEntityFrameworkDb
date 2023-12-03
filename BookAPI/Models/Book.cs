using System.Reflection.Metadata;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace BookAPI.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int WriterId { get; set; }
    }
}
