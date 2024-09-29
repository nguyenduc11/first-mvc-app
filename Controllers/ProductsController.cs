using Microsoft.AspNetCore.Mvc;
using MyApp.Models;
using MyApp.ViewModels;
namespace MyApp.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            var products = ProductsRepository.GetProducts(loadCaegory: true);
            return View(products);
        }

        public IActionResult Add()
        {
            ViewBag.Action = "add";
            var productViewModel = new ProductViewModel
            {
                Categories = CategoriesRepository.GetCategories()
            };
            return View(productViewModel);
        }

        [HttpPost]
        public IActionResult Add(ProductViewModel productViewModel)
        {
            ViewBag.Action = "add";
            // Check if the model state is valid
            if (ModelState.IsValid)
            {
                // Add the product to the repository
                ProductsRepository.AddProduct(productViewModel.Product);

                // Redirect to the Index action after successful addition
                return RedirectToAction(nameof(Index));
            }
            Console.WriteLine("ModelState is invalid");
            // If the model state is invalid, repopulate the Categories list
            productViewModel.Categories = CategoriesRepository.GetCategories();

            // Return the view with the existing model to display validation messages
            return View(productViewModel);
        }


        public IActionResult Edit(int id)
        {
            var product = ProductsRepository.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            ViewBag.Action = "edit";
            var productViewModel = new ProductViewModel
            {
                Product = product,
                Categories = CategoriesRepository.GetCategories()
            };
            return View(productViewModel);
        }
    }
}