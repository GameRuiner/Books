using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    interface IBookService
    {
        List<BookI> AddB(string title, string author);

        List<BookI> RemoveB(string title);

        List<BookI> EditB(string title);

        void BookList(User user);
    }
}
