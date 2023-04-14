using PastryShopAPI.Models;
using PastryShopAPI.Models.Combos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.ModelsTest.ComboTest
{
    public class ProductComboModelShould
    {
        [Fact]
        public void ValidateProductSetId()
        {
            //Arrange
            var product = new Product_ComboModel
            {
                ProductId = 1,
            };

            //Act
            var getValue = product.ProductId;

            //Assert
            Assert.Equal(1, getValue);
        }

        [Fact]
        public void ValidateComboSetId()
        {
            //Arrange
            var product = new Product_ComboModel
            {
                ComboId = 1,
            };

            //Act
            var getValue = product.ComboId;

            //Assert
            Assert.Equal(1, getValue);
        }
    }
}