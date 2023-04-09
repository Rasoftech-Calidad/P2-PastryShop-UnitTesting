using PastryShopAPI;
using PastryShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.DataTest.EntitiesTest
{
    public class CategoryEntityShould
    {
        [Fact]
        public void ValidateCategorySetId()
        {
            //Arrange
            var category = new CategoryEntity
            {
                Id = 1,
            };

            //Act
            var getValue = category.Id;

            //Assert
            Assert.Equal(1, getValue);
        }

        [Fact]
        public void ValidateCategorySetName()
        {
            //Arrange
            CategoryEntity category = new CategoryEntity();
            string name = "Pastel";
            category.Name = name;

            //Act
            var getValue = category.Name;

            //Assert
            //Assert.Equal(product.Name, name);
            Assert.Contains(getValue, category.Name);
        }

        [Fact]
        public void ValidateDescription()
        {
            //Arrange
            CategoryEntity category = new CategoryEntity();
            category.Description = "Sabores a eleccion con almendras de coco";

            //Act
            var getValue = category.Description;

            //Assert
            Assert.IsType<string>(getValue);
            //Assert.Contains("Sabores a eleccion con almendras de coco", getValue);
        }

        [Fact]
        public void ValidateImagePath()
        {
            //Arrange
            CategoryEntity category = new CategoryEntity();
            category.ImagePath = "E:\\UCB - INGENIERIA EN SISTEMAS\\Semestre 1 - 2023\\Gestion de Calidad de Sistemas\\P2-PastryShop-UnitTesting\\Backend\\PastryShopAPI\\PastryShopAPI\\Resources\\Images\\0b43ff83-fdd9-49f7-8b19-9b4ed406925f.png";

            //Act
            var listExtencionImage = new List<string>() { ".png" };

            //Assert
            //Assert.Contains(".png", product.ImagePath);
            foreach (string extencion in listExtencionImage)
            {
                Assert.Contains(extencion, category.ImagePath);
            }
            //Assert.IsType<string>(product.ImagePath);
        }
    }
}
