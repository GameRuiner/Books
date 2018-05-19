using ConsoleApp1;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApplication1.Controllers
{
    [Route("api/books")]
    public class BookController : Controller
    {
        private BookService bookService;

        public BookController()
        {
            bookService = new BookService();
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<BookI> Get()
        {
            return _context.Books.Select(library => library);
        }

        // GET api/values/5
        [HttpGet("{name}")]
        public BookI Get(string name)
        {
            return _context.Books.Where( book => book.Title == name).Select(book => book).FirstOrDefault();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]BookI book)
        {
            _context.Books.Add(book);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{title}")]
        public void Delete(String title)
        {
            bookService.RemoveB(title);
        }
    }

}
