using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;
using System.Linq;

public class UniqueUsersFilter : ActionFilterAttribute
{
    private readonly string file = "users.log";
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        try
        {
            var userIdentifier = context.HttpContext.Connection.RemoteIpAddress.ToString();
            var lines = File.ReadAllLines(file);
            if (lines.Contains(userIdentifier.Trim())) return;
            
            File.AppendAllLines(file, new[] { userIdentifier });
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (IOException ex)
        {
            Console.WriteLine("An error occurred while writing to the file: " + ex.Message);
        }
    }
}