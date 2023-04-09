using PastryShopAPI.Models.Security;

namespace UnitTesting.ModelsTest
{
    public class RegisterViewModelShould
    {
        [Theory]
        [InlineData("valid@valid.com", "validpassword", "validpassword")]
        public void CreatingRegisterModel_WithValidData_ReturnsValidObject(string email, string password, string confirmpassword)
        {
            // Arrange
            // Act
            var registerUser = new RegisterViewModel()
            {
                Email = email,
                Password = password,
                ConfirmPassword = confirmpassword,
            };
            // Assert
            Assert.Equal(registerUser.Email, email);
            Assert.Equal(registerUser.Password, password);
            Assert.Equal(registerUser.ConfirmPassword, confirmpassword);
        }
    }
}
