using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        public static List<BookI> mainLibrary = new List<BookI>();
        public static List<User> userlist = new List<User>();
      
        static void Main(string[] args)
        {
            String cki,title,author,username;
            User user;
            UserService uservice;
            var service = new BookService();

            Console.WriteLine("Welcome to library");
            do
            {
                cki = Console.ReadLine();
                if (cki == "Add") {
                    Console.WriteLine("Title:");
                    title = Console.ReadLine();
                    Console.WriteLine("Author:");
                    author = Console.ReadLine();
                    mainLibrary = service.AddB(title,author);
                }

                else if (cki == "Library books"){
                    service.BookList(mainLibrary);
                    }
                else if (cki == "Remove"){
                    service.BookList(mainLibrary);
                    Console.WriteLine("Please choose title");
                    title = Console.ReadLine();
                    mainLibrary = service.RemoveB(title);
                    } 
                else if (cki == "Edit")
                {
                    service.BookList(mainLibrary);
                    Console.WriteLine("Please choose title");
                    title = Console.ReadLine();
                    mainLibrary = service.EditB(title);
                }
                else if (cki == "User list")
                {
                    foreach (var item in userlist)
                    {
                        Console.WriteLine(item.Name);
                    }
                }
                else if (cki == "Login")
                {
                    Console.WriteLine("Your login:");
                    username = Console.ReadLine();
                    user = new User(username);
                    var selecteduser =  from u in userlist where (u.Name==username) select u;
                    if (selecteduser.Count() > 0)
                    {
                        user = selecteduser.First();
                        Console.WriteLine("Welcome back " + user.Name);
                    }
                    else
                    {
                        Console.WriteLine("Welcome new user " + user.Name);
                        userlist.Add(user);
                    }
                    uservice = new UserService(user);
                    while (true)
                    {
                        cki = Console.ReadLine();
                        if (cki == "Logout")
                        {
                            Console.WriteLine("Goodbye "+ user.Name);
                            break;
                        }
                        switch (cki)
                        {
                            case "Borrow":
                                service.BookList(mainLibrary);
                                Console.WriteLine("Please, enter title of book");
                                title = Console.ReadLine();
                                uservice.Borrow(title);
                                break;
                            case "Return":
                                service.BookList(user.Library);
                                Console.WriteLine("Please, enter title of book");
                                title = Console.ReadLine();
                                uservice.ReturnB(title);
                                break;
                            case "My books":
                                service.BookList(user.Library);
                                break;
                            case "Library":
                                service.BookList(mainLibrary);
                                break;
                            case "User name":
                                Console.WriteLine(user.Name);
                                break;
                            default:
                                Console.WriteLine("Unknown user command");
                                break;
                        }

                    } 
                   
                }
                else
                {
                    Console.WriteLine("Unknown command");
                }

            } while (cki != "Exit");
        }
        
    }
}
