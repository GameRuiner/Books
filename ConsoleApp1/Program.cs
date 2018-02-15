using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        public static List<BookI> books = new List<BookI>();
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
            public List<string> library;
        }
        static void Main(string[] args)
        {
            String cki,title,author;
            Console.WriteLine("Welcome to library"+"sss");
            do
            {
                cki = Console.ReadLine();
                if (cki == "Add") {
                    Console.WriteLine("Title:");
                    title = Console.ReadLine();
                    Console.WriteLine("Author:");
                    author = Console.ReadLine();
                    books = AddB(title,author);
                }

                else if (cki == "My books"){
                        foreach (var item in books) {
                            Console.WriteLine("Title: "+item.title+" Author: "+ item.author);
                        }
                    }
                else if (cki == "Remove")
                {
                        title = Console.ReadLine();
                        books = RemoveB(title);
                    } 
                else if (cki == "Edit")
                {
                    title = Console.ReadLine();
                    books = EditB(title);
                }
                else if (cki == "Login")
                {
                   
                }

            } while (cki != "Exit");
        }
        public static List<BookI> AddB(string title, string author)
        {
            BookI book = new BookI(title, author);
            books.Add(book);
            return books;
        }
        public static List<BookI> RemoveB(string title)
        {
            foreach (var item in books)
            {
                if (item.title == title) {
                    books.Remove(item);
                    break;
                        }
            }
            return books;

        }
        public static List<BookI> EditB(string title)
        {
            string com,newTitle,newAuthor;
            foreach (var item in books)
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
            return books;
        }
    }
}
