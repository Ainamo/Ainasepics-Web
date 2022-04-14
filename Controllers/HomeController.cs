using Microsoft.AspNetCore.Mvc;

namespace AinasepicsApi.Controllers;

[Route("/")]
public class HomeController : ControllerBase
{
    [HttpGet]
    [Produces("text/html")]
    public ActionResult<string> Get() {
        string htmlContent = System.IO.File.ReadAllText("Data/Pages/Home.html");
        return htmlContent;
    }
}
