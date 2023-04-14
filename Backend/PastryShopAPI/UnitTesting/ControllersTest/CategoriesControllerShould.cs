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
    public class CategoriesControllerShould
    {
        /*
        [Fact]
        public void Add_category_ReturnSameCategory()
        {
            // Arrange
            var categoryModel = new CategoryModel()
            {
                Id = 1,
                Name = "Tortas",
                Description = "Tortas de todos los sabores",
                ImageUrl = "https://www.paulinacocina.net/wp-content/uploads/2022/04/selva-negra-receta-1.jpg",
            };

            int categoryId = 1;
            int productId = 1;
            var categoryServiceMock = new Mock<ICategoriesService>();
            var fileServiceMock = new Mock<IFileService>();

            // Act
            categoryServiceMock.Setup(r => r.GetCategoryAsync(categoryId, productId)).ReturnsAsync(categoryModel);
            var categoryController = new CategoriesController(categoryServiceMock.Object, fileServiceMock.Object);
            var response = categoryController.GetCategoryAsync(categoryId, productId);
            var result = response.Result as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task Add_categories_ReturnSameCategories()
        {
            // Arrange
            var categoryModel1 = new CategoryModel()
            {
                Id = 1,
                Name = "Tortas",
                Description = "Tortas de todos los sabores",
                ImageUrl = "https://www.paulinacocina.net/wp-content/uploads/2022/04/selva-negra-receta-1.jpg",
            };
            var categoryModel2 = new CategoryModel()
            {
                Id = 2,
                Name = "Panes",
                Description = "Panes de todos los sabores",
                ImageUrl = "https://www.paulinacocina.net/wp-content/uploads/2022/04/selva-negra-receta-1.jpg",
            };

            var enumerable = new List<CategoryModel>() { categoryModel1, categoryModel2 } as IEnumerable<CategoryModel>;
            int productId = 1;
            var categoryServiceMock = new Mock<ICategoriesService>();
            var fileServiceMock = new Mock<IFileService>();

            // Act
            categoryServiceMock.Setup(r => r.GetCategoriesAsync(productId)).ReturnsAsync(enumerable);
            var categoryController = new CategoriesController(categoryServiceMock.Object, fileServiceMock.Object);
            var response = await categoryController.GetCategoriesAsync(productId);
            var result = (OkObjectResult)response.Result;
            var categoriesList = result.Value as List<CategoryModel>;
            var countCategoriesList = categoriesList.Count();

            // Assert
            Assert.Equal(2, countCategoriesList);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task CreateCategory_AddCategory_ReturnSameCategory()
        {
            //Arrange
            var categoryFormModel = new CategoryFormModel()
            {
                Id = 1,
                Name = "Tortas",
                Description = "Tortas de todos los sabores",
                ImageUrl = "https://www.paulinacocina.net/wp-content/uploads/2022/04/selva-negra-receta-1.jpg",
            };

            int productId = 1;
            var categoryServiceMock = new Mock<ICategoriesService>();
            var fileServiceMock = new Mock<IFileService>();

            // Act
            categoryServiceMock.Setup(r => r.CreateCategoryAsync(productId, categoryFormModel)).ReturnsAsync(new CategoryModel()
            {
                Id = 1,
                Name = "Tortas",
                Description = "Tortas de todos los sabores",
                ImageUrl = "https://www.paulinacocina.net/wp-content/uploads/2022/04/selva-negra-receta-1.jpg",
            });
            var categoryController = new CategoriesController(categoryServiceMock.Object, fileServiceMock.Object);
            var response = await categoryController.CreateCategoryFormAsync(productId, categoryFormModel);
            var result = response.Result as CreatedResult;
            var categoryCreated = result.Value as CategoryModel;

            // Assert
            Assert.Equal(1, categoryCreated.Id);
            Assert.Equal("Tortas", categoryCreated.Name);
            Assert.Equal(201, result.StatusCode);
        }
        */
    }
}
