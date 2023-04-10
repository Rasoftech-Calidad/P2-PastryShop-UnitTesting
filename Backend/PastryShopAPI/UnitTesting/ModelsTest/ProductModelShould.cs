using PastryShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.ModelsTests
{
    public class ProductModelShould
    {
        [Fact]
        public void ValidateProductSetId()
        {
            //Arrange
            var product = new ProductModel
            {
                Id = 1,
            };

            //Act
            var getValue = product.Id;

            //Assert
            Assert.Equal(1, getValue);
        }

        [Fact]
        public void ValidateProductSetName()
        {
            //Arrange
            ProductModel product = new ProductModel();
            string name = "Pastel";
            product.Name = name;

            //Act
            var getValue = product.Name;

            //Assert
            //Assert.Equal(product.Name, name);
            Assert.Contains(getValue, product.Name);
        }

        [Fact]
        public void ValidateDescription()
        {
            //Arrange
            ProductModel product = new ProductModel();
            product.Description = "Sabores a eleccion con almendras de coco";

            //Act
            var getValue = product.Description;

            //Assert
            Assert.IsType<string>(getValue);
            //Assert.Contains("Sabores a eleccion con almendras de coco", getValue);
        }

        [Fact]
        public void ValidatePrice()
        {
            //Arrange
            var product = new ProductModel
            {
                Price = 5000,
            };

            //Act
            var getValue = product.Price;

            //Assert
            Assert.Equal(5000, getValue);
        }

        [Fact]
        public void ValidateRaiting()
        {
            //Arrange
            var product = new ProductModel
            {
                Rating = 7,
            };

            //Act
            var getValue = product.Rating;

            //Assert
            Assert.Equal(7, getValue);
        }

        [Fact]
        public void ValidateImagePath()
        {
            //Arrange
            ProductModel product = new ProductModel();
            product.ImagePath = "E:\\UCB - INGENIERIA EN SISTEMAS\\Semestre 1 - 2023\\Gestion de Calidad de Sistemas\\P2-PastryShop-UnitTesting\\Backend\\PastryShopAPI\\PastryShopAPI\\Resources\\Images\\0b43ff83-fdd9-49f7-8b19-9b4ed406925f.png";

            //Act
            var listExtencionImage = new List<string>() { ".png" };

            //Assert
            //Assert.Contains(".png", product.ImagePath);
            foreach (string extencion in listExtencionImage)
            {
                Assert.Contains(extencion, product.ImagePath);
            }
            //Assert.IsType<string>(product.ImagePath);
        }

        [Fact]
        public void ValidateCategoryId()
        {
            //Arrange
            ProductModel product = new ProductModel();
            CategoryModel category = new CategoryModel();
            category.Id = 1;

            //Act
            product.CategoryId = (long)category.Id;

            //Assert
            Assert.Equal(category.Id, product.CategoryId);
        }
    }
}