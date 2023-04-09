using PastryShopAPI.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.ModelsTest
{
    public class LoginViewModelShould
    {
        [Theory]
        [InlineData("valid@valid.com", "validpassword")]
        public void CreateModel_WithValidData_ReturnValidObject(string email, string password)
        {
            // Arrange
            // Act
            var login = new LoginViewModel()
            {
                Email = email,
                Password = password,
            };
            // Assert
            Assert.Equal(login.Email, email);
            Assert.Equal(login.Password, password);
        }
    }
}
