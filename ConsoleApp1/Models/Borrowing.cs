using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1
{
    public class Borrowing //: DbContext
    {
        [Key]
        public int id { get; set; }
        [ForeignKey(nameof(BookId))]
        public int BookId { get; set; }
        public User User { get; set; }
        public BookI Book { get; set; }
        public DateTime BTime { get; set; }
        public DateTime RTime { get; set; }
    }
}
