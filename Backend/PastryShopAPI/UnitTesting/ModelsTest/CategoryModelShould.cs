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
    }
}
