using Library.Core.Classes;
using Library.Core.ViewModels;
using Library.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        private readonly IBook _book;
        public BookController(IBook book)
        {
            _book = book;
        }
        public IActionResult Index()
        {
            return View(_book.GetAllBooks());
        }

        public IActionResult Create()
        {
            ViewBag.Topics = _book.GetAllTopics()
                .Select(i => new SelectListItem
                {
                    Value = i.Id.ToString(),
                    Text = i.Name
                }).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(BookViewModel modal)
        {
            ViewBag.Topics = _book.GetAllTopics()
               .Select(i => new SelectListItem
               {
                   Value = i.Id.ToString(),
                   Text = i.Name
               }).ToList();
            if (ModelState.IsValid)
            {
                Book book = new Book()
                {
                    Name = modal.Name,
                    TopicId = modal.TopicId,
                    Author = modal.Author,
                    Language = modal.Language,
                    Pages = modal.Pages,
                    PublishYear = modal.PublishYear,
                    Existing = modal.Existing
                };
                _book.AddNewBook(book);
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult Detail(int id)
        {
            return View(_book.GetBookById(id));
        }


        public IActionResult Edit(int id)
        {
            ViewBag.Topics = _book.GetAllTopics()
                .Select(i => new SelectListItem
                {
                    Value = i.Id.ToString(),
                    Text = i.Name
                }).ToList();
            return View(_book.GetBookById(id));
        }


        [HttpPost]
        public IActionResult Edit(int id,BookViewModel modal)
        {
            ViewBag.Topics = _book.GetAllTopics()
                .Select(i => new SelectListItem
                {
                    Value = i.Id.ToString(),
                    Text = i.Name
                }).ToList();
            if (ModelState.IsValid)
            {
                _book.EditBook(id, modal);
                return RedirectToAction(nameof(Index));
            }
            return View(modal);
        }



        public IActionResult Delete(int id)
        {
            return View(_book.GetBookById(id));
        }



        [HttpPost]
        public IActionResult Delete(int? id)
        {
            _book.DeleteBook(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
