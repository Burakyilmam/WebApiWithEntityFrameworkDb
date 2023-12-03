using Microsoft.EntityFrameworkCore;

namespace BookAPI.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
:       base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookWriter>()
                .HasKey(bw => new { bw.BookId, bw.WriterId });

            modelBuilder.Entity<BookWriter>()
                .HasOne(bw => bw.Book)
                .WithMany(b => b.BookWriters)
                .HasForeignKey(bw => bw.BookId);

            modelBuilder.Entity<BookWriter>()
                .HasOne(bw => bw.Writer)
                .WithMany(w => w.BookWriters)
                .HasForeignKey(bw => bw.WriterId);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Writer> Writers { get; set; }
    }
}
