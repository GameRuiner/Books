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

            var selectedbooks = from b in _context.Books where b.Title == book && b.Borrowed == false select b;
            BookI bBook;
            bBook = selectedbooks.FirstOrDefault();
            if (bBook!=null)
            {
                bBook.Borrowed = true;
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
            var selectedbooks = from b in _context.Borrowings where b.Book.Title == book  &&  b.RTime == default(DateTime) select b;
            var bBooks = selectedbooks.FirstOrDefault();
            if (bBooks!=null)
            {
                BookI bBook = bBooks.Book;
                bBook.Borrowed = false;
                Console.WriteLine("Book " + book + " successfully returned ");
                selectedbooks.First().RTime = DateTime.Now;
                _context.SaveChanges();
            }
            else
            {
                Console.WriteLine("You don't have " + book);
            }
           
        }

        public void BookList(User user)
        {
            var selectedbooks = from b in _context.Borrowings where b.User == user && b.RTime == default(DateTime) select b.Book;
            foreach (var item in selectedbooks)
            {
                Console.WriteLine("Title: " + item.Title + " Author: " + item.Author);
            }
        }
    }
}
