using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using Microsoft.AspNetCore.Mvc.Filters;


namespace CRUD_Session.Controllers
{
    public class JournalisteFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            LogAction(context, "Executing");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            LogAction(context, "Executed");
        }

        private void LogAction(FilterContext context, string status)
        {
            string logMessage = $"{DateTime.Now} - {context.HttpContext.User.Identity.Name} - {context.ActionDescriptor.DisplayName} - {status}";

            // Spécifiez le chemin de votre fichier de journalisation
            string filePath = "path/to/logfile.txt";

            // Écrivez le message de journalisation dans un fichier texte
            File.AppendAllText(filePath, logMessage + Environment.NewLine);
        }
    }
}

