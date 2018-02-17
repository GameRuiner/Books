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
    }
}
