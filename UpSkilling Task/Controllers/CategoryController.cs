using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UpSkilling_Task.Dto;
using UpSkilling_Task.Entities;

namespace UpSkilling_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly Context _context;

        public CategoryController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IReadOnlyList<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }
        [HttpGet("{id}")]
        public Category CategoryById(int id)
            => _context.Categories.FirstOrDefault(c=>c.Id==id);
        [HttpPost]
        public IActionResult AddCategory(CategoryDto c)
        {
            var category = new Category()
            {
                Description = c.Description,
                 Name = c.Name   
            
            };

            _context.Categories.Add(category);
            _context.SaveChanges();
            //var bookToReturnDto = new BookToReturnDto()
            //{
            //    //    Description = book.Description,
            //    //    Auther = book.Auther,
            //    //    CategoryId = book.CategoryId,
            //    //    Price = book.Price,
            //    //    Id = book.Id,
            //    CategoryName = book.Category.Name,
            //    //    Name = book.Name,
            //    //    stock = book.stock,

            //};
            return Ok(category);

        }
        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, CategoryDto c)
        {


            var category = _context.Categories.Find(id);
            category.Name = c.Name;
            category.Description = c.Description;

            _context.Categories.Update(category);
            _context.SaveChanges();
            return Ok(category);


        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _context.Categories.Find(id);

            _context.Remove(category);
            _context.SaveChanges();
            return Ok();


        }


    }
}
