using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class User
    {
        public List<BookI> Library { get; }
        public string Name { get; }
        public User(string nm)
        {
            Library = new List<BookI>();
            Name = nm;
        }
        public void Borrow(string book)
        {
            foreach (var item in Program.mainLibrary)
            {
                if (item.Title == book)
                {
                    Library.Add(item);
                    Program.mainLibrary.Remove(item);
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
                    Program.mainLibrary.Add(item);
                    Library.Remove(item);
                    Console.WriteLine("Book " + book + " successfully returned ");
                    return;

                }
            }
            Console.WriteLine("You don't have " + book);
        }

    }
}
