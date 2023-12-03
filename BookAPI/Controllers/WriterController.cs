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
    }
}

