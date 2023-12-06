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
        [HttpGet("GetByName")]
        public IActionResult GetByName(string name)
        {
            var categories = context.Categories.ToList();

            if (categories.Count == 0)
            {
                return NotFound("Kategori Bulunmamaktadır.");
            }
            
            var query = categories.Where(x=>x.Name == name);

            if(query.Count() == 0)
            {
                return NotFound("Aradığınız isimde kategori bulunmamaktadır.");
            }
            else
            {
                return Ok(query);
            }
        }
        [HttpGet("GetByConstainName")]
        public IActionResult GetByConstainName(string name)
        {
            var categories = context.Categories.ToList();

            if (categories.Count == 0)
            {
                return NotFound("Kategori Bulunmamaktadır.");
            }

            var query = categories.Where(x=>x.Name.Contains(name));

            if (query.Count() == 0)
            {
                return NotFound("Aradığınız isimde kategori bulunmamaktadır.");
            }
            else
            {
                return Ok(query);
            }
        }
        [HttpGet("GetTop5")]
        public IActionResult GetTop5()
        {
            var categories = context.Categories.ToList();

            if (categories.Count == 0)
            {
                return NotFound("Kategori Bulunmamaktadır.");
            }

            return Ok(categories.OrderByDescending(x=>x.Name).Take(5));
        }
        [HttpGet("GetLast5")]
        public IActionResult GetLast5()
        {
            var categories = context.Categories.ToList();

            if (categories.Count == 0)
            {
                return NotFound("Kategori Bulunmamaktadır.");
            }

            return Ok(categories.OrderBy(x => x.Name).Take(5));
        }
        [HttpGet("GetAllSorted")]
        public IActionResult GetAllSorted()
        {
            var categories = context.Categories.ToList();

            if (categories.Count == 0)
            {
                return NotFound("Kategori Bulunmamaktadır.");
            }

            return Ok(categories.OrderBy(x => x.Name));
        }
        [HttpGet("GetAllSortedDescending")]
        public IActionResult GetAllSortedDescending()
        {
            var categories = context.Categories.ToList();

            if (categories.Count == 0)
            {
                return NotFound("Kategori Bulunmamaktadır.");
            }

            return Ok(categories.OrderByDescending(x => x.Name));
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
            if (value != null)
            {
                context.Remove(value);
                context.SaveChanges();
                return Ok($"ID değeri {value.Id} olan kategori başarıyla silindi.");
            }
            else
            {
                return NotFound("Kategori bulunmamaktadır.");
            }
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
