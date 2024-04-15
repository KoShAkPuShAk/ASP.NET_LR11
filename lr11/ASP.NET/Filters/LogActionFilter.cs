using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
public class LogActionFilter : ActionFilterAttribute
{
    override public void OnActionExecuting(ActionExecutingContext context) => File.AppendAllText(
        "logfile.log",
        DateTime.Now + "\t"+ context.ActionDescriptor.DisplayName + Environment.NewLine
    );

}

