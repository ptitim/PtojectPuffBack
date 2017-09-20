using Microsoft.AspNetCore.Mvc;

namespace ProjetPuff.Controllers
{
    public class EventController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return
            View();
        }
    }
}