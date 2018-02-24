using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleApp1
{
    
    class UserService
    {
        public List<BookI> Library = new List<BookI>();
        BookI bBook;
        public UserService(User user)
        {
          Library = user.Library;

        }
        public void Borrow(string book)
        {
            
            var selectedbooks = from b in Program.mainLibrary where (b.Title == book) select b;
            if (selectedbooks.Count() > 0)
            {
                bBook = selectedbooks.First();
                Library.Add(bBook);
                Program.mainLibrary.Remove(bBook);
                Console.WriteLine("Book " + book + " successfully borrowed ");
            }
            else
            {
                Console.WriteLine("Library don't contain book " + book);
            }
            
        }
        public void ReturnB(string book)
        {
            var selectedbooks = from b in Library where (b.Title == book) select b;
            if (selectedbooks.Count() > 0)
            {
                bBook = selectedbooks.First();
                Program.mainLibrary.Add(bBook);
                Library.Remove(bBook);
                Console.WriteLine("Book " + book + " successfully returned ");
            }
            else
            {
                Console.WriteLine("You don't have " + book);
            }
           
        }
    }
}
