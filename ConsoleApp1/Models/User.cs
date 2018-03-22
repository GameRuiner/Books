using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;

namespace ConsoleApp1
{
    class User //: DbContext
    {
        public string Name { get; }
        public User(string nm)
        {
            Name = nm;
        }
    }
}
