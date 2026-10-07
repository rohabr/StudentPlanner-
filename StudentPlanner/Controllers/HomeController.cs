using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Matching;
using StudentPlanner.DataAccess;
using StudentPlanner.Models;

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
}