using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;

namespace ConsoleApp1
{
    class BookI //: DbContext
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public BookI(string nm, string au)
        {
            Title = nm;
            Author = au;
        }
    }
}

