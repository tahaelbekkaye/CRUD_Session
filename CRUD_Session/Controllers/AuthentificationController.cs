using CRUD_Session.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CRUD_Session.Controllers
{
    public class AuthentificationController : Controller
    {
        public IActionResult LoginForm()
        {
            return View();
        }

        public IActionResult Login(User u) 
        {
            if (ModelState.IsValid)
            {
                string Password = new string(u.Password.Reverse().ToArray());
                if (u.Login==Password)
                {
                    var user = new User { Login = u.Login, LastLogout = DateTime.Now};
                    HttpContext.Session.SetString("User", JsonConvert.SerializeObject(user));
                    HttpContext.Session.SetString("isAuth", "");
                    return RedirectToAction("Create","Crud");
                }
            }
            return View("LoginForm");
        }
        public IActionResult Logout()
        {
            HttpContext.Session?.Clear();
            return RedirectToAction("LoginForm");
        }
    }
}
