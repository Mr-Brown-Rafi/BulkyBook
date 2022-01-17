using BulkyBook.DataAccess;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitofWork _unitofWork;

        public CategoryController(IUnitofWork db)
        {
            _unitofWork = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryist = _unitofWork.category.GetAll();
            return View(objCategoryist);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            //Here we are checking for custom validations,key should be unique and wecould add labek names and erros can be summerize
            if(category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Name and Display order should not be equal");
            }
            if(ModelState.IsValid)
            {
                _unitofWork.category.Add(category);
                _unitofWork.Save();
                TempData["Success"] = "Category added successfully.";
                return RedirectToAction("Index");
            }
            return View(category);
        }
        
        //GET
        public IActionResult Edit(int? id)
        {
            if(id == null && id == 0)
            {
                return NotFound();
            }
            var category = _unitofWork.category.FirstOrDefault(c => c.Id == id); // we can use firstOrDefualt,singleOrdefault,Find,Single,
            if(category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            //Here we are checking for custom validations,key should be unique and wecould add labek names and erros can be summerize
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Name and Display order should not be equal");
            }
            if (ModelState.IsValid)
            {
                _unitofWork.category.Update(category);
                _unitofWork.Save();
                TempData["Success"] = "Category updated successfully.";
                return RedirectToAction("Index");
            }
            return View(category);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null && id == 0)
            {
                return NotFound();
            }
            var category = _unitofWork.category.FirstOrDefault(c => c.Id == id); // we can use firstOrDefualt,singleOrdefault,Find,Single,
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var obj = _unitofWork.category.FirstOrDefault(c => c.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitofWork.category.Remove(obj);
            _unitofWork.Save();
            TempData["Success"] = "Category deleted successfully.";
            return RedirectToAction("Index");
        }
    }
}
