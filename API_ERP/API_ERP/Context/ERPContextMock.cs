using API_ERP.Class;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace API_ERP_Context
{
    public class ERPcontextMock : IERPApiService
    {
        public List<Customer> customers { get; }
        public List<Product> Products { get; }
        public ERPcontextMock()
        {
            string fileJsonProducts = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, ".\\Data\\products.json"));
            string fileJsonCustomers = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, ".\\Data\\customers.json"));
            Products = JsonConvert.DeserializeObject<List<Product>>(fileJsonProducts);
            customers = JsonConvert.DeserializeObject<List<Customer>>(fileJsonCustomers);
        }

        public async Task<List<Order>> GetCommandsAsync()
        {
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

        public async Task<Order> GetCommandAsync(int id)
        {
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
            Order OrderSelected = commands.FirstOrDefault(c => c.Id == id);
            return OrderSelected;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return Products;
        }

        public async Task<Product> GetProductAsync(int id)
        {            
           Product product = Products.FirstOrDefault(c => c.Id == id);
           return product;
        }
    }
}


