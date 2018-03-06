using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace ConsoleApp1
{
    class Borrowing
    {
        public User User { get; set; }
        public BookI Book { get; set; }
        public DateTime BTime { get; set; }
        public DateTime RTime { get; set; }
    }
}
