using PastryShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.ModelsTest
{
    public class CategoryFormModelShould
    {
        [Fact]
        public void ValidateCategoryForm_SetId()
        {
            //Arrange
            var category = new CategoryFormModel
            {
                Id = 1,
            };

            //Act
            var getValue = category.Id;

            //Assert
            Assert.Equal(1, getValue);
        }

        [Fact]
        public void ValidateDescription()
        {
            //Arrange
            CategoryFormModel category = new CategoryFormModel();
            category.Description = "Sabores a eleccion con almendras de coco";

            //Act
            var getValue = category.Description;

            //Assert
            Assert.IsType<string>(getValue);
        }

        [Fact]
        public void ValidateImageUrl()
        {
            //Arrange
            CategoryModel category = new CategoryFormModel();

            //Act
            category.ImageUrl = "https://www.paulinacocina.net/wp-content/uploads/2022/04/selva-negra-receta-1.jpg";

            //Assert

            Assert.Contains("https://www.paulinacocina.net/wp-content/uploads/2022/04/selva-negra-receta-1.jpg", category.ImageUrl);
        }
    }
}
