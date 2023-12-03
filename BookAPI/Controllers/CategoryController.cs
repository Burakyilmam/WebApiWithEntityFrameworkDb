using BookAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly Context context;
        public CategoryController(Context context) {
            this.context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = context.Categories.ToList();

            if (categories.Count == 0)
            {
                return NotFound("Kategori Bulunmamaktadır.");
            }
            return Ok(categories);
        }
    }
}
