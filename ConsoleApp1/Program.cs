﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // string connectionString = "Server = localhost; Database = master; Trusted_Connection = True";
            //var context = new DbContext(connectionString);
            //context.Database.Initialize(true);
            String cki,title,author,username;
            User user;
            Context _context = new Context();
            UserService userservice = new UserService(_context);

            BookService service = new BookService(_context);

            Console.WriteLine("Welcome to library");
            do
            {
                cki = Console.ReadLine();
                if (cki == "Add") {
                    Console.WriteLine("Title:");
                    title = Console.ReadLine();
                    Console.WriteLine("Author:");
                    author = Console.ReadLine();
                    service.AddB(title,author);
                }

                else if (cki == "Library books"){
                    IEnumerable<BookI> books = service.Library();
                    foreach (var book in books) {
                        Console.WriteLine("Title: "+book.Title+", "+ "Author: " + book.Author); }
                    }

                else if (cki == "Help")
                {
                    Console.WriteLine("Add, Remove, Edit, User list, Library books, Login");
                }
                else if (cki == "Remove"){
                    IEnumerable<BookI> books = service.Library();
                    foreach (var item in books)
                    {
                        Console.WriteLine("Title: " + item.Title + " Author: " + item.Author);
                    }
                    Console.WriteLine("Please choose title");
                    title = Console.ReadLine();
                    service.RemoveB(title);
                    } 
                else if (cki == "Edit")
                {
                    IEnumerable<BookI> books = service.Library();
                    foreach (var item in books)
                    {
                        Console.WriteLine("Title: " + item.Title + " Author: " + item.Author);
                    }
                    Console.WriteLine("Please choose title");
                    title = Console.ReadLine();
                    service.EditB(title);
                }
                else if (cki == "User list")
                {
                    foreach (var item in _context.Users)
                    {
                        Console.WriteLine(item.Name);
                    }
                }
                else if (cki == "Login")
                {
                    Console.WriteLine("Your login:");
                    username = Console.ReadLine();
                    


                    var selecteduser =  from u in _context.Users where (u.Name==username) select u;
                    User users = selecteduser.FirstOrDefault();
                    if (users != null)
                    {
                        Console.WriteLine("Welcome back " + users.Name);
                        user = users;
                    }
                    else
                    {
                        user = new User
                        {
                            Name = username
                        };
                        Console.WriteLine("Welcome new user " + user.Name);
                        _context.Users.Add(user);
                    }
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
                                foreach (var item in _context.Books)
                                {
                                    if (item.Borrowed == false)
                                    {
                                        Console.WriteLine("Title: " + item.Title + " Author: " + item.Author);
                                    }
                                }
                                Console.WriteLine("Please, enter title of book");
                                title = Console.ReadLine();
                                userservice.Borrow(title,user);
                                break;
                            case "Return":
                                userservice.BookList(user);
                                Console.WriteLine("Please, enter title of book");
                                title = Console.ReadLine();
                                userservice.ReturnB(title,user);
                                break;
                            case "My books":
                                userservice.BookList(user);
                                break;
                            case "Library":
                                foreach (var item in _context.Books)
                                {
                                    Console.WriteLine("Title: " + item.Title + " Author: " + item.Author);
                                }
                                break;
                            case "User name":
                                Console.WriteLine(user.Name);
                                break;
                            case "Borrowing":
                                foreach (var item in _context.Borrowings)
                                {
                                    if (item.User == user)
                                    {
                                        Console.WriteLine("Title: " + item.Book.Title + " Author: " + item.Book.Author);
                                        if (item.RTime == default(DateTime))
                                        {
                                            Console.WriteLine("Borrowing date: " + item.BTime + " Return date: --");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Borrowing date: " + item.BTime + " Return date: " + item.RTime);
                                        }

                                    }

                                }
                                break;
                            case "Help":
                                Console.WriteLine("Borrowing, User name, Library, My books, Return, Borrow, Logout");
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
