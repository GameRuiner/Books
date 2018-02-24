using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
            BookI rBook;
            var selectedbooks = from b in Program.mainLibrary where b.Title == title select b;
            if (selectedbooks.Count() > 0)
            {
                rBook = selectedbooks.First();
                Program.mainLibrary.Remove(rBook);
            }
            else
            {
                Console.WriteLine("Library doesn't have book " + title);
            }
            return Program.mainLibrary;

        }
        public List<BookI> EditB(string title)
        {
            string com, newTitle, newAuthor;
            BookI eBook;
            var selectedbooks = from b in Program.mainLibrary where b.Title == title select b;
                if (selectedbooks.Count()>0)
                {
                eBook = selectedbooks.First();
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
                        eBook.Title = newTitle;
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
                        eBook.Author = newAuthor;
                    }

                }
            else
            {
                Console.WriteLine("Library doesn't have book "+ title);
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
