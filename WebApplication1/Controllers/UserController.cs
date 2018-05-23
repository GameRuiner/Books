using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        private UserService userService;
        private Context _context = new Context();

        public UserController()
        {
            userService = new UserService();
        }
        // GET: api/User
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _context.Users;
        }

        // GET: api/User/5
        [HttpGet("{name}")]
        public User Get(string name)
        {
            return _context.Users.Where(user => user.Name == name).Select(user => user).FirstOrDefault();
        }
        
        // POST: api/User
        [HttpPost]
        public void Post([FromBody]User user)
        {
            _context.Users.Add(user);
        }
        
        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            User u = new ConsoleApp1.User(value);
            u.id = id;
            _context.Users.Add(u);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
