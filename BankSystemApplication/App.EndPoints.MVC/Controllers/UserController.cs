using App.Domain.Core.Contracts.AppService;
using App.Domain.Services.AppService;
using App.Infra.Db;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace App.EndPoints.MVC.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserAppService _userAppService;

        public UserController()
        {
            _userAppService = new UserAppService();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserPanel()
        {
            var loggedInUser = _userAppService.GetCurrentUser();
            return View(loggedInUser);
        }


        [HttpPost]
        public IActionResult Login(string username,string password)
        {
            var result = _userAppService.Login(username, password);
            if (result.IsSucced)
            {
                InMemoryDb.CurrentUser = result.Currentuser;
                return RedirectToAction("UserPanel");
            }
            // handle edge cases for incorrect password entries
            else
            {
                TempData["ErrorMessage"] = result.Message;
                return View("Index");
            }
        }
    }
}
