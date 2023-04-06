using AutoMapper;
using PastryShopAPI;
using PastryShopAPI.Models;

namespace TestProject_PastryShop
{
    public class UnitTest1
    {
        readonly IMapper _mapper;

        [Fact]
        public void Test1()
        {
            //Arrange
            var categoryModel = new CategoryModel();//1,"cake","delicious cake", "urlfakeblabla", "dadasdas"
            var categoryEntity = new CategoryEntity();
            var categoryEntityType = categoryEntity.GetType().ToString();
            //Act
            var actual = _mapper.Map<CategoryEntity>(categoryModel);
            var actualType = actual.GetType().ToString();

            //Assert
            Assert.Equal(categoryEntityType, categoryEntityType);
        }
    }
}