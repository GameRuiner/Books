using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class BookService
    {
        public  List<BookI> AddB(string title, string author)
        {
            BookI book = new BookI(title, author);
            Program.mainLibrary.Add(book);
            return Program.mainLibrary;
        }
        public List<BookI> RemoveB(string title)
        {
            foreach (var item in Program.mainLibrary)
            {
                if (item.Title == title)
                {
                    Program.mainLibrary.Remove(item);
                    break;
                }
            }
            return Program.mainLibrary;

        }
        public List<BookI> EditB(string title)
        {
            string com, newTitle, newAuthor;
            foreach (var item in Program.mainLibrary)
            {
                if (item.Title == title)
                {
                    Console.WriteLine("Change title? Y/N");
                    com = Console.ReadLine();
                    while (com != "N" && com != "Y")
                    {
                        com = Console.ReadLine();
                        Console.WriteLine(com);
                    }
                    if (com == "Y")
                    {
                        Console.WriteLine("New title:");
                        newTitle = Console.ReadLine();
                        item.Title = newTitle;
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
            return Program.mainLibrary;
        }
        public  void BookList(List<BookI> booklist)
        {
            foreach (var item in booklist)
            {
                Console.WriteLine("Title: " + item.Title + " Author: " + item.Author);
            }
        }
    }
}
