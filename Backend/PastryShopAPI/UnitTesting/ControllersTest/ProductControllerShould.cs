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
            var response = productController.GetProductAsync(categoryId, productId);
            var result = response.Result as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }
        [Fact]
        public async Task Add_products_ReturnSameProducts()
        {
            // Arrange
            var productModel1 = new ProductModel()
            {
                Id = 1,
                Name = "Tortas",
                Description = "Tortas de todos los sabores",
                ImageUrl = "https://www.paulinacocina.net/wp-content/uploads/2022/04/selva-negra-receta-1.jpg",
                Rating = 5,
            };
            var productModel2 = new ProductModel()
            {
                Id = 2,
                Name = "Panes",
                Description = "Panes de todos los sabores",
                ImageUrl = "https://www.paulinacocina.net/wp-content/uploads/2022/04/selva-negra-receta-1.jpg",
                Rating = 5,
            };

            var enumerable = new List<ProductModel>() { productModel1, productModel2 } as IEnumerable<ProductModel>;
            int categoryId = 1;
            var productServiceMock = new Mock<IProductsService>();
            var fileServiceMock = new Mock<IFileService>();

            // Act
            productServiceMock.Setup(r => r.GetProductsAsync(categoryId)).ReturnsAsync(enumerable);
            var productController = new ProductsController(productServiceMock.Object, fileServiceMock.Object);
            var response = await productController.GetProductsAsync(categoryId);
            var result = (OkObjectResult)response.Result;
            var productsList = result.Value as List<ProductModel>;
            var countProductsList = productsList.Count();

            // Assert
            Assert.Equal(2, countProductsList);
            Assert.Equal(200, result.StatusCode);
        }
        [Fact]
        public async Task CreateProduct_AddProduct_ReturnSameProducts()
        {
            //Arrange
            var productFormModel = new ProductFormModel()
            {
                Id = 1,
                Name = "Tortas",
                Description = "Tortas de todos los sabores",
                ImageUrl = "https://www.paulinacocina.net/wp-content/uploads/2022/04/selva-negra-receta-1.jpg",
                Rating = 5,
            };

            int categoryId = 1;
            var productServiceMock = new Mock<IProductsService>();
            var fileServiceMock = new Mock<IFileService>();

            // Act
            productServiceMock.Setup(r => r.CreateProductAsync(categoryId, productFormModel)).ReturnsAsync(new ProductModel()
            {
                Id = 1,
                Name = "Tortas",
                Description = "Tortas de todos los sabores",
                ImageUrl = "https://www.paulinacocina.net/wp-content/uploads/2022/04/selva-negra-receta-1.jpg",
                Rating = 5,
            });
            var productController = new ProductsController(productServiceMock.Object, fileServiceMock.Object);
            var response = await productController.CreateProductFormAsync(categoryId, productFormModel);
            var result = response.Result as CreatedResult;
            var productCreated = result.Value as ProductModel;

            // Assert
            Assert.Equal(1, productCreated.Id);
            Assert.Equal("Tortas", productCreated.Name);
            Assert.Equal(201, result.StatusCode);
        }
        [Fact]
        public async Task CreateProduct_AddProduct_DeleteSameProducts()
        {
            //Arrange
            var productFormModel = new ProductFormModel()
            {
                Id = 1,
                Name = "Tortas",
                Description = "Tortas de todos los sabores",
                ImageUrl = "https://www.paulinacocina.net/wp-content/uploads/2022/04/selva-negra-receta-1.jpg",
                Rating = 5,
            };

            int categoryId = 1;
            int productId = 1;
            var productServiceMock = new Mock<IProductsService>();
            var fileServiceMock = new Mock<IFileService>();

            // Act
            productServiceMock.Setup(r => r.CreateProductAsync(categoryId, productFormModel)).ReturnsAsync(new ProductModel()
            {
                Id = 1,
                Name = "Tortas",
                Description = "Tortas de todos los sabores",
                ImageUrl = "https://www.paulinacocina.net/wp-content/uploads/2022/04/selva-negra-receta-1.jpg",
                Rating = 5,
            });
            var productController = new ProductsController(productServiceMock.Object, fileServiceMock.Object);
            var response = await productController.DeleteProductAsync(categoryId,productId);
            var result = response.Result as OkObjectResult;

            // Assert
            Assert.Equal(200, result.StatusCode);
        }
    }
}
