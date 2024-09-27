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
            var productViewModel = new ProductViewModel
            {
                Categories = CategoriesRepository.GetCategories()
            };
            return View(productViewModel);
        }
    }
}