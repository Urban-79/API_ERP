﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace API_ERP.Class
{
    public class ERPApiService : IERPApiService
    {
        private readonly HttpClient _httpClient;

        public ERPApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://615f5fb4f7254d0017068109.mockapi.io/api/v1/");
        }
        public async Task<List<Order>?> GetCommandsAsync()
        {
            var response = await _httpClient.GetAsync($"customers");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(json);
            List<Order> commands = new List<Order>();
            foreach (Customer customer in customers)
            {
                foreach (Order order in customer.Orders)
                {
                    Order command = new Order
                    {
                        CustomerId = customer.Id,
                        Id = order.Id,
                        CreatedAt = order.CreatedAt,
                    };
                    commands.Add(command);
                }
            }
            return commands;
        }
        public async Task<List<Command>?> GetCommandAsync(string id)
        {
            //Customer customer = customers.FirstOrDefault(c => c.Orders.Any(o => o.CustomerId == TON_ID));
            //Order commande = customer.Orders.FirstOrDefault(o => o.id == TON_ID);
            var response = await _httpClient.GetAsync($"customers/"+id+"/orders");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Command>>(json);
            }
            return null;
        }
        public async Task<Product?> GetProductAsync(string id)
        {
            var response = await _httpClient.GetAsync($"products/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Product>(json);
            }
            return null;
        }
        public async Task<List<Product>?> GetProductsAsync()
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
    public interface IERPApiService
    {
        Task<List<Order>?> GetCommandsAsync();
        Task<List<Command>?> GetCommandAsync(string id);
        Task<List<Product>?> GetProductsAsync();
        Task<Product?> GetProductAsync(string id);
    }

}