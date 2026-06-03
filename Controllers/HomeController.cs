using Microsoft.AspNetCore.Mvc;
using MvcTodoApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace MvcTodoApp.Controllers
{
    public class HomeController : Controller
    {
        // قائمة محاكاة لقاعدة البيانات (في الذاكرة)
        private static List<TaskItem> tasks = new List<TaskItem>
        {
            new TaskItem { Id = 1, Title = "تدرب على MVC Design Pattern", IsComplete = false },
            new TaskItem { Id = 2, Title = "تدرب على N-tier Architecture", IsComplete = false },
            new TaskItem { Id = 3, Title = "تدرب على استخدام git", IsComplete = false },
        };

        /// <summary>
        /// يعرض القائمة الرئيسية للمهام.
        /// </summary>
        public IActionResult Index()
        {
            return View(tasks);
        }

        /// <summary>
        /// إضافة مهمة جديدة.
        /// </summary>
        /// <param name="title">عنوان المهمة</param>
        [HttpPost]
        public IActionResult AddTask(string title)
        {
            if (!string.IsNullOrEmpty(title))
            {
                var newTask = new TaskItem
                {
                    Id = tasks.Max(t => t.Id) + 1,
                    Title = title,
                    IsComplete = false
                };
                tasks.Add(newTask);
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// تعيين مهمة كمكتملة.
        /// </summary>
        /// <param name="id">معرف المهمة</param>
        [HttpPost]
        public IActionResult CompleteTask(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
                task.IsComplete = true;
            return RedirectToAction("Index");
        }
        /// <summary>
        /// تعديل عنوان المهمة.
        /// </summary>
        /// <param name="id">معرف المهمة</param>
        /// <param name="newTitle">العنوان الجديد</param>
        [HttpPost]
        public IActionResult EditTask(int id, string newTitle)
        {
            // TODO: ابحث عن المهمة باستخدام id 
            // TODO: تأكد من أن المهمة موجودة وأن newTitle  غير فارغ 
            // TODO:  عدّل عنوان المهمة 
            return RedirectToAction("Index");
        }

    }
}
