using API_ERP.Class;
using API_ERP.Context;
using API_ERP.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace API_ERP_Test
{
    public class ERPControllerTests
    {
        private ERPcontextMock _contextMock = new ERPcontextMock();
        #region commandes test
        [Fact]
        public async Task GetAllCommands_ReturnsListOrders()
        {
            //arrage 
            CommandesController controller = new CommandesController(_contextMock);

            //Act
            var result = await controller.GetAllCommands();

            //Assert 
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Order>>(actionResult.Value);
            Assert.NotNull(result);
        }
        [Fact]
        public async Task GetCommand_ReturnsOrder()
        {
            // Arrange
            CommandesController controller = new CommandesController(_contextMock);
            Customer customerResult = _contextMock.customers.Where(c => c.Orders != null).FirstOrDefault();
            Order orderResult = customerResult.Orders.FirstOrDefault();


            // Act
            IActionResult result = await controller.GetCommand(orderResult.Id);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            OkObjectResult objectResult = (OkObjectResult)result;
            Assert.IsType<Order>(objectResult.Value);
            Order order = (Order)objectResult.Value;
            Assert.Equal(orderResult.Id, order.Id);
            Assert.Equal(customerResult.Id, order.CustomerId);
        }
        [Fact]
        public async Task AddCommand_ReturnsCreatedResult()
        {
            // Arrange
            CommandesController controller = new CommandesController(_contextMock);
            Customer customer = _contextMock.customers.FirstOrDefault();
            Order order = new Order
            {
                CreatedAt = DateTime.Now,
                CustomerId = customer.Id
            };

            // Act
            IActionResult result = await controller.AddCommand(order);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            OkObjectResult createdResult = (OkObjectResult)result;
            Assert.IsType<Order>(createdResult.Value);
            Order createdOrder = (Order)createdResult.Value;
            Assert.Equal(order.CreatedAt, createdOrder.CreatedAt);
            Assert.Equal(order.CustomerId, createdOrder.CustomerId);
            Assert.NotEqual(0, createdOrder.Id);
        }
        
        [Fact]
        public async Task UpdateCommand_ModelIsValid()
        {
            // Arrange
            CommandesController controller = new CommandesController(_contextMock);
            Customer customerResult = _contextMock.customers.FirstOrDefault();
            Order orderResult = customerResult.Orders.FirstOrDefault();
            Order orderUpdated = new Order { Id = orderResult.Id, CustomerId = customerResult.Id, CreatedAt = orderResult.CreatedAt.AddDays(1) };

            // Act
            IActionResult result = await controller.UpdateCommand(orderUpdated);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            OkObjectResult updatedResult = (OkObjectResult)result;
            Order updatedOrder = (Order)updatedResult.Value;
            Assert.Equal(orderUpdated.Id, updatedOrder.Id);
            Assert.Equal(orderUpdated.CustomerId, updatedOrder.CustomerId);
            Assert.Equal(orderUpdated.CreatedAt, updatedOrder.CreatedAt);
        }
        [Fact]
        public async Task DeleteCommand_ReturnsOkResult()
        {
            // Arrange
            CommandesController controller = new CommandesController(_contextMock);
            Customer customer = _contextMock.customers.FirstOrDefault();
            Order orderToDelete = customer.Orders.FirstOrDefault();
            int orderIdToDelete = orderToDelete.Id;

            // Act
            IActionResult result = await controller.DeleteCommand(orderIdToDelete);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            Customer customerAfterDelete = _contextMock.customers.Where(c => c.Id == customer.Id).FirstOrDefault();
            Assert.NotNull(customerAfterDelete);
            Assert.DoesNotContain(customerAfterDelete.Orders, o => o.Id == orderIdToDelete);
        }
        #endregion
        #region Produits
        [Fact]
        public async Task GetAllProducts_ReturnsListProducts()
        {
            // Arrange
            ProduitsController controller = new ProduitsController(_contextMock);

            // Act
            var result = await controller.GetAllProduct();

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Product>>(actionResult.Value);
            Assert.NotNull(result);
        }
        [Fact]
        public async Task GetProduct_ReturnsProduct()
        {
            // Arrange
            ProduitsController controller = new ProduitsController(_contextMock);
            Product productResult = _contextMock.products.FirstOrDefault();

            // Act
            IActionResult result = await controller.GetProduct(productResult.Id);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            OkObjectResult objectResult = (OkObjectResult)result;
            Assert.IsType<Product>(objectResult.Value);
            Product product = (Product)objectResult.Value;
            Assert.Equal(productResult.Id, product.Id);
            Assert.Equal(productResult.Name, product.Name);
            Assert.Equal(productResult.Details.Description, product.Details.Description);
            Assert.Equal(productResult.Details.Price, product.Details.Price);
            Assert.Equal(productResult.Details.Color, product.Details.Color);
            Assert.Equal(productResult.Stock, product.Stock);
        }
        [Fact]
        public async Task AddProduct_ReturnsCreatedResult()
        {
            // Arrange
            ProduitsController controller = new ProduitsController(_contextMock);
            Product product = new Product
            {
                CreatedAt = DateTime.Now,
                Name = "Test Product",
                Details = new Details
                {
                    Price = 10.0f,
                    Description = "This is a test product",
                    Color = "Red"
                },
                Stock = 5
            };

            // Act
            IActionResult result = await controller.AddProduct(product);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            OkObjectResult createdResult = (OkObjectResult)result;
            Assert.IsType<Product>(createdResult.Value);
            Product createdProduct = (Product)createdResult.Value;
            Assert.Equal(product.CreatedAt, createdProduct.CreatedAt);
            Assert.Equal(product.Name, createdProduct.Name);
            Assert.Equal(product.Details.Description, createdProduct.Details.Description);
            Assert.Equal(product.Details.Price, createdProduct.Details.Price);
            Assert.Equal(product.Details.Color, createdProduct.Details.Color);
            Assert.Equal(product.Stock, createdProduct.Stock);
            Assert.NotEqual(0, createdProduct.Id);
        }
        [Fact]
        public async Task UpdateProduct_ModelIsValid()
        {
            // Arrange
            ProduitsController controller = new ProduitsController(_contextMock);
            Product productResult = _contextMock.products.FirstOrDefault();
            Product productUpdated = new Product
            {
                Id = productResult.Id,
                Name = "New Name",
                Stock = 5,
                Details = new Details
                {
                    Description = "New Description",
                    Price = 10.99f,
                    Color = "Blue"
                },
                CreatedAt = productResult.CreatedAt.AddDays(1)
            };
           
            // Act
            IActionResult result = await controller.UpdateProduct(productUpdated);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            OkObjectResult updatedResult = (OkObjectResult)result;
            Product updatedProduct = (Product)updatedResult.Value;
            Assert.Equal(productUpdated.Id, updatedProduct.Id);
            Assert.Equal(productUpdated.Name, updatedProduct.Name);
            Assert.Equal(productUpdated.Stock, updatedProduct.Stock);
            Assert.Equal(productUpdated.Details.Description, updatedProduct.Details.Description);
            Assert.Equal(productUpdated.Details.Price, updatedProduct.Details.Price);
            Assert.Equal(productUpdated.Details.Color, updatedProduct.Details.Color);
        }

        [Fact]
        public async Task DeleteProduct_ReturnsOkResult()
        {
            // Arrange
            ProduitsController controller = new ProduitsController(_contextMock);
            Product productToDelete = _contextMock.products.FirstOrDefault();
            int productIdToDelete = productToDelete.Id;

            // Act
            IActionResult result = await controller.DeleteProduct(productIdToDelete);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            Product productAfterDelete = _contextMock.products.Where(p => p.Id == productIdToDelete).FirstOrDefault();
            Assert.Null(productAfterDelete);
        }

        #endregion
    }
}