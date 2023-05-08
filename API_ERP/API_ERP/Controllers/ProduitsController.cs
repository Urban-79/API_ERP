using API_ERP.Class;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API_ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduitsController : ControllerBase
    {
        private readonly IERPApiService _ERPApiService;

        public ProduitsController(IERPApiService ERPApiService)
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

        /// <summary>
        /// Add Product
        /// </summary>
        /// <param name="addedOrder">object order </param>
        /// <returns>test</returns>
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product addedProduct)
        {
            Product result = await _ERPApiService.AddProductAsync(addedProduct);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        /// <summary>
        /// Update Product
        /// </summary>
        /// <param name="updatedProduct">Objet Product</param>
        /// <returns>test</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(Product updatedProduct)
        {
            Product result = await _ERPApiService.UpdateProductAsync(updatedProduct);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        /// <summary>
        /// Delete Product
        /// </summary>
        /// <param name="id">Objet Product</param>
        /// <returns>test</returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            Product result = await _ERPApiService.DeleteProductAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
