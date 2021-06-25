using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using THWEB_KimNgan.Models;

namespace THWEB_KimNgan.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult listBook()
        {
            var books = new List<bookModels>();
            books.Add(new bookModels(1, "html5 & css3 The complete Manual", "Author name 1", "/Content/img/sach1.jpg"));
            books.Add(new bookModels(2, "html5 & css3 The complete Manual", "Author name 2", "/Content/img/sach2.jpg"));
            books.Add(new bookModels(3, "html5 & css3 The complete Manual", "Author name 3", "/Content/img/sach3.jpg"));
            return View(books);
        }
        [HttpGet]
        public ActionResult editBook(int id)
        {
            var books = new List<bookModels>();
            books.Add(new bookModels(1, "html5 & css3 The complete Manual", "Author name 1", "/Content/img/sach1.jpg"));
            books.Add(new bookModels(2, "html5 & css3 The complete Manual", "Author name 2", "/Content/img/sach2.jpg"));
            books.Add(new bookModels(3, "html5 & css3 The complete Manual", "Author name 3", "/Content/img/sach3.jpg"));
            bookModels bookk = new bookModels();
            foreach (bookModels item in books)
            {
                if (item.Id == id)
                {
                    bookk = item;
                    break;
                }
            }
            if (bookk == null)
            {
                return HttpNotFound();
            }
            return View(bookk);
        }
        [HttpPost, ActionName("editBook")]
        [ValidateAntiForgeryToken]
        public ActionResult editBook(int id, string titel, string author, string img)
        {
            var books = new List<bookModels>();
            books.Add(new bookModels(1, "html5 & css3 The complete Manual", "Author name 1", "/Content/img/sach1.jpg"));
            books.Add(new bookModels(2, "html5 & css3 The complete Manual", "Author name 2", "/Content/img/sach2.jpg"));
            books.Add(new bookModels(3, "html5 & css3 The complete Manual", "Author name 3", "/Content/img/sach3.jpg"));
            bookModels bookk = new bookModels();

            if (id == null)
            {
                return HttpNotFound();
            }
            foreach (bookModels item in books)
            {
                if (item.Id == id)
                {
                    item.Titel = titel;
                    item.Author = author;
                    item.Img = img;
                    break;
                }
            }
            return View("listBook", books);
        }

        public ActionResult crateBook()
        {
            return View();
        }

        [HttpPost, ActionName("crateBook")]
        [ValidateAntiForgeryToken]
        public ActionResult crateBook([Bind(Include = "Id,Titel,Author,Img")] bookModels book)
        {
            var books = new List<bookModels>();
            books.Add(new bookModels(1, "html5 & css3 The complete Manual", "Author name 1", "/Content/img/sach1.jpg"));
            books.Add(new bookModels(2, "html5 & css3 The complete Manual", "Author name 2", "/Content/img/sach2.jpg"));
            books.Add(new bookModels(3, "html5 & css3 The complete Manual", "Author name 3", "/Content/img/sach3.jpg"));
            try
            {
                if (ModelState.IsValid)
                {
                    books.Add(book);
                }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Erro Save");
            }
            return View("listBook", books);
        }
    }
}