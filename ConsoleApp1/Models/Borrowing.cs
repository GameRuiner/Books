using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Data.Entity;

namespace ConsoleApp1
{
    class Borrowing //: DbContext
    {
        public User User { get; set; }
        public BookI Book { get; set; }
        public DateTime BTime { get; set; }
        public DateTime RTime { get; set; }
    }
}
