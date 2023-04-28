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
        private readonly IERPApiService _ERPApiService;

        public CommandesController(IERPApiService ERPApiService)
        {
            _ERPApiService = ERPApiService;
        }
        /// <summary>
        /// Get Commande
        /// </summary>
        /// <param name="id">Id de la commande</param>
        /// <returns>test</returns>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommand(int id)
        {
            var order = await _ERPApiService.GetCommandAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
        /// <summary>
        /// Get all Commandes
        /// </summary>      
        /// <returns>test</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllCommands()
        {
            var orders = await _ERPApiService.GetCommandsAsync();
            if (orders == null)
            {
                return NotFound();
            }
            return Ok(orders);
        }
    }
}
