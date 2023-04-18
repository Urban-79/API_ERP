using API_ERP.Class;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API_ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class productsController : ControllerBase
    {
        /// <summary>
        /// Get Commande
        /// </summary>
        /// <param name="id"></param>
        /// <returns>test</returns>

        [HttpGet]
        public async Task<IActionResult> GetProduct(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }

            using (var httpClient = new HttpClient())
            {
                var apiUrl = "https://615f5fb4f7254d0017068109.mockapi.io/api/v1/products/" + id;
                var response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Command>(json);
                    return Ok(result);
                }

                return BadRequest();
            }
        }
    }
}
