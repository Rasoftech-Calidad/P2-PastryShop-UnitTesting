using PastryShopAPI;
using PastryShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.ModelsTest
{
    public class CategoryModelShould
    {
        [Fact]
        public void ValidateCategorySetId()
        {
            //Arrange
            var category = new CategoryModel
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
            CategoryModel category = new CategoryModel();
            string name = "Chocolatados";
            category.Name = name;

            //Act
            var getValue = category.Name;

            //Assert
            Assert.Equal(category.Name, name);
            //Assert.Contains(getValue, category.Name);
        }

        [Fact]
        public void ValidateDescription()
        {
            //Arrange
            CategoryModel category = new CategoryModel();
            category.Description = "Pasteles finos en corteza doble";

            //Act
            var getValue = category.Description;

            //Assert
            //Assert.IsType<string>(getValue);
            Assert.Contains("Pasteles finos en corteza doble", getValue);
        }

        [Fact]
        public void ValidateImageUrl()
        {
            //Arrange
            CategoryModel category = new CategoryModel();
            category.ImageUrl = "https://st4.depositphotos.com/21419180/23161/i/600/depositphotos_231611588-stock-photo-apple-pie-double-crust-apple.jpg";

            //Act
            var listExtencionImage = new List<string>() { ".jpg" };

            //Assert
            Assert.Contains(".jpg", category.ImageUrl);
            /*foreach (string extencion in listExtencionImage)
            {
                Assert.Contains(extencion, category.ImageUrl);
            }*/
            //Assert.IsType<string>(category.ImageUrl);
        }
    }
}