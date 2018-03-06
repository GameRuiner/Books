using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleApp1
{
    
    class UserService : IUserService
    {
        User users;
        public UserService(User user)
        {
            users = user;

        }
        public void Borrow(string book, User user)
        {
            
            var selectedbooks = from b in Database.mainLibrary where (b.Title == book) select b;
            if (selectedbooks.Count() > 0)
            {
                BookI bBook;
                bBook = selectedbooks.First();
                Database.BorrowingList.Add (new Borrowing() { User = user, Book = bBook, BTime = DateTime.Now });
                Database.mainLibrary.Remove(bBook);
                Console.WriteLine("Book " + book + " successfully borrowed ");
            }
            else
            {
                Console.WriteLine("Library don't contain book " + book);
            }
            
        }
        public void ReturnB(string book, User user)
        {
            var selectedbooks = from b in Database.BorrowingList where (b.Book.Title == book && b.User == users) select b;
            if (selectedbooks.Count() > 0)
            {
                BookI bBook;
                bBook = selectedbooks.First().Book;
                Database.mainLibrary.Add(bBook);
                Console.WriteLine("Book " + book + " successfully returned ");
                var selectedborrows = from b in Database.BorrowingList where ((b.User == user) && (b.Book == bBook)) select b;
                if (selectedborrows.Count() > 0)
                {
                    selectedborrows.First().RTime = DateTime.Now;
                }
            }
            else
            {
                Console.WriteLine("You don't have " + book);
            }
           
        }
    }
}
