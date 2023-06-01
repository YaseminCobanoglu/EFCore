using EFCore.Models.Context;
using EFCore.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.Controllers
{
    public class CategoryController:Controller
    {
        MyContext _db;

        public CategoryController(MyContext db)
        {
            _db = db;
        }

        public IActionResult GetCategories()
        {
            //databasedeki kategorylerin listelenmesi
            return View(_db.Categories.ToList());
        }

        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(Category item)
        {
            _db.Categories.Add(item);
            _db.SaveChanges();
            return RedirectToAction("GetCategories");

        }

        public IActionResult UpdateCategory(int id)
        {
            return View(_db.Categories.Find(id));
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category item) 
        {
            Category original = _db.Categories.Find(item.ID);
            original.CategoryName=item.CategoryName;
            original.Description=item.Description;  
            original.ModifiedDate=item.ModifiedDate;
            _db.SaveChanges();
            return RedirectToAction("GetCategories");
        }
         
        public IActionResult DeleteCategory(int id)
        {
            _db.Categories.Remove(_db.Categories.Find(id));
            _db.SaveChanges();
            return RedirectToAction("GetCategories");
        }
    }
}
