using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        public static List<string> books = new List<string>();
        public static List<string> library = new List<string>();
        public static List<string> users = new List<string>() {"library"};
        static void Main(string[] args)
        {
            String cki,book1,book2,user = "library";
            Console.WriteLine("Welcome to library");
            do
            {
                cki = Console.ReadLine();
                if (cki == "Add"){
                    cki = Console.ReadLine();
                    books = AddB(cki);
                }
                if (cki == "My books"){
                    foreach (var item in books){
                        Console.WriteLine(item);
                                               }
                }
                if (cki == "Remove")
                {
                    cki = Console.ReadLine();
                    books = RemoveB(cki);
                }
                if (cki == "Edit")
                {
                    book1 = Console.ReadLine();
                    book2 = Console.ReadLine();
                    books = EditB(book1,book2);
                }
                if (cki == "Login")
                {
                    if (user == "library")
                    {
                        library = books;
                    }
                    user = Console.ReadLine();
                    if (users.Contains(user)){
                         
                    }
                    else
                    {

                        
                    }

                }

            } while (cki != "Exit");
        }
        public static List<string> AddB(string book)
        {
            books.Add(book);
            return books;
        }
        public static List<string> RemoveB(string book)
        {
            books.Remove(book);
            return books;

        }
        public static List<string> EditB(string book1, string book2)
        {
            books.Remove(book1);
            books.Add(book2);
            return books;
        }
    }
}
