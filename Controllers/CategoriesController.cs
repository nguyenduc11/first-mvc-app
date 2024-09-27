using Microsoft.AspNetCore.Mvc;
using MyApp.Models;

namespace MyApp.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            var categories = CategoriesRepository.GetCategories();
            return View(categories);
        }

        public IActionResult Edit([FromRoute] int id)
        {
            // var category = new Category { CategoryId = id };
            ViewBag.Action = "edit";
            var category = CategoriesRepository.GetCategoryById(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (category != null)
            {
                CategoriesRepository.UpdateCategory(category.CategoryId, category);
            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "add";
            return View();
        }
        [HttpPost]
        public IActionResult Add(Category category)
        {
            CategoriesRepository.AddCategory(category);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete([FromRoute] int id)
        {
            CategoriesRepository.DeleteCategory(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

