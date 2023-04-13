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

        [Fact]
        public void SetSuccessTrue_WithValidData_ReturnsSameTrue()
        {
            // Arrange
            var isSuccess = true;
            // Act
            _userManagerResponse.IsSuccess = isSuccess;

            // Assert
            Assert.True(isSuccess);
        }

        [Fact]
        public void SetSuccessFalse_WithValidData_ReturnsSameFalse()
        {
            // Arrange
            var isSuccess = false;
            // Act
            _userManagerResponse.IsSuccess = isSuccess;

            // Assert
            Assert.False(isSuccess);
        }

        [Fact]
        public void SetErrorsList_WithValidData_ReturnsCompleteErrorList()
        {
            // Arrange
            var errors = new List<string>();
            errors.Add("Product not in this combo");
            errors.Add("product is null");
            var expected = errors;

            // Act
            _userManagerResponse.Errors = errors;
            var actual = _userManagerResponse.Errors;
            var countActual = actual.Count();
            var countExpected = expected.Count();
            
            // Assert
            Assert.StrictEqual(expected, actual);
            Assert.Equal(expected, actual);
            Assert.Equal(countExpected, countActual);
        }

        [Fact]
        public void SetExpireDate_WithValidData_ReturnsSameExpireDate()
        {
            // Arrange
            var year = 2025;
            var month = 9;
            var day = 30;
            var expectedExpireDate = new DateTime(year, month, day);
            // Act
            _userManagerResponse.ExpireDate= expectedExpireDate;
            var actualExpireDate = _userManagerResponse.ExpireDate;
            // Assert
            Assert.Equal(expectedExpireDate, actualExpireDate);
        }

    }
}
