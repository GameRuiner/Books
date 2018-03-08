﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    interface IBookService
    {
        void AddB(string title, string author);

        void RemoveB(string title);

        void EditB(string title);

        void BookList(User user);
    }
}
