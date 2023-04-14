using Microsoft.AspNetCore.Mvc;
using Moq;
using PastryShopAPI.Controllers;
using PastryShopAPI.Models.Security;
using PastryShopAPI.Services.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.ControllersTest
{
    public class AuthControllerShould
    {
        private readonly Mock<IUserService> _userService;
        private AuthController _authController;
        public AuthControllerShould()
        {
            _userService = new Mock<IUserService>();
        }

        // REGISTER USER
        [Fact]
        public async Task RegisterAsync_WithValidData_ReturnsSuccessfullUserResponse()
        {
            // Arrange
            var userResponse = new UserManagerResponse() 
            {
                Message = "User created succesfully!",
                IsSuccess = true,
            };
            var newUser = new RegisterViewModel() 
            { 
                Email = "goodemail@gmail.com",
                Password = "goodpassword000",
                ConfirmPassword = "goodpassword000"
            };
            _userService.Setup(r => r.RegisterUserAsync(newUser)).ReturnsAsync(userResponse);
            _authController = new AuthController(_userService.Object);

            // Act
            var registerResponse = await _authController.RegisterAsync(newUser);
            var actualResponse = registerResponse as OkObjectResult;
            var actualStatusCode = actualResponse?.StatusCode;
            var actualValue = actualResponse?.Value as UserManagerResponse;
            var expectedStatusCode = 200;

            // Assert
            Assert.Equal(expectedStatusCode, actualStatusCode);
            Assert.Equal(userResponse.Message, actualValue?.Message);
            Assert.True(actualValue?.IsSuccess);
        }


    }
}
