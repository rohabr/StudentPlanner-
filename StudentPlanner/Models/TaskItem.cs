namespace StudentPlanner.Models;

public class TaskItem
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Emne { get; set; } = "";
    public bool IsDone { get; set; } = false;
    public DateTime? DueDate { get; set; }
    public string Priority { get; set; } = "";
    public string? Kommentar { get; set; }
}