using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bookstore.Models;
using System.Net;

namespace Bookstore.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        BookstoreContext context = new BookstoreContext();
        // GET: Book
        public ActionResult Index()
        {
            var model = context.Books.ToList();
            var publishers = context.Publishers.ToList();
            var t = (from items in model
                    join p in publishers on items.PublisherId equals p.PublisherId
                    select new
                    {
                       BookId = items.BookId,
                       BookName = items.BookName,
                       DatePublished = items.DatePublished,
                       PublisherName = p.PublisherName
                    }).ToList();
            var books = new List<BookViewModel>();
            foreach(var i in t)
            {
                books.Add(new BookViewModel()
                {
                    BookId = i.BookId,
                    BookName = i.BookName,
                    DatePublished = i.DatePublished,
                    PublisherName = i.PublisherName
                });
            }
            return View(books);
        }

        // GET: Book/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var book = context.Books.Where(x=>x.BookId==id).ToList();
            var publishers = context.Publishers.ToList();
            if (book == null)
            {
                return HttpNotFound();
            }
            ///////////
            var t = (from items in book
                     join p in publishers on items.PublisherId equals p.PublisherId
                     select new
                     {
                         BookId = items.BookId,
                         BookName = items.BookName,
                         DatePublished = items.DatePublished,
                         PublisherName = p.PublisherName
                     }).ToList();
            var books = new List<BookViewModel>();
            var b = new BookViewModel();
            b.BookId = t.FirstOrDefault().BookId;
            b.BookName = t.FirstOrDefault().BookName;
            b.DatePublished = t.FirstOrDefault().DatePublished;
            b.PublisherName = t.FirstOrDefault().PublisherName;
            //foreach (var i in t)
            //{
            //    books.Add(new BookViewModel()
            //    {
            //        BookId = i.BookId,
            //        BookName = i.BookName,
            //        DatePublished = i.DatePublished,
            //        PublisherName = i.PublisherName
            //    });
            //}
            ///////
            return View(b);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            ViewBag.Publishers = context.Publishers.ToList();
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(Book book)
        {
            try
            {
                // TODO: Add insert logic here
                if (book != null)
                {
                    context.Books.Add(book);
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                ViewBag.Error = e.ToString();
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = context.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.Publishers = context.Publishers.ToList();
            return View(book);
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, Book book)
        {
            try
            {
                // TODO: Add update logic here
                if(id!=null && book != null)
                {
                    Book bookInDb = context.Books.Find(id);
                    bookInDb.BookName = book.BookName;
                    bookInDb.DatePublished = book.DatePublished;
                    bookInDb.PublisherId = book.PublisherId;
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var book = context.Books.Where(x => x.BookId == id).ToList();
            var publishers = context.Publishers.ToList();
            if (book == null)
            {
                return HttpNotFound();
            }
            ///////////
            var t = (from items in book
                     join p in publishers on items.PublisherId equals p.PublisherId
                     select new
                     {
                         BookId = items.BookId,
                         BookName = items.BookName,
                         DatePublished = items.DatePublished,
                         PublisherName = p.PublisherName
                     }).ToList();
            var books = new List<BookViewModel>();
            var b = new BookViewModel();
            b.BookId = t.FirstOrDefault().BookId;
            b.BookName = t.FirstOrDefault().BookName;
            b.DatePublished = t.FirstOrDefault().DatePublished;
            b.PublisherName = t.FirstOrDefault().PublisherName;
            //foreach (var i in t)
            //{
            //    books.Add(new BookViewModel()
            //    {
            //        BookId = i.BookId,
            //        BookName = i.BookName,
            //        DatePublished = i.DatePublished,
            //        PublisherName = i.PublisherName
            //    });
            //}
            ///////
            return View(b);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
            {
            try
            {
                // TODO: Add delete logic here
                Book book = context.Books.Find(id);
                context.Books.Remove(book);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
