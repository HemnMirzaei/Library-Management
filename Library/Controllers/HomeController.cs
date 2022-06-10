using Library.Core.Interfaces;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Dynamic;

namespace Library.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly IDashboard _dash;
        public HomeController(IDashboard dash)
        {
            _dash = dash;
        }

        public IActionResult Index()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult Index(int id)
        {
            if (ModelState.IsValid)
            {
                if (_dash.IsExistId(id))
                {
                    TempData["userid"] =id;
                    return RedirectToAction("Dashboard");
                }
                else
                {
                    ModelState.AddModelError("Id", "The user id not found");
                }
            }
            return View();
        }



        public IActionResult Dashboard(int id)
        {
            dynamic MyModel = new ExpandoObject();
            MyModel.User = _dash.GetUser(Convert.ToInt32(TempData["userid"]));
            MyModel.Book = _dash.BooksOnLoan(Convert.ToInt32(TempData["userid"]));
            return View(MyModel);
        }


        public IActionResult Delete(int id)
        {
            _dash.RemoveReservation(id);
            return RedirectToAction(nameof(Index));
        }

    }
}