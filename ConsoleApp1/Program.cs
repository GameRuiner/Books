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
            public string title,author;
            public BookI()
            {
                title = "unknown";
                author = "unknown";
            }
            public BookI(string nm, string au)
            {
                title = nm;
                author = au;
            }
            public void SetTitle(string newTitle)
            {
                title = newTitle;
            }
            public void SetAuthor(string newAuthor)
            {
                author = newAuthor;
            }
        }
        public class User
        {
            public List<BookI> library;
            public string name;
            public User()
            {
                library = new List<BookI>();
                name = null;
            }
            public User(string nm)
            {
                library = new List<BookI>();
                name = nm;
            }
            public void Borrow(string book)
            {
                foreach (var item in mainLibrary)
                {
                    if (item.title == book)
                    {
                        library.Add(item);
                        mainLibrary.Remove(item);
                        Console.WriteLine("Book " + book + " successfully borrowed ");
                        return;
                    }
                }
                Console.WriteLine("Library don't contain book " + book);
            }
            public void ReturnB(string book)
            {
                foreach (var item in library)
                {
                    if (item.title == book)
                    {
                        mainLibrary.Add(item);
                        library.Remove(item);
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
            Boolean b;
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
                    title = Console.ReadLine();
                    mainLibrary = EditB(title);
                }
                else if (cki == "User list")
                {
                    foreach (var item in userlist)
                    {
                        Console.WriteLine(item.name);
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
                        if(item.name == username)
                        {
                            user = item;
                            b = false;
                            Console.WriteLine("Welcome back " + user.name);
                        }
                    }
                    if (b)
                    {
                        Console.WriteLine("Welcome new user " + user.name);
                        userlist.Add(user);
                    }
                    while (true)
                    {
                        cki = Console.ReadLine();
                        if (cki == "Logout")
                        {
                            Console.WriteLine("Goodbye "+ user.name);
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
                                BookList(user.library);
                                Console.WriteLine("Please, enter title of book");
                                title = Console.ReadLine();
                                user.ReturnB(title);
                                break;
                            case "My books":
                                BookList(user.library);
                                break;
                            case "Library":
                                BookList(mainLibrary);
                                break;
                            case "User name":
                                Console.WriteLine(user.name);
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
                if (item.title == title) {
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
                if (item.title == title)
                {
                    Console.WriteLine("Change title? Y/N");
                    com = Console.ReadLine();
                    while (com!="N" || com!= "Y"){
                        com = Console.ReadLine();
                    }
                    if (com == "Y")
                    {
                        Console.WriteLine("New title:");
                        newTitle = Console.ReadLine();
                        item.SetTitle(newTitle);
                    }
                    Console.WriteLine("Change author? Y/N");
                    com = Console.ReadLine();
                    while (com != "N" || com != "Y")
                    {
                        com = Console.ReadLine();
                    }
                    if (com == "Y")
                    {
                        Console.WriteLine("New author:");
                        newAuthor = Console.ReadLine();
                        item.SetAuthor(newAuthor);
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
                Console.WriteLine("Title: " + item.title + " Author: " + item.author);
            }
        }
    }
}
