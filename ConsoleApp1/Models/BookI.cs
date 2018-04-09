﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConsoleApp1
{
    public class BookI //: DbContext
    {
        [Key]
        public int id { get; set; } 
        public string Title { get; set; }
        public string Author { get; set; }
        public BookI(string nm, string au)
        {
            Title = nm;
            Author = au;
        }
    }
}

