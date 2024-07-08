using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UpSkilling_Task.Entities;
using UpSkilling_Task.Dto;


namespace UpSkilling_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly Context _context;

        public BookController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IReadOnlyList<Book> GetBooks()
        {
            return _context.Books.Include(b => b.Category).ToList();
        }
        [HttpGet("{id}")]
        public ActionResult GetBookById(int id)
        { 
            var book = _context.Books.Include(b => b.Category).FirstOrDefault(b => b.Id == id);
            
            var bookToReturnDto = new BookToReturnDto()
            {
                Description = book.Description,
                Auther = book.Auther,
                CategoryId = book.CategoryId,
                Price = book.Price,
                Id = book.Id,
                CategoryName = book.Category.Name,
                Name = book.Name,
                stock = book.stock,

            };
            return Ok(bookToReturnDto);
        } 
        
        [HttpPost]
        public  IActionResult AddBook(BookDto b)
        {
            var book = new Book()
            {
                Name = b.Name,
                Auther = b.Auther,
                CategoryId = b.CategoryId,
                Price = b.Price,
                Description = b.Description,
            };
            
            _context.Books.Add(book);
            _context.SaveChanges();
            _context.Books.Include(b => b.Category).FirstOrDefault(b => b.Id == book.Id);

            var bookToReturnDto = new BookToReturnDto()
            {
                Description = book.Description,
                Auther = book.Auther,
                CategoryId = book.CategoryId,
                Price = book.Price,
                Id = book.Id,
                CategoryName = book.Category.Name,
                Name = book.Name,
                stock = book.stock,

            };
            return Ok(bookToReturnDto);

        }
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, BookDto bookDto) {


            var book = _context.Books.Find(id);
            book.Name = bookDto.Name;
            book.Auther = bookDto.Auther;
            book.Description = bookDto.Description;
            book.Price = bookDto.Price;
            book.CategoryId = bookDto.CategoryId;
            book.stock = bookDto.stock;

            _context.Books.Update(book);
            _context.SaveChanges();
            return Ok(book);
 

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _context.Books.Find(id);

            _context.Remove(book);
            _context.SaveChanges();
            return Ok();


        }



    }
}


