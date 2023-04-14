using PastryShopAPI.Models;
using PastryShopAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PastryShopAPI.Data.Entities;
using PastryShopAPI;

namespace UnitTesting.DataTest.EntitiesTest
{
    public class ProductEntityShould
    {
        [Fact]
        public void ValidateProductSetId()
        {
            //Arrange
            var product = new ProductEntity
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
            ProductEntity product = new ProductEntity();
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
            ProductEntity product = new ProductEntity();
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
            var product = new ProductEntity
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
            var product = new ProductEntity
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
            ProductEntity product = new ProductEntity();
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
        public void ValidateImageUrl()
        {
            //Arrange
            ProductEntity product = new ProductEntity();

            //Act
            product.ImageUrl = "https://www.paulinacocina.net/wp-content/uploads/2022/04/selva-negra-receta-1.jpg";

         
            //Assert
            Assert.Equal("https://www.paulinacocina.net/wp-content/uploads/2022/04/selva-negra-receta-1.jpg", product.ImageUrl);
        }
    }
}
