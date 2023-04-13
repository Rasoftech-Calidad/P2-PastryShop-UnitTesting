using PastryShopAPI.Models.Security;


namespace UnitTesting.ModelsTest
{
    public class UserManagerResponseShould
    {
        UserManagerResponse _userManagerResponse;
        public UserManagerResponseShould()
        {
            _userManagerResponse = new UserManagerResponse();
        }

        [Fact]
        public void SetMessage_WithValidData_ReturnsValidMessage()
        {
            // Arrange
            string message = "Some model does not exist";

            // Act
            _userManagerResponse.Message = message;

            // Assert
            Assert.Equal(message, _userManagerResponse.Message);
        }
    }
}
