using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class _context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Books;Trusted_Connection=True;");
        }

        public static DbSet<BookI> Books { get; set; }
        public static DbSet<Borrowing> Borrowings { get; set; }
        public static DbSet<User> Users { get; set; }
    }
}
