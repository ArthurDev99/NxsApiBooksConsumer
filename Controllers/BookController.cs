using APIConsumer.Data;
using APIConsumer.Models.ViewModels.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APIConsumer.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index(string author = "", string title = "", int year = 0)
        {
            var data_books = IntakerAPI.getBooksList(author, title, year);
            if (TempData["Error"]!= null) {
                ViewBag.Error = TempData["Error"];
            }

            if (TempData["Success"] != null) {
                ViewBag.Success = TempData["Success"];
            }
            if (data_books.code != 200) 
            {
                ViewBag.Error = data_books.message;
            }
            return View(data_books.data);
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            var authors = IntakerAPI.getAuthorsList();
            List<SelectListItem> list_authors = new List<SelectListItem>();
            list_authors.Add(new SelectListItem()
            {
                Text = "Selecciona un autor",
                Value = ""
            });

            foreach (var a in authors.data)
            {
                list_authors.Add(new SelectListItem()
                {
                    Text = a.Name,
                    Value = a.AuthorId.ToString()
                });
            }

            ViewBag.AuthorsList = list_authors;
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(BookVM new_book)
        {
            try
            {
                var response_save_book = IntakerAPI.createNewBook(new_book);

                if (response_save_book.code == 200)
                {
                    TempData["Success"] = response_save_book.message;
                }
                else {
                    TempData["Error"] = response_save_book.message;
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
