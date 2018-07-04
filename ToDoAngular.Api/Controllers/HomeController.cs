using Microsoft.AspNetCore.Mvc;

namespace ToDoAngular.Api.Controllers
{
    [Route("api")]
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("test")]
        public IActionResult Index()
        {
            return new JsonResult("the api works");
        }
    }
}