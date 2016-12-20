using BEL_BookApp;
using BLL_BookApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class BookDetailsController : Controller
    {
        BookDetails_BLL BookDetails_BLL = new BookDetails_BLL();
        //
        // GET: /BookDetails/
        public ActionResult Index()
        {
            return View(BookDetails_BLL.GetBookRecords());
        }

        public ActionResult Create(BooksDetails_BEL Book)
        {
            return View(Book);
        }

        [HttpPost]
        public ActionResult Save(BooksDetails_BEL Book)
        {
            if (ModelState.IsValid)
            {
                if (Book.BookId > 0)
                {
                    BookDetails_BLL.UpdateBookRecord(Book);
                }
                else
                {
                    BookDetails_BLL.SaveBookDetails(Book);
                }

                return RedirectToAction("Index");
            }
            else
            {
                return View(Book);
            }
        }

        public ActionResult Edit(int id)
        {
            var Book = BookDetails_BLL.GetBookRecord(id);
            return View(Book);
        }

        public ActionResult Delete(int id)
        {
            var Book = BookDetails_BLL.GetBookRecord(id);
            return View(Book);
        }

        [HttpPost]
        public ActionResult Remove(BooksDetails_BEL Book)
        {
            int result = BookDetails_BLL.DeleteBookRecord(Book.BookId);

            return View("Index",BookDetails_BLL.GetBookRecords());
        }
    }
}