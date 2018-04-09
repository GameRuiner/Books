using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Linq;



namespace ConsoleApp1
{
    public class Database
    {
        public static Dictionary<BookI, bool> mainLibrary = new Dictionary<BookI, bool>();
        public static List<User> userlist = new List<User>();
        public static List<Borrowing> BorrowingList = new List<Borrowing>();

    }
}
  

