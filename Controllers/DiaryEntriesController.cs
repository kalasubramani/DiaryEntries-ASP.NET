using DiaryApp.Data;
using DiaryApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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

        [HttpPost]
        public IActionResult Create(DiaryEntry obj)
        {
            //add server side validations for the data entered by the user
            if(obj!=null && obj.Title.Length < 3)
            {
                //add error msg to model state
                ModelState.AddModelError("Title", "Title too short");
            }

            //update DB only if model state is valid
            if (ModelState.IsValid)
            {
                //add the values in the obj to DB table named DiaryEntries
                _db.DiaryEntries.Add(obj);
                //save changes  to DB
                _db.SaveChanges();
                //once data is saved in DB, redirect user to the index page of DairyEntries
                return RedirectToAction("Index");
            }

            //If Model state is invalid, return the values captured in the obj to the form along with the error msg from ModelSTateErr
            return View(obj);
        }
    }
}
