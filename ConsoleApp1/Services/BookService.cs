﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleApp1
{
    public class BookService : IBookService
    {
        private _context _context;

        public BookService()
        {
            _context = new _context();
        }

        public void AddB(string title, string author)
        {
            BookI book = new BookI(title, author);
            _context.Books.Add(book);
            
        }
        public void RemoveB(string title)
        {
            BookI rBook;
            var selectedbooks = from b in _context.Books where b.Title == title  select b;
            rBook = selectedbooks.FirstOrDefault();
            if (rBook!=null)
            {
                _context.Books.Remove(rBook);
            }
            else
            {
                Console.WriteLine("Library doesn't have book " + title);
            }

        }
        public void EditB(string title)
        {
            string com, newTitle, newAuthor;
            BookI eBook;
            var selectedbooks = from b in _context.Books where b.Title == title select b;
            eBook = selectedbooks.FirstOrDefault();
                if (eBook!=null)
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
        }
        public  void BookList(User user)
        {
            var selectedbooks = from b in _context.Borrowings where b.User == user && b.RTime == default(DateTime) select b.Book;
            foreach (var item in selectedbooks)
            {
                Console.WriteLine("Title: " + item.Title + " Author: " + item.Author);
            }
        }
    }
}
