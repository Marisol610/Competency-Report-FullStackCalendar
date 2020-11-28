

using Microsoft.AspNetCore.Mvc;
using FullStackCalendar.Models;
using System.Linq;

namespace FullStackCalendar.Controllers

{

public class ApiController : Controller
{
    private DataContext dbContext;

    public ApiController(DataContext db)
    {
        this.dbContext =db;
    }

[HttpPost]
public IActionResult SaveTask([FromBody] Task theTask)
{
      
       dbContext.Tasks.Add(theTask);
       dbContext.SaveChanges(); 
        
        return Json(theTask);
}

[HttpGet]

public IActionResult GetTasks() 
{
    var allTasks = dbContext.Tasks.ToList();
    return Json(allTasks);
    
}

[HttpDelete]

public IActionResult DeleteTask(int id)
{
    Task theTask = dbContext.Tasks.Find(id);// find the task with the id
    dbContext.Tasks.Remove(theTask);
    dbContext.SaveChanges();

    return Ok();
}

public IActionResult Test()
{
    return Content("Hello FSDI");
}

}

}
//SQL
//"insert into Task(id, title, location, important) VALUE(" +obj.id+ " + "+obj.title +", " +obj.location + "," +obj.important +")";