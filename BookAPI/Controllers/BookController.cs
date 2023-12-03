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

        [HttpGet]
        public IActionResult GetAll()
        {
            var books = context.Books.ToList();

            if (books.Count == 0)
            {
                return NotFound("Kitap Bulunmamaktadır.");
            }
            return Ok(books);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var books = context.Books.FirstOrDefault(x => x.Id == id);

            if (books == null)
            {
                return NotFound($"ID değeri {id} olan kitap bulunamadı.");
            }
            return Ok(books);
        }
    }
}
