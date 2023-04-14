using Microsoft.AspNetCore.Mvc;
using Moq;
using PastryShopAPI.Controllers;
using PastryShopAPI.Models;
using PastryShopAPI.Services;
using PastryShopAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PastryShopAPI.Data.Entities;
using AutoMapper;
using PastryShopAPI;
using PastryShopAPI.Data.Repositories;

namespace UnitTesting.ServicesTest
{
    public class ProductsServiceShould
    {
        [Fact]
        public async Task CreateProduct_AddProduct_ReturnSameProduct()
        {
            //Arrange
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AtomapperProfile>());
            var mapper = config.CreateMapper();
            var product = new ProductEntity()
            {
                Id = 1,
                Name = "Tortas",
                Description = "Tortas de todos los sabores",
                ImageUrl = "https://www.paulinacocina.net/wp-content/uploads/2022/04/selva-negra-receta-1.jpg",
                Rating = 5,
            };
            var category = new CategoryEntity
            {
                Id = 1,
                Name="Pasteles",
                Description= "Pasteles de todos los sabores",
                ImageUrl = "https://www.paulinacocina.net/wp-content/uploads/2022/04/selva-negra-receta-1.jpg",
            };

            int categoryId = 1;
            var categoryModel = mapper.Map<CategoryModel>(category);
            var productModel = mapper.Map<ProductModel>(product);
            var pastryShopRepository = new Mock<IPastryShopRepository>();
            // Act
            pastryShopRepository.Setup(r => r.GetCategoryAsync(categoryId)).ReturnsAsync(category);

            pastryShopRepository.Setup(r => r.CreateCategory(category));
            pastryShopRepository.Setup(r => r.CreateProduct(categoryId, product));
            pastryShopRepository.Setup(r => r.SaveChangesAsync()).ReturnsAsync(true);
            var productService = new ProductsService(pastryShopRepository.Object, mapper);
            var categoryService = new CategoriesService(pastryShopRepository.Object, mapper);
            var categoryAdded = await categoryService.CreateCategoryAsync(categoryModel);
            var ProductAdded = await productService.CreateProductAsync(categoryId, productModel);
            

            // Assert
            Assert.Equal(1, ProductAdded.Id);
            Assert.Equal("Tortas", ProductAdded.Name);
            
        }
    }
}
