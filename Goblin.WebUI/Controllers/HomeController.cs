using Microsoft.AspNetCore.Mvc;

namespace Goblin.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "hello there";
        }
    }
}
