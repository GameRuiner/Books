using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleApp1
{
    public class BookService : IBookService
    {
        private Context _context;

        public BookService(Context context)
        {
            _context = context;
        }

        public IEnumerable<BookI>  Library()
        {
            var selectedbooks = from b in _context.Books where b.Borrowed == false select b;
            return selectedbooks.ToList();
                
        }

        public void AddB(string title, string author)
        {
            BookI book = new BookI{
                Author = author,
                Title = title,
                Borrowed = false};
            _context.Books.Add(book);
            _context.SaveChanges();

        }
        public void RemoveB(string title)
        {
            BookI rBook;
            var selectedbooks = from b in _context.Books where b.Title == title  select b;
            rBook = selectedbooks.FirstOrDefault();
            if (rBook!=null)
            {
                _context.Books.Remove(rBook);
                _context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Library doesn't have book " + title);
            }

        }
        public void EditB(string title)
        {
            //var book = new BookI();
            //var entity = _context.Entry<BookI>(book);
            //entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            //_context.SaveChanges();

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
                _context.SaveChanges();

            }
            else
            {
                Console.WriteLine("Library doesn't have book "+ title);
            }
        }

    }
}
