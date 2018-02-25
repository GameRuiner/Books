using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    interface IUserService
    {
        void Borrow(string book);

        void ReturnB(string book);
    }
}
