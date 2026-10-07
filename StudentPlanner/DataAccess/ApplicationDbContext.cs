using Microsoft.EntityFrameworkCore;
using StudentPlanner.Models;

namespace StudentPlanner.DataAccess;


public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options){}
    
    public DbSet<TaskItem> Tasks { get; set; }

}