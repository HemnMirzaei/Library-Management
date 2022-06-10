using Library.Core.Interfaces;
using Library.Core.ViewModels;
using Library.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUser _user;
        public AccountController(IUser user)
        {
            _user = user;
        }

        public IActionResult Index()
        {
            return View(_user.GetAllUsers());
        }


        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserViewModel modal)
        {
            if (ModelState.IsValid)
            {
                LibraryUser users = new LibraryUser()
                {
                    Name = modal.Name,
                    Birthday = modal.Birthday,
                    Role = modal.Role,
                    Gedner = modal.Gedner
                };
                _user.AddNewUser(users);
                return RedirectToAction("Index");   
            }
            return View(modal);
        }



        public IActionResult Detail(int id)
        {
            return View(_user.GetUserById(id));
        }


        public IActionResult Edit(int id)
        {
            return View(_user.GetUserById(id));
        }

        [HttpPost]
        public IActionResult Edit(int id,LibraryUser modal)
        {
            if (ModelState.IsValid)
            {
                _user.EditUser(id, modal);
                return RedirectToAction("Index");
            }
            return View(modal);
        }



        public IActionResult Delete(int id)
        {
            return View(_user.GetUserById(id));
        }


        [HttpPost]
        public IActionResult Delete(int? id)
        {
            _user.DeleteUser(id);
            return RedirectToAction("Index");
        }
    }
}
