using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Linq;



namespace ConsoleApp1
{
    class Database
    {
        public static List<BookI> mainLibrary = new List<BookI>();
        public static List<User> userlist = new List<User>();
        public static List<Borrowing> BorrowingList = new List<Borrowing>();
        public static void AddBorrow(User user, BookI book)
        {
            BorrowingList.Add(new Borrowing(user, book));
        }
        public static void ReturnBorrow(User user, BookI book)
        {
            var selectedborows = from b in Database.BorrowingList where ((b.User == user) && (b.Book == book)) select b;
            if (selectedborows.Count() > 0)
            {
                selectedborows.First().RTime = DateTime.Now;
            }
        }
    }
}
  

