using BEL_BookApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class PublisherBooksModel
    {
        public PublisherBooksModel() { }

        public PublisherBooksModel(Publisher_BEL Publisher, IEnumerable<BooksDetails_BEL> AllBooks, IEnumerable<BooksDetails_BEL> PublisherBooks)
        {
            this.Publisher = Publisher;
            this.AllBooks = AllBooks;
            this.PublisherBooks = PublisherBooks;
        }

        public Publisher_BEL Publisher { get; set; }

        public IEnumerable<BooksDetails_BEL> AllBooks { get; set; }

        public IEnumerable<BooksDetails_BEL> PublisherBooks { get; set; }
    }
}