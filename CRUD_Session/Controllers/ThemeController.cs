using CRUD_Session.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CRUD_Session.Controllers
{
    public class ThemeController : Controller
    {
        public IActionResult Switch(string theme)
        {
            if (theme != "Dark" && theme != "Light")
            {
                theme = "Default"; 
            }
            Response.Cookies.Append("ThemePreference", theme);
            // Redirect to Crud/Index action
            return RedirectToAction("Index", "Crud");
        }
    }
}
