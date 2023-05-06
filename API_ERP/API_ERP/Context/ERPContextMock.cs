using API_ERP.Class;
using Newtonsoft.Json;

namespace API_ERP.Context
{
    public class ERPcontextMock : IERPApiService
    {
        public ERPcontextMock()
        {
            string fileJsonProducts =
                File.ReadAllText(Path.Combine(AppContext.BaseDirectory, ".\\Data\\products.json"));
            string fileJsonCustomers =
                File.ReadAllText(Path.Combine(AppContext.BaseDirectory, ".\\Data\\customers.json"));
            products = JsonConvert.DeserializeObject<List<Product>>(fileJsonProducts);
            customers = JsonConvert.DeserializeObject<List<Customer>>(fileJsonCustomers);
        }

        public List<Customer> customers { get; }
        public List<Product> products { get; }

        #region Command

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

            Order orderSelected = commands.FirstOrDefault(c => c.Id == id);
            return orderSelected;
        }

        public async Task<Order> AddCommandAsync(Order addedOrder)
        {
            Customer existingCustomer = customers.FirstOrDefault(c => c.Id == addedOrder.CustomerId);
            if (existingCustomer == null)
            {
                return null;
            }

            if (await GetCommandAsync(addedOrder.Id) != null)
            {
                return null;
            }

            List<Order> listOrder = await GetCommandsAsync();
            Order lastOrder = listOrder.OrderByDescending(c => c.Id).FirstOrDefault();
            int newOrderId = (lastOrder != null) ? lastOrder.Id + 1 : 1;

            addedOrder.Id = newOrderId;
            existingCustomer.Orders.Add(addedOrder);

            // save changes to file
            File.WriteAllText(".\\Data\\customers.json", JsonConvert.SerializeObject(customers));

            return addedOrder;
        }

        public async Task<Order> UpdateCommandAsync(Order updatedOrder)
        {
            if (updatedOrder != null)
            {
                // Recherche de la commande à mettre à jour
                Customer customer = customers.FirstOrDefault(c => c.Id == updatedOrder.CustomerId);
                if (customer != null)
                {
                    Order order = customer.Orders.FirstOrDefault(o => o.Id == updatedOrder.Id);
                    if (order != null)
                    {
                        // Mise à jour des propriétés de la commande
                        order.CreatedAt = updatedOrder.CreatedAt;

                        // Sauvegarde des modifications dans le fichier JSON
                        File.WriteAllText(".\\Data\\customers.json", JsonConvert.SerializeObject(customers));

                        return updatedOrder;
                    }
                }
            }

            return null;
        }

        public async Task<Order> DeleteCommandAsync(int id)
        {
            Order deletedOrder = await GetCommandAsync(id);
            if (deletedOrder != null)
            {
                Order orderFichier = customers.FirstOrDefault(c => c.Id == deletedOrder.CustomerId).Orders
                    .FirstOrDefault(o => o.Id == id);
                customers.FirstOrDefault(c => c.Id == deletedOrder.CustomerId).Orders.Remove(orderFichier);
                File.WriteAllText(".\\Data\\customers.json", JsonConvert.SerializeObject(customers));
                return deletedOrder;
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region Product

        public async Task<List<Product>> GetProductsAsync()
        {
            return products;
        }

        public async Task<Product> GetProductAsync(int id)
        {
            Product product = products.FirstOrDefault(c => c.Id == id);
            return product;
        }

        public async Task<Product> AddProductAsync(Product addedProduct)
        {
            Product lastProduct = products.OrderByDescending(p => p.Id).FirstOrDefault();
            int newProductId = (lastProduct != null) ? lastProduct.Id + 1 : 1;
            if (addedProduct != null)
            {
                addedProduct.Id = newProductId;
                products.Add(addedProduct);
                File.WriteAllText(".\\Data\\products.json", JsonConvert.SerializeObject(products));
                return addedProduct;
            }
            else
            {
                return null;
            }
        }

        public async Task<Product> DeleteProductAsync(int id)
        {
            Product deletedProduct = await GetProductAsync(id);
            if (deletedProduct != null)
            {
                products.Remove(deletedProduct);
                File.WriteAllText(".\\Data\\products.json", JsonConvert.SerializeObject(products));
                return deletedProduct;
            }
            else
            {
                return null;
            }
        }

        public async Task<Product> UpdateProductAsync(Product updatedProduct)
        {
            if (updatedProduct != null)
            {
                // Recherche de la commande à mettre à jour
                Product productToUpdate = await GetProductAsync(updatedProduct.Id);
                if (productToUpdate != null)
                {
                    // Mise à jour des propriétés de la commande
                    productToUpdate.Details = updatedProduct.Details;
                    productToUpdate.Name = updatedProduct.Name;
                    productToUpdate.Stock = updatedProduct.Stock;

                    // Sauvegarde des modifications dans le fichier JSON
                    File.WriteAllText(".\\Data\\products.json", JsonConvert.SerializeObject(products));

                    return productToUpdate;
                }
            }

            return null;
        }

        #endregion
    }
}