using API_ERP.Class;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API_ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductApiService _productApiService;

        public ProductsController(ProductApiService productApiService)
        {
            _productApiService = productApiService;
        }

        /// <summary>
        /// Get Commande
        /// </summary>
        /// <param name="id"></param>
        /// <returns>test</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }
            var product = await _productApiService.GetProductAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        /// <summary>
        /// Get All Product
        /// </summary>
        /// <returns>test</returns>

        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var product = await _productApiService.GetProductsAsync();
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);            
        }
    }
}
