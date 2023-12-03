using BookAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WriterController : Controller
    {
        private readonly Context context;
        public WriterController(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var writers = context.Writers.ToList();

            if (writers.Count == 0)
            {
                return NotFound("Yazar Bulunmamaktadır.");
            }
            return Ok(writers);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var writers = context.Writers.FirstOrDefault(x => x.Id == id);

            if (writers == null)
            {
                return NotFound($"ID değeri {id} olan yazar bulunamadı.");
            }
            return Ok(writers);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var value = context.Writers.Find(id);
            context.Remove(value);
            context.SaveChanges();
            return Ok($"ID değeri {value.Id} olan yazar başarıyla silindi.");
        }
    }
}

