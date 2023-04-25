using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System.Text;

namespace API_ERP.Class
{
    public class ProductApiService
    {
        private readonly HttpClient _httpClient;

        public ProductApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://615f5fb4f7254d0017068109.mockapi.io/api/v1/");
        }

        public async Task<List<Command>> GetCommandsAsync()
        {
            var response = await _httpClient.GetAsync("command");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Command>>(json);
        }

        public async Task<Command> GetCommandAsync(string id)
        {
            var response = await _httpClient.GetAsync($"command/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Command>(json);
            }
            return null;
        }
        public async Task<Product> GetProductAsync(string id)
        {
            var response = await _httpClient.GetAsync($"products/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Product>(json);
            }
            return null;
        }
        public async Task<List<Product>> GetProductsAsync()
        {
            var response = await _httpClient.GetAsync($"products");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Product>>(json);
            }
            return null;
        }
    }
}
