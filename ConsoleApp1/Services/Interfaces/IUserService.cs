using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    interface IUserService
    {
        void Borrow(string book, User user);

        void ReturnB(string book, User user);
    }
}
