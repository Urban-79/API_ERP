using API_ERP.Class;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly IERPApiService _ERPApiService;

        public StocksController(IERPApiService ERPApiService)
        {
            _ERPApiService = ERPApiService;
        }
        /// <summary>
        /// Get Stock
        /// </summary>
        /// <param name="id">Id du produit</param>
        /// <returns>test</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStock(int id)
        {
            int product = await _ERPApiService.GetStockAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        /// <summary>
        /// Update Stock
        /// </summary>
        /// <param name="id">Id du produit</param>
        ///  <param name="stock">nombre de stock</param>
        /// <returns>test</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateStock(int id,int stock)
        {
            Product product = await _ERPApiService.UpdateStockAsync(id, stock);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
