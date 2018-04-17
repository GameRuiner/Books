﻿using ConsoleApp1;
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

        public UserController()
        {
            userService = new UserService();
        }
        // GET: api/User
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return Database.userlist.Select(ulist => ulist.Name);
        }

        // GET: api/User/5
        [HttpGet("{name}")]
        public User Get(string name)
        {
            return Database.userlist.Where(user => user.Name == name).Select(user => user).FirstOrDefault();
        }
        
        // POST: api/User
        [HttpPost]
        public void Post([FromBody]User user)
        {
            Database.userlist.Add(user);
        }
        
        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}