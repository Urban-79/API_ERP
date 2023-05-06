using API_ERP.Class;
using Microsoft.AspNetCore.Mvc;

namespace API_ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IERPApiService _erpApiService;

        public ProductsController(IERPApiService erpApiService)
        {
            _erpApiService = erpApiService;
        }

        /// <summary>
        /// Get Product
        /// </summary>
        /// <param name="id"></param>
        /// <returns>test</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _erpApiService.GetProductAsync(id);
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
            var product = await _erpApiService.GetProductsAsync();
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        /// <summary>
        /// Add Commande
        /// </summary>
        /// <param name="addedProduct">object order </param>
        /// <returns>test</returns>
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product addedProduct)
        {
            Product result = await _erpApiService.AddProductAsync(addedProduct);
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
        public async Task<IActionResult> UpdateCommand(Product updatedProduct)
        {
            Product result = await _erpApiService.UpdateProductAsync(updatedProduct);
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
            Product result = await _erpApiService.DeleteProductAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}