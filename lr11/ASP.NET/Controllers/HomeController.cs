using Microsoft.AspNetCore.Mvc;
public class HomeController : Controller
{
    [Route("/")]
    public IActionResult Home()
    {
        return View();
    }
}