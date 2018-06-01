using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConsoleApp1
{
    public class BookI 
    {
        [Key]
        public int id { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public Boolean Borrowed { get; set; }
        public BookI()
        {
        }
    }
}

