using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace ConsoleApp1
{
    class Borrowing
    {
        public User User { get; }
        public BookI Book { get; }
        public DateTime BTime { get; }
        public DateTime RTime { get; set; }
        public Borrowing(User user,BookI book)
        {
            User = user;
            Book = book;
            BTime = DateTime.Now;
            RTime = default(DateTime);
            
        }
        void Returning()
        {
            RTime = DateTime.Now;
        }


    }
}
