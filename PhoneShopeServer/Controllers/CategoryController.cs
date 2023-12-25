using Microsoft.AspNetCore.Mvc;
using PhoneShopeLibrary.Models;
using PhoneShopeLibrary.Responses;
using PhoneShopeServer.Repositories;

namespace PhoneShopeServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(ICategory _ServiceCategory) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetAllCategories()
        {
            var categories = await _ServiceCategory.GetAllCategories();
            return Ok(categories);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse>> AddCategory(Category model)
        {
            if (model is null) return BadRequest("Model is Null!");
            var response = await _ServiceCategory.AddCategory(model);
            return Ok(response);
        }
    }
}
