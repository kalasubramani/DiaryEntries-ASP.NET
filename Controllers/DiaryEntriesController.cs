using Microsoft.AspNetCore.Mvc;

namespace DiaryApp.Controllers
{
    public class DiaryEntriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
