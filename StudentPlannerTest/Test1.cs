using StudentPlanner.Models;
using StudentPlanner.Controllers;
namespace StudentPlannerTest;

[TestClass]
public sealed class Test1
{
    [TestMethod]
    public void NyIdSkalVæreHoyereEnn1()
    {
        List<TaskItem> task = new List<TaskItem>()
        {
            new TaskItem
            {
                Id = 1, Title = "Innlevering 1", Emne = "IS202", IsDone = false, DueDate = DateTime.Now.AddDays(15),
                Priority = "Middels"
            },
            new TaskItem
            {
                Id = 2, Title = "Innlevering 2", Emne = "IS200", IsDone = false, DueDate = DateTime.Now.AddDays(10),
                Kommentar = "Kommentar", Priority = "Lav"
            },
            new TaskItem
            {
                Id = 5, Title = "Innlevering 2", Emne = "IS200", IsDone = false, DueDate = DateTime.Now.AddDays(10),
                Kommentar = "Kommentar", Priority = "Lav"
            }
        };

        Assert.AreEqual(5, task.Max(t => t.Id));
        int nyId = HomeController.GetNextId(task);
        Assert.AreEqual(6, nyId);


    }
}