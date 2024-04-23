using CRUD_Session.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Text.Json;
using CRUD_Session.Models;


namespace CRUD_Session.Controllers
{
    [ThemeFilter]
    [AuthFilter]
    public class CrudController : Controller
    {
        public IActionResult Index()
        {
            var user = GetUserFromSession();
            var todoList = GetTodoListFromSession();
            ViewBag.User = user.LastLogout;
            //ViewBag.Theme = user.Theme;
            ViewBag.Theme = HttpContext.Items["Theme"] as string;
            return View(todoList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public IActionResult Create(ToDo T)
        {
            if (ModelState.IsValid)
            {
                var todoList = GetTodoListFromSession();
                T.Id = todoList.Count + 1;
                todoList.Add(T);
                SaveTodoListToSession(todoList);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Modifier(int id)
        {
            var todoList = GetTodoListFromSession();
            var todoToUpdate = todoList.FirstOrDefault(t => t.Id == id);

            if (todoToUpdate == null)
            {
                return RedirectToAction("Index");
            }

            return View("Modifier", todoToUpdate);
        }

        [HttpPost]
        public IActionResult Modifier(ToDo updatedTodo)
        {
            if (ModelState.IsValid)
            {
                var todoList = GetTodoListFromSession();
                var existingTodoIndex = todoList.FindIndex(t => t.Id == updatedTodo.Id);

                if (existingTodoIndex != -1)
                {
                    todoList[existingTodoIndex] = updatedTodo;
                    SaveTodoListToSession(todoList);
                }
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Supprimer(int id)
        {
            var todoList = GetTodoListFromSession();
            var todoToDelete = todoList.FirstOrDefault(t => t.Id == id);

            if (todoToDelete != null)
            {
                todoList.Remove(todoToDelete);
                SaveTodoListToSession(todoList);
            }

            return RedirectToAction("Index");
        }
        
        private List<ToDo> GetTodoListFromSession()
        {
            var todoList = HttpContext.Session.GetString("TodoList") ?? "[]";
            return JsonConvert.DeserializeObject<List<ToDo>>(todoList);
        }
        private void SaveTodoListToSession(List<ToDo> todoList)
        {
            var todoListJson = JsonConvert.SerializeObject(todoList);
            HttpContext.Session.SetString("TodoList", todoListJson);
        }
        private User GetUserFromSession()
        {
            var userJson = HttpContext.Session.GetString("User");

            if (userJson != null)
            {
                // Désérialiser les données JSON de l'utilisateur
                return JsonConvert.DeserializeObject<User>(userJson);
            }

            // Retourner un utilisateur par défaut ou gérer le cas où l'utilisateur n'est pas trouvé
            return new User();
        }
    }
}
