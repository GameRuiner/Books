using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class BookI
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

