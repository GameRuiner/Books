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
            return Database.mainLibrary.Select(library => library.Key);
        }

        // GET api/values/5
        [HttpGet("{name}")]
        public BookI Get(string name)
        {
            return Database.mainLibrary.Where( book => book.Key.Title == name).Select(book => book.Key).FirstOrDefault();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]BookI book)
        {
            Database.mainLibrary.Add(book, false);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
    }
