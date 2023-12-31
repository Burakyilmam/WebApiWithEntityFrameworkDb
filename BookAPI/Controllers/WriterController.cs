﻿using BookAPI.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

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

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var writers = context.Writers.ToList();

            if (writers.Count == 0)
            {
                return NotFound("Yazar Bulunmamaktadır.");
            }
            return Ok(writers);
        }
        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var writers = context.Writers.FirstOrDefault(x => x.Id == id);

            if (writers == null)
            {
                return NotFound($"ID değeri {id} olan yazar bulunamadı.");
            }
            return Ok(writers);
        }
        [HttpGet("GetCount")]
        public IActionResult GetCount()
        {
            var writers = context.Writers.Count();

            if (writers == 0)
            {
                return NotFound("Yazar Bulunmamaktadır.");
            }
            return Ok($"{writers} adet yazar bulunmaktadır.");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var value = context.Writers.Find(id);
            if (value != null)
            {
                context.Remove(value);
                context.SaveChanges();
                return Ok($"ID değeri {value.Id} olan yazar başarıyla silindi.");
            }
            else
            {
                return NotFound("Yazar bulunmamaktadır.");
            }
        }
        [HttpPost]
        public IActionResult Add(Writer writer)
        {
            var existingWriter = context.Writers.FirstOrDefault(s => s.Id == writer.Id);
            if (existingWriter != null)
            {
                return Conflict($"ID değeri {writer.Id} olan yazar zaten mevcut.");
            }
            context.Writers.Add(writer);
            context.SaveChanges();

            return Ok("Yazar başarıyla eklendi.");
        }
        [HttpPut]
        public IActionResult Update(string name, int id)
        {
            var value = context.Writers.Find(id);
            value.Name = name;
            context.Update(value);
            context.SaveChanges();
            return Ok($"ID değeri {value.Id} olan yazar başarıyla güncellendi.");
        }
    }
}

