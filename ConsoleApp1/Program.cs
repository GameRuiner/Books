using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        public static List<BookI> mainLibrary = new List<BookI>();
        public static List<User> userlist = new List<User>();

        public class BookI
        {
            public string Title{ get; set; }
            public string Author { get; set; }
            public BookI(string nm, string au)
            {
                Title = nm;
                Author = au;
            }
        }
        public class User
        {
            public List<BookI> Library { get;}
            public string Name { get;}
            public User(string nm)
            {
                Library = new List<BookI>();
                Name = nm;
            }
            public void Borrow(string book)
            {
                foreach (var item in mainLibrary)
                {
                    if (item.Title == book)
                    {
                        Library.Add(item);
                        mainLibrary.Remove(item);
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
                        mainLibrary.Add(item);
                        Library.Remove(item);
                        Console.WriteLine("Book " + book + " successfully returned ");
                        return;

                    }
                }
                Console.WriteLine("You don't have " + book);
            }

        }
        static void Main(string[] args)
        {
            String cki,title,author,username;
            User user;
            bool b;
            Console.WriteLine("Welcome to library");
            do
            {
                cki = Console.ReadLine();
                if (cki == "Add") {
                    Console.WriteLine("Title:");
                    title = Console.ReadLine();
                    Console.WriteLine("Author:");
                    author = Console.ReadLine();
                    mainLibrary = AddB(title,author);
                }

                else if (cki == "Library books"){
                     BookList(mainLibrary);
                    }
                else if (cki == "Remove")
                {
                        title = Console.ReadLine();
                        mainLibrary = RemoveB(title);
                    } 
                else if (cki == "Edit")
                {
                    BookList(mainLibrary);
                    Console.WriteLine("Please choose title");
                    title = Console.ReadLine();
                    mainLibrary = EditB(title);
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
                    b = true;
                    username = Console.ReadLine();
                    user = new User(username);
                    foreach (var item in userlist)
                    {
                        if(item.Name == username)
                        {
                            user = item;
                            b = false;
                            Console.WriteLine("Welcome back " + user.Name);
                            break;
                        }
                    }
                    if (b)
                    {
                        Console.WriteLine("Welcome new user " + user.Name);
                        userlist.Add(user);
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
                                BookList(mainLibrary);
                                Console.WriteLine("Please, enter title of book");
                                title = Console.ReadLine();
                                user.Borrow(title);
                                break;
                            case "Return":
                                BookList(user.Library);
                                Console.WriteLine("Please, enter title of book");
                                title = Console.ReadLine();
                                user.ReturnB(title);
                                break;
                            case "My books":
                                BookList(user.Library);
                                break;
                            case "Library":
                                BookList(mainLibrary);
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
        public static List<BookI> AddB(string title, string author)
        {
            BookI book = new BookI(title, author);
            mainLibrary.Add(book);
            return mainLibrary;
        }
        public static List<BookI> RemoveB(string title)
        {
            foreach (var item in mainLibrary)
            {
                if (item.Title == title) {
                    mainLibrary.Remove(item);
                    break;
                        }
            }
            return mainLibrary;

        }
        public static List<BookI> EditB(string title)
        {
            string com,newTitle,newAuthor;
            foreach (var item in mainLibrary)
            {
                if (item.Title == title)
                {
                    Console.WriteLine("Change title? Y/N");
                    com = Console.ReadLine();
                    while (com!="N" && com!= "Y"){
                        com = Console.ReadLine();
                        Console.WriteLine(com);
                    }
                    if (com == "Y")
                    {
                        Console.WriteLine("New title:");
                        newTitle = Console.ReadLine();
                        item.Title= newTitle;
                    }
                    Console.WriteLine("Change author? Y/N");
                    com = Console.ReadLine();
                    while (com != "N" && com != "Y")
                    {
                        com = Console.ReadLine();
                    }
                    if (com == "Y")
                    {
                        Console.WriteLine("New author:");
                        newAuthor = Console.ReadLine();
                        item.Author = newAuthor;
                    }

                    break;
                }
            }
            return mainLibrary;
        }
        public static void BookList(List<BookI> booklist)
        {
            foreach (var item in booklist)
            {
                Console.WriteLine("Title: " + item.Title + " Author: " + item.Author);
            }
        }
    }
}
