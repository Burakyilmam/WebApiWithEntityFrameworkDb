using BookAPI.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

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
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var categories = context.Categories.ToList();

            if (categories.Count == 0)
            {
                return NotFound("Kategori Bulunmamaktadır.");
            }
            return Ok(categories);
        }
        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var categories = context.Categories.FirstOrDefault(x => x.Id == id);

            if (categories == null)
            {
                return NotFound($"ID değeri {id} olan kategori bulunamadı.");
            }
            return Ok(categories);
        }
        [HttpGet("GetCount")]
        public IActionResult GetCount()
        {
            var categories = context.Categories.Count();

            if (categories == 0)
            {
                return NotFound("Kategori Bulunmamaktadır.");
            }
            return Ok($"{categories} adet kategori bulunmaktadır.");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var value = context.Categories.Find(id);
            context.Remove(value);
            context.SaveChanges();
            return Ok($"ID değeri {value.Id} olan kategori başarıyla silindi.");
        }
        [HttpPost]
        public IActionResult Add(Category category)
        {
            var existingCategory = context.Categories.FirstOrDefault(s => s.Id == category.Id);
            if (existingCategory != null)
            {
                return Conflict($"ID değeri {category.Id} olan kategori zaten mevcut.");
            }
            context.Categories.Add(category);
            context.SaveChanges();

            return Ok("Kategori başarıyla eklendi.");
        }
        [HttpPut]
        public IActionResult Update(string name, int id)
        {
            var value = context.Categories.Find(id);
            value.Name = name;
            context.Update(value);
            context.SaveChanges();
            return Ok($"ID değeri {value.Id} olan kategori başarıyla güncellendi.");
        }
    }
}
