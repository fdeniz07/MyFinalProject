using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] // --> Attribute
    public class ProductsController : ControllerBase
    {
        //Loosely coupled - gevsek baglilik
        //naming convention --> isimlendirme kurallari private readonly _serviceName
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        public List<Product> Get()
        {
            //IProductService productService = new ProductManager(new EfProductDal());
            var result = _productService.GetAll();
            return result.Data;


            //return new List<Product>
            //{
            //    new Product { ProductId = 1, ProductName = "Elma" },
            //    new Product { ProductId = 2, ProductName = "Armut" }
            //};
        }
    }
}