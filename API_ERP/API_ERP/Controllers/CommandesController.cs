using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using API_ERP.Class;

namespace API_ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandesController : ControllerBase
    {
        private readonly ProductApiService _productApiService;

        public CommandesController(ProductApiService productApiService)
        {
            _productApiService = productApiService;
        }
        /// <summary>
        /// Get Commande
        /// </summary>
        /// <param name="id"></param>
        /// <returns>test</returns>

        [HttpGet]
        public async Task<IActionResult> GetCommand(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }
            var product = await _productApiService.GetCommandAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        /// <summary>
        /// Get All Commandes
        /// </summary>
        /// <returns>test</returns>

        [HttpGet]
        public async Task<IActionResult> GetAllCommand()
        {
            var product = await _productApiService.GetCommandsAsync();
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
