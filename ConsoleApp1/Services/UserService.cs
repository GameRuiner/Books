using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleApp1
{
    
    class UserService : IUserService
    {
        private Context _context;

        public UserService()
        {
            _context = new Context();
        }

        public void Borrow(string book, User user)
        {
            
            var selectedbooks = from b in Database.mainLibrary where (b.Key.Title == book) select b;
            BookI bBook;
            bBook = selectedbooks.FirstOrDefault().Key;
            if (bBook!=null)
            {
                Database.BorrowingList.Add (new Borrowing() { User = user, Book = bBook, BTime = DateTime.Now });
                Database.mainLibrary[bBook] = true;
                Console.WriteLine("Book " + book + " successfully borrowed ");
            }
            else
            {
                Console.WriteLine("Library don't contain book " + book);
            }
            
        }
        public void ReturnB(string book, User user)
        {
            var selectedbooks = from b in Database.BorrowingList where (b.Book.Title == book) select b;
            BookI bBook;
            bBook = selectedbooks.FirstOrDefault().Book;
            if (bBook!=null)
            {
                Database.mainLibrary[bBook] = false;
                Console.WriteLine("Book " + book + " successfully returned ");
                selectedbooks.First().RTime = DateTime.Now;
            }
            else
            {
                Console.WriteLine("You don't have " + book);
            }
           
        }
    }
}
