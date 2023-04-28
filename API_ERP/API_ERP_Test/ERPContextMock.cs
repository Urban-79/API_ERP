using API_ERP.Class;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ERP_Test
{
    internal class ERPcontextMock : IERPApiService
    {
        public List<Customer> customers { get; }

        public ERPcontextMock()
        {
            #region Add données (List<Customer> Customers)          
            customers = new List<Customer> { new Customer
            {
                CreatedAt = DateTime.Parse("2023-02-19T15:26:38.450Z"),
                Name = "Jessica Grady",
                Username = "Merle.Hammes",
                FirstName = "Johnson",
                LastName = "Gutmann",
                Address = new Address
                {
                    PostalCode = "43019",
                    City = "Port Reanna"
                },
                Profile = new Profile
                {
                    FirstName = "Malcolm",
                    LastName = "Ward"
                },
                Company = new Company
                {
                    CompanyName = "Leffler, Murphy and Wunsch"
                },
                Id = 7,
                Orders = new List<Order>
                {
                    new Order
                    {
                        CreatedAt = DateTime.Parse("2023-02-19T21:15:11.180Z"),
                        Id = 7,
                        CustomerId = 7
                    },
                    new Order
                    {
                        CreatedAt = DateTime.Parse("2023-02-19T14:36:25.139Z"),
                        Id = 57,
                        CustomerId = 7
                    }
                }
            }};
            #endregion
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

        public Task<Order> GetCommandAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}


