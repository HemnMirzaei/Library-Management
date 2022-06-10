using Library.Core.Interfaces;
using Library.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservation _res;
        public ReservationController(IReservation res)
        {
            _res = res;
        }

        public IActionResult Index()
        {
            ViewBag.Books = _res.GetAllBooks()
                .Select(i => new SelectListItem
                {
                    Value = i.Id.ToString(),
                    Text = i.Name
                }).ToList();

            ViewBag.Users = _res.GetAllUsers()
                .Select(i => new SelectListItem
                {
                    Value = i.Id.ToString(),
                    Text = i.Name
                });
            return View();
        }


        [HttpPost]
        public IActionResult Index(Reservation modal)
        {
            ViewBag.Books = _res.GetAllBooks()
                .Select(i => new SelectListItem
                {
                    Value = i.Id.ToString(),
                    Text = i.Name
                });
            ViewBag.Users = _res.GetAllUsers()
                .Select(i => new SelectListItem
                {
                    Value = i.Id.ToString(),
                    Text = i.Name
                });
            DateTime dt = DateTime.Now;
            Reservation res = new Reservation()
            {
                BookId = modal.BookId,
                UserId = modal.UserId,
                Date = dt.ToString()
            };
            _res.AddNewReservation(res);

            return RedirectToAction("Index");
        }
    }
}
