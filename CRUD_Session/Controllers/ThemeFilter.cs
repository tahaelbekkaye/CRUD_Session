using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
namespace CRUD_Session.Controllers
{
    public class ThemeFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var themeCookie = context.HttpContext.Request.Cookies["ThemePreference"];

            // Vous pouvez maintenant utiliser la valeur du thème comme nécessaire
            if (!string.IsNullOrEmpty(themeCookie))
            {
                context.HttpContext.Items["Theme"] = themeCookie;
            }

            base.OnActionExecuting(context);
        }
    }
}
