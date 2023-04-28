using API_ERP.Class;
using API_ERP.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace API_ERP.Tests
{
    public class ProductsControllerTests
    {
        private readonly ProductsController _controller;

        public ProductsControllerTests()
        {
            var service = new ERPApiService(); // Remplacer par votre service de test
            _controller = new ProductsController(service);
        }

        [Fact]
        public async Task GetProduct_ReturnsBadRequest_WhenIdIsNull()
        {
            // Arrange
            string id = null;

            // Act
            var result = await _controller.GetProduct(id);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestResult>(result);
            Assert.Equal(400, badRequestResult.StatusCode);
        }

        [Fact]
        public async Task GetProduct_ReturnsNotFound_WhenProductDoesNotExist()
        {
            // Arrange
            string id = "non-existing-id";

            // Act
            var result = await _controller.GetProduct(id);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundResult>(result);
            Assert.Equal(404, notFoundResult.StatusCode);
        }

        // [Fact]
        // public async Task GetProduct_ReturnsOk_WhenProductExists()
        // {
        //     // Arrange
        //     string id = "existing-id";
        //     var mockService = new Mock<ProductApiService>();
        //     mockService.Setup(s => s.GetProductAsync(id))
        //         .ReturnsAsync(new Product { Id = id });
        //     var controller = new ProductsController(mockService.Object);
        //
        //     // Act
        //     var result = await controller.GetProduct(id);
        //
        //     // Assert
        //     var okResult = Assert.IsType<OkObjectResult>(result);
        //     var product = Assert.IsType<Product>(okResult.Value);
        //     Assert.Equal(id, product.Id);
        //     mockService.Verify(s => s.GetProductAsync(id), Times.Once);
        // }
    }
}