using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public interface IBookService
    {
        IEnumerable<BookI> Library();

        void AddB(string title, string author);

        void RemoveB(string title);

        void EditB(string title);

        void BookList(User user);
    }
}
