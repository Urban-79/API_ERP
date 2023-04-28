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
        private readonly IERPApiService _ERPApiService;

        public ProductsController(IERPApiService ERPApiService)
        {
            _ERPApiService = ERPApiService;
        }

        /// <summary>
        /// Get Product
        /// </summary>
        /// <param name="id"></param>
        /// <returns>test</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _ERPApiService.GetProductAsync(id);
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
            var product = await _ERPApiService.GetProductsAsync();
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);            
        }
    }
}
