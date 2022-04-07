using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsingAuthoorizationWithSwagger.Data;

namespace UsingAuthoorizationWithSwagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = ProductStore.GetProduct();

            return Ok(products);
        }


        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = ProductStore.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);


        }
    }
}
