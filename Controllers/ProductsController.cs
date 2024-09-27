using Microsoft.AspNetCore.Mvc;
using MyApp.Models;
namespace MyApp.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            var products = ProductsRepository.GetProducts();
            return View(products);
        }
    }
}