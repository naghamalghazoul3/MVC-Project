using Microsoft.AspNetCore.Mvc;
using NTierTodoApp.Business;

namespace NTierTodoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly TaskService taskService;

        public HomeController(TaskService service)
        {
            taskService = service;
        }

        /// <summary>
        /// يعرض قائمة المهام.
        /// </summary>
        public IActionResult Index()
        {
            var tasks = taskService.GetTasks();
            return View(tasks);
        }

        /// <summary>
        /// إضافة مهمة جديدة.
        /// </summary>
        [HttpPost]
        public IActionResult AddTask(string title)
        {
            if (!string.IsNullOrWhiteSpace(title))
                taskService.AddTask(title);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// تعيين مهمة كمكتملة.
        /// </summary>
        [HttpPost]
        public IActionResult CompleteTask(int id)
        {
            taskService.CompleteTask(id);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// حذف مهمة.
        /// </summary>
        [HttpPost]
        public IActionResult DeleteTask(int id)
        {
            taskService.DeleteTask(id);
            return RedirectToAction("Index");
        }
    }
}
