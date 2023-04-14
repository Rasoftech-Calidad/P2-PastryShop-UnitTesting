using PastryShopAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.DataTest.EntitiesTest
{
    public class ProductComboEntityShould
    {

        [Fact]
        public void ValidateComboEntity_SetId()
        {
            //Arrange
            var product = new Product_ComboEntity
            {
                Id = 1,
            };

            //Act
            var getValue = product.Id;

            //Assert
            Assert.Equal(1, getValue);
        }
    }
}
