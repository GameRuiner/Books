using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleApp1
{
    
    public class UserService : IUserService
    {
        private Context _context;

        public UserService(Context context)
        {
            _context = context;
        }

        public void Borrow(string book, User user)
        {
            
            var selectedbooks = from b in _context.Books where (b.Title == book) select b;
            BookI bBook;
            bBook = selectedbooks.FirstOrDefault();
            if (bBook!=null)
            {
                _context.Borrowings.Add (new Borrowing() { User = user, Book = bBook, BTime = DateTime.Now });
                Console.WriteLine("Book " + book + " successfully borrowed ");
                _context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Library don't contain book " + book);
            }
            
        }
        public void ReturnB(string book, User user)
        {
            var selectedbooks = from b in _context.Borrowings where (b.Book.Title == book) select b;
            BookI bBook;
            bBook = selectedbooks.FirstOrDefault().Book;
            if (bBook!=null)
            {
                Console.WriteLine("Book " + book + " successfully returned ");
                selectedbooks.First().RTime = DateTime.Now;
                _context.SaveChanges();
            }
            else
            {
                Console.WriteLine("You don't have " + book);
            }
           
        }
    }
}
