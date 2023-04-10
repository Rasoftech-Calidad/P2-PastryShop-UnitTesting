using Microsoft.AspNetCore.Mvc;
using Moq;
using PastryShopAPI.Controllers;
using PastryShopAPI.Models;
using PastryShopAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.ControllersTest
{
    public class ProductControllerShould
    {
        [Fact]
        public void Add_product_ReturnSameProduct()
        {
            // Arrange
            var productModel = new ProductModel()
            {
                Id = 1,
                Name = "Tortas",
                Description = "Tortas de todos los sabores",
                ImageUrl = "https://www.paulinacocina.net/wp-content/uploads/2022/04/selva-negra-receta-1.jpg",
                Rating = 5,
            };

            int productId = 1;
            int categoryId = 1;
            var productServiceMock = new Mock<IProductsService>();
            var fileServiceMock = new Mock<IFileService>();

            // Act
            productServiceMock.Setup(r => r.GetProductAsync(categoryId, productId)).ReturnsAsync(productModel);
            var productController = new ProductsController(productServiceMock.Object, fileServiceMock.Object);
            var response = productController.GetProductAsync(1, 1);
            var result = response.Result as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }
        
    }
}
