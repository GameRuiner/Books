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
            
            var selectedbooks = from b in Database.mainLibrary where (b.Key.Title == book) select b;
            if (selectedbooks.Count() > 0)
            {
                BookI bBook;
                bBook = selectedbooks.First().Key;
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
            var selectedbooks = from b in Database.BorrowingList where (b.Book.Title == book && b.User == users ) select b;
            if (selectedbooks.Count() > 0)
            {
                BookI bBook;
                bBook = selectedbooks.First().Book;
                Database.mainLibrary[bBook] = false;
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
