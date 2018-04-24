using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConsoleApp1
{
    public class User //: DbContext
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public User(string nm)
        {
            Name = nm;
        }
    }
}
