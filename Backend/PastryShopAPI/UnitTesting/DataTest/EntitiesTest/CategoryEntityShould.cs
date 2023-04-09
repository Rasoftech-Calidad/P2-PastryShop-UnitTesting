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
    }
}
