using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleApp1
{
    
    class UserService : IUserService
    {
        BookI bBook;
        User users;
        public UserService(User user)
        {
            users = user;

        }
        public void Borrow(string book)
        {
            
            var selectedbooks = from b in Database.mainLibrary where (b.Title == book) select b;
            if (selectedbooks.Count() > 0)
            {
                bBook = selectedbooks.First();
                Database.AddBorrow(users, bBook);
                Database.mainLibrary.Remove(bBook);
                Console.WriteLine("Book " + book + " successfully borrowed ");
            }
            else
            {
                Console.WriteLine("Library don't contain book " + book);
            }
            
        }
        public void ReturnB(string book)
        {
            var selectedbooks = from b in Database.BorrowingList where (b.Book.Title == book && b.User == users) select b;
            if (selectedbooks.Count() > 0)
            {
                bBook = selectedbooks.First().Book;
                Database.mainLibrary.Add(bBook);
                Database.ReturnBorrow(users, bBook);
                Console.WriteLine("Book " + book + " successfully returned ");
            }
            else
            {
                Console.WriteLine("You don't have " + book);
            }
           
        }
    }
}
