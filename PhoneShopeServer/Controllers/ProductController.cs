using Microsoft.AspNetCore.Mvc;
using PhoneShopeLibrary.Models;
using PhoneShopeLibrary.Responses;
using PhoneShopeServer.Repositories;

namespace PhoneShopeServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProduct _ServiceProduct) : ControllerBase
    {
     
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProducts(bool features)
        {
            var products = await _ServiceProduct.GetProducts(features);
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse>> AddProduct(Product model)
        {
            if (model is null) return BadRequest("Model is Null!");
            var response = await _ServiceProduct.AddProduct(model);
            return Ok(response);
        }
    }
}
