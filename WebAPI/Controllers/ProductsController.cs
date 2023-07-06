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
        //IoC Container -- Inversion of Control 
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //IProductService productService = new ProductManager(new EfProductDal());
            var result = _productService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

            #region Eski Kodlar
            //return new List<Product>
            //{
            //    new Product { ProductId = 1, ProductName = "Elma" },
            //    new Product { ProductId = 2, ProductName = "Armut" }
            //};
            #endregion
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}