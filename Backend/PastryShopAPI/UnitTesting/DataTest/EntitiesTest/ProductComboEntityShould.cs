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
        public void ValidateProductComboEntity_SetId()
        {
            //Arrange
            var productCombo = new Product_ComboEntity
            {
                Id = 1,
            };

            //Act
            var getValue = productCombo.Id;

            //Assert
            Assert.Equal(1, getValue);
        }
        [Fact]
        public void ValidateProductComboEntity_SetProductId()
        {
            //Arrange
            var productCombo = new Product_ComboEntity
            {
                ProductId = 1,
            };

            //Act
            var getValue = productCombo.ProductId;

            //Assert
            Assert.Equal(1, getValue);
        }
        [Fact]
        public void ValidateProductComboEntity_SetComboId()
        {
            //Arrange
            var productCombo = new Product_ComboEntity
            {
                ComboId = 1,
            };

            //Act
            var getValue = productCombo.ComboId;

            //Assert
            Assert.Equal(1, getValue);
        }
        [Fact]
        public void ValidateProductComboEntity_SetProduct()
        {
            //Arrange
            var product = new ProductEntity
            {
                Id = 1
            };
            var productCombo = new Product_ComboEntity
            {
                Product=product
            };

            //Assert
            Assert.Equal(product, productCombo.Product);
        }
        [Fact]
        public void ValidateProductComboEntity_SetCombo()
        {
            //Arrange
            var combo = new ComboEntity
            {
                Id = 1
            };
            var productCombo = new Product_ComboEntity
            {
                Combo = combo
            };

            //Assert
            Assert.Equal(combo, productCombo.Combo);
        }
    }
}
