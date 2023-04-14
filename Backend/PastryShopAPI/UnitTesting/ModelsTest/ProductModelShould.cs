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
        public void ValidateProductForm_SetId()
        {
            //Arrange
            var product = new ProductFormModel
            {
                Id = 1,
            };

            //Act
            var getValue = product.Id;

            //Assert
            Assert.Equal(1, getValue);
        }

        [Fact]
        public void ValidateDescription()
        {
            //Arrange
            ProductFormModel product = new ProductFormModel();
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
            var product = new ProductFormModel
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
            var product = new ProductFormModel
            {
                Rating = 7,
            };

            //Act
            var getValue = product.Rating;

            //Assert
            Assert.Equal(7, getValue);
        }

        [Fact]
        public void ValidateImageUrl()
        {
            //Arrange
            ProductModel product = new ProductFormModel();
            

            //Act
            product.ImageUrl = "https://www.paulinacocina.net/wp-content/uploads/2022/04/selva-negra-receta-1.jpg";

            //Assert
            
            
            Assert.Contains("https://www.paulinacocina.net/wp-content/uploads/2022/04/selva-negra-receta-1.jpg", product.ImageUrl);



        }
    }
}