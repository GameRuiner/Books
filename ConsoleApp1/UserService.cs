using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    
    class UserService
    {
        public List<BookI> Library = new List<BookI>();
        public UserService(User user)
        {
          Library = user.Library;

        }
        public void Borrow(string book)
        {
            foreach (var item in Program.mainLibrary)
            {
                if (item.Title == book)
                {
                    Library.Add(item);
                    Program.mainLibrary.Remove(item);
                    Console.WriteLine("Book " + book + " successfully borrowed ");
                    return;
                }
            }
            Console.WriteLine("Library don't contain book " + book);
        }
        public void ReturnB(string book)
        {
            foreach (var item in Library)
            {
                if (item.Title == book)
                {
                    Program.mainLibrary.Add(item);
                    Library.Remove(item);
                    Console.WriteLine("Book " + book + " successfully returned ");
                    return;

                }
            }
            Console.WriteLine("You don't have " + book);
        }
    }
}
