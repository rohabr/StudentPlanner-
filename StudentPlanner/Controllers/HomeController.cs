using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Matching;
using StudentPlanner.Models;

namespace StudentPlanner.Controllers;

public class HomeController : Controller
{
    
    private static List<TaskItem> task = new List<TaskItem>()
    {
        new TaskItem {Id = 1, Title =  "Innlevering 1", Emne = "IS202", IsDone = false, DueDate = DateTime.Now.AddDays(15), Priority = PriorityLevel.Høy},
        new TaskItem {Id = 2,Title = "Mappe innlevering 1", Emne = "IS201", IsDone = false, DueDate = DateTime.Now.AddDays(30), Priority = PriorityLevel.Lav},
        new TaskItem {Id = 3,Title = "Sprint review", Emne = "IS200", IsDone = true, DueDate = DateTime.Now.AddDays(7), Priority = PriorityLevel.Middels}
    };

    public static int GetNextId(List<TaskItem> task)
    {
        if (task.Count == 0) return 1;
        return task.Max(t => t.Id) + 1;
    }
                                                                                                               
                                                                                                                                             
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult TodoList()
    {
        return View(task);                                                                                                                           
    }

    public IActionResult Delete(int id)
    {
        var taskItemToRemove = task.Find(x => x.Id == id);
       
        if (taskItemToRemove != null)
        {
            task.Remove(taskItemToRemove);
        }
        return RedirectToAction("TodoList");

    }

    public IActionResult ToggleComplete(int id)
    {
        var taskItemToComplete = task.Find(t => t.Id == id);
        if (taskItemToComplete != null)
        {
            taskItemToComplete.IsDone = !taskItemToComplete.IsDone;
        }
        return RedirectToAction("TodoList");
    }

    [HttpGet]
    public IActionResult CreateTask()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreateTask(TaskItem taskItem)
    {
        taskItem.Id = GetNextId(task);        
        task.Add(taskItem);
        return RedirectToAction("TodoList");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}