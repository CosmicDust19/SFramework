using System.Web.Mvc;
using SFramework.Northwind.Business.Abstract;
using SFramework.Northwind.Entities.Concrete;
using SFramework.Northwind.MvcWebUI.Models;

namespace SFramework.Northwind.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Index()
        {
            var model = new ProductListViewModel
            {
                Products = _productService.GetAll()
            };
            return View(model);
        }

        public string Add()
        {
            _productService.Add(new Product
            {
                CategoryId = 1,
                ProductName = "AGsm",
                QuantityPerUnit = "1",
                UnitPrice = 25
            });
            return "Added";
        }

        public string AddUpdate()
        {
            _productService.TransactionalOperation(
                new Product
                {
                    CategoryId = 1,
                    ProductName = "AGsm",
                    QuantityPerUnit = "2",
                    UnitPrice = 21
                },
                new Product
                {
                    ProductId = 79,
                    CategoryId = 1,
                    ProductName = "AAGsm",
                    QuantityPerUnit = "2",
                    UnitPrice = 10
                });
            return "Transactional";
        }

    }
}