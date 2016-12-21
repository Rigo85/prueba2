using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL_BookApp
{
    public class BooksDetails_BEL
    {
        public BooksDetails_BEL() { }
        public BooksDetails_BEL(string BookName, string Author, decimal Price)
        {
            this.BookName = BookName;
            this.Author = Author;
            this.Price = Price;
            this.Active = true;
        }

        public BooksDetails_BEL(int BookId, string BookName, string Author, decimal Price, bool Active)
        {
            this.BookId = BookId;
            this.BookName = BookName;
            this.Author = Author;
            this.Price = Price;
            this.Active = Active;
        }

        public int BookId { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public bool Active { get; set; }
    }
}
