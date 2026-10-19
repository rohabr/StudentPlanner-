using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StudentPlanner.DataAccess;
using StudentPlanner.Models;
 using TaskStatus = StudentPlanner.Models.TaskCategory;


namespace StudentPlanner.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _db;

    public HomeController(ApplicationDbContext db)
    {
        _db = db;
    }
    
                                                                                                                                             
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult TodoList()
    {
        return View(_db.Tasks.ToList());                                                                                                                           
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        var taskItemToRemove = _db.Tasks.Find(id);
        
        if (taskItemToRemove != null)
        {
            _db.Tasks.Remove(taskItemToRemove);
            _db.SaveChanges();

        }
        return RedirectToAction("TodoList");

    }

    [HttpPost]
    public IActionResult ToggleComplete(int id)
    {
        var taskItemToComplete = _db.Tasks.Find(id);
        if (taskItemToComplete != null)
        {
            taskItemToComplete.IsDone = !taskItemToComplete.IsDone;
            _db.SaveChanges();

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
        _db.Add(taskItem);
        _db.SaveChanges();
        
        return RedirectToAction("TodoList");
    }
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public static TaskCategory GetTaskStatus(TaskItem task, DateTime now)
    {
        if (task.IsDone)
        {
            return TaskCategory.Completed;
        }

        if (task.DueDate == null)
        {
            return TaskCategory.NoDueDate;
        }

        DateTime dueDate = task.DueDate.Value.Date;

        if (dueDate < now.Date)
        {
            return TaskCategory.OverDue;
        }
        
        if (dueDate == now.Date)
        {
            return TaskCategory.DueToday;
        }
        
        if (dueDate < now.Date.AddDays(7))
        {
            return TaskCategory.DueSoon;
        }

        return TaskCategory.Upcoming;
        
    }
}