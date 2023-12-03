using BookAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly Context context;
        public BookController(Context context)
        {
            this.context = context;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var books = context.Books.ToList();

            if (books.Count == 0)
            {
                return NotFound("Kitap Bulunmamaktadır.");
            }
            return Ok(books);
        }
        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var books = context.Books.FirstOrDefault(x => x.Id == id);

            if (books == null)
            {
                return NotFound($"ID değeri {id} olan kitap bulunamadı.");
            }
            return Ok(books);
        }
        [HttpGet("GetCount")]
        public IActionResult GetCount()
        {
            var books = context.Books.Count();

            if (books == 0)
            {
                return NotFound("Kitap Bulunmamaktadır.");
            }
            return Ok($"{books} adet kitap bulunmaktadır.");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var value = context.Books.Find(id);
            if(value != null)
            {
                context.Remove(value);
                context.SaveChanges();
                return Ok($"ID değeri {value.Id} olan kitap başarıyla silindi.");
            }
            else
            {
                return NotFound("Kitap Bulunmamaktadır.");
            }
           
        }
        [HttpPost]
        public IActionResult Add(Book book)
        {

            var existingBook = context.Books.FirstOrDefault(s => s.Id == book.Id);
            if (existingBook != null)
            {
                return Conflict($"ID değeri {book.Id} olan kitap zaten mevcut.");
            }

            context.Books.Add(book);
            context.SaveChanges();

            return Ok("Kitap başarıyla eklendi.");
        }
        [HttpPut]
        public IActionResult Update(string name,decimal price,int categoryId,int writerId,int id)
        {
            var value = context.Books.Find(id);
            value.Name = name;
            value.Price = price;
            value.WriterId = writerId;
            value.CategoryId = categoryId;
            context.Update(value);
            context.SaveChanges();
            return Ok($"ID değeri {value.Id} olan kitap başarıyla güncellendi.");
        }
    }
}
