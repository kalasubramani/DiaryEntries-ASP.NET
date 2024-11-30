using DiaryApp.Data;
using DiaryApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiaryApp.Controllers
{
    public class DiaryEntriesController : Controller
    {
        private readonly ApplicationDbContext _db;


        //dependeny injection of DB contxt
        public DiaryEntriesController(ApplicationDbContext db)
        {
            _db= db;            
        }
        public IActionResult Index()
        {
            //get the corr. table from db and convert it to a list. Then assign it to <List> obj to be passed to corr. view
            List<DiaryEntry> objDiaryEntryList = _db.DiaryEntries.ToList();
            //pass data to view
            return View(objDiaryEntryList);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
