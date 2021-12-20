using APIConsumer.Data;
using APIConsumer.Models.ViewModels.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APIConsumer.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        public ActionResult Index()
        {
            var authors_list = IntakerAPI.getAuthorsList();

            if (TempData["Error"] != null)
            {
                ViewBag.Error = TempData["Error"];
            }

            if (TempData["Success"] != null)
            {
                ViewBag.Success = TempData["Success"];
            }

            if (authors_list.code != 200) {
                ViewBag.Error = authors_list.message;
            }
            return View(authors_list.data);
        }

        // GET: Author/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Author/Create
        public ActionResult Create()
        {
            return View( new AuthorVM());
        }

        // POST: Author/Create
        [HttpPost]
        public ActionResult Create(AuthorVM new_author)
        {
            try
            {
                var save_author = IntakerAPI.createNewAuthor(new_author);
                if (save_author.code != 200) 
                {
                    TempData["Error"] = save_author.message;
                }
                else
                {
                    TempData["Success"] = save_author.message;
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Author/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Author/Edit/5
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

        // GET: Author/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Author/Delete/5
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
