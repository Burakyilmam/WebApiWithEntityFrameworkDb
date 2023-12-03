﻿using BookAPI.Models;
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
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var categories = context.Categories.FirstOrDefault(x => x.Id == id);

            if (categories == null)
            {
                return NotFound($"ID değeri {id} olan kategori bulunamadı.");
            }
            return Ok(categories);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var value = context.Categories.Find(id);
            context.Remove(value);
            context.SaveChanges();
            return Ok($"ID değeri {value.Id} olan kategori başarıyla silindi.");
        }
    }
}
