using API_ERP.Class;
using Microsoft.AspNetCore.Mvc;

namespace API_ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandesController : ControllerBase
    {
        private readonly IERPApiService _erpApiService;

        public CommandesController(IERPApiService erpApiService)
        {
            _erpApiService = erpApiService;
        }

        /// <summary>
        /// Get Commande
        /// </summary>
        /// <param name="id">Id de la commande</param>
        /// <returns>test</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommand(int id)
        {
            Order order = await _erpApiService.GetCommandAsync(id);
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
            List<Order> orders = await _erpApiService.GetCommandsAsync();
            if (orders == null)
            {
                return NotFound();
            }

            return Ok(orders);
        }

        /// <summary>
        /// Add Commande
        /// </summary>
        /// <param name="addedOrder">object order </param>
        /// <returns>test</returns>
        [HttpPost]
        public async Task<IActionResult> AddCommand(Order addedOrder)
        {
            Order result = await _erpApiService.AddCommandAsync(addedOrder);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        /// <summary>
        /// Update Commande
        /// </summary>
        /// <param name="updatedOrder">Objet Order</param>
        /// <returns>test</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateCommand(Order updatedOrder)
        {
            Order result = await _erpApiService.UpdateCommandAsync(updatedOrder);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        /// <summary>
        /// Delete Commande
        /// </summary>
        /// <param name="id">Objet Order</param>
        /// <returns>test</returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteCommand(int id)
        {
            Order result = await _erpApiService.DeleteCommandAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}