using System.Collections.Generic;
using System.Web.Http;
using SFramework.Northwind.Business.Abstract;
using SFramework.Northwind.Entities.Concrete;

namespace SFramework.Northwind.WebApi.Controllers
{
    public class ProductsController : ApiController
    {

        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public List<Product> Get()
        {
            return _productService.GetAll();
        }

    }
}
