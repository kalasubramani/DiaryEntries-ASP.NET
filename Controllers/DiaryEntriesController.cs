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

        //retieves data from db for the selected row
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            //get the DB record with given id
            if (id == null || id == 0) return NotFound();//display 404 error message

            DiaryEntry? diaryEntry = _db.DiaryEntries.Find(id);
            if (diaryEntry == null) return NotFound();

            //return view with data retrieved from sb
            return View(diaryEntry);
        }

        //update db with edited diary entry
        [HttpPost]
        public IActionResult Edit(DiaryEntry obj)
        {
            //add server side validations for the data entered by the user
            if (obj != null && obj.Title.Length < 3)                            
                ModelState.AddModelError("Title", "Title too short");
            

            //update DB only if model state is valid
            if (ModelState.IsValid)
            {
                //updates the values in the obj to DB table named DiaryEntries
                _db.DiaryEntries.Update(obj);
                //save changes  to DB
                _db.SaveChanges();
                //once data is saved in DB, redirect user to the index page of DairyEntries
                return RedirectToAction("Index");
            }

            //If Model state is invalid, return the values captured in the obj to the form along with the error msg from ModelSTateErr
            return View(obj);
        }

        //display the diary entry selected by user to be deleted
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            //get the DB record with given id
            if (id == null || id == 0) return NotFound();//display 404 error message

            DiaryEntry? diaryEntry = _db.DiaryEntries.Find(id);
            if (diaryEntry == null) return NotFound();

            //return view with data retrieved from sb
            return View(diaryEntry);
        }

        [HttpPost]
        public IActionResult Delete(DiaryEntry obj)
        {
                //deletes the diary entry from db
                _db.DiaryEntries.Remove(obj);
                //save changes  to DB
                _db.SaveChanges();
                //once db is updated, redirect user to the index page of DairyEntries
                return RedirectToAction("Index");
        }
    }
}
