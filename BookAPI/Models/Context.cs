using Microsoft.EntityFrameworkCore;

namespace BookAPI.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
:       base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Writer> Writers { get; set; }
    }
}
