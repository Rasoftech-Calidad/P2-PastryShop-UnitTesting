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

        [Fact]
        public async Task RegisterAsync_WithUnMatchingPasswords_ReturnsUnSuccessfullUserResponse()
        {
            // Arrange
            var userResponse = new UserManagerResponse()
            {
                Message = "Confirm password doesn't match the password",
                IsSuccess = false,
            };
            var newUser = new RegisterViewModel()
            {
                Email = "goodemail@gmail.com",
                Password = "goodpassword",
                ConfirmPassword = "unmatchingpassword",
            };
            _userService.Setup(r => r.RegisterUserAsync(newUser)).ReturnsAsync(userResponse);
            _authController = new AuthController(_userService.Object);

            // Act
            var registerResponse = await _authController.RegisterAsync(newUser);
            var actualResponse = registerResponse as BadRequestObjectResult;
            var actualStatusCode = actualResponse?.StatusCode;
            var actualValue = actualResponse?.Value as UserManagerResponse;
            var expectedStatusCode = 400;

            // Assert
            Assert.Equal(expectedStatusCode, actualStatusCode);
            Assert.Equal(userResponse.Message, actualValue?.Message);
            Assert.False(actualValue?.IsSuccess);
        }

        [Fact]
        public async Task RegisterAsync_InvalidUserData_ReturnsUnSuccessfullUserResponse()
        {
            // Arrange
            var userResponse = "Some properties are not valid";
            var expectedStatusCode = 400;
            var newUser = new RegisterViewModel()
            {
                Email = "bademail",
                Password = "bad",
                ConfirmPassword = "bad",
            };
            _authController = new AuthController(_userService.Object);

            // Act
            _authController.ModelState.AddModelError("IsInvalid", "error");
            var registerResponse = await _authController.RegisterAsync(newUser);
            var actualResponse = registerResponse as BadRequestObjectResult;
            var actualStatusCode = actualResponse?.StatusCode;
            var actualValue = actualResponse?.Value;

            // Assert
            Assert.Equal(expectedStatusCode, actualStatusCode);
            Assert.Equal(userResponse, actualValue);
        }


        // CREATE ROLE
        [Fact]
        public async Task CreateRoleAsync_WithValidData_ReturnsSuccessfullUserResponse()
        {
            // Arrange
            var userResponse = new UserManagerResponse()
            {
                Message = "Role created succesfully!",
                IsSuccess = true,
            };
            var newRole = new CreateRoleViewModel()
            {
                Name = "Admin",
                NormalizedName = "ADMIN",
            };
            var expectedStatusCode = 200;
            _userService.Setup(r => r.CreateRoleAsync(newRole)).ReturnsAsync(userResponse);
            _authController = new AuthController(_userService.Object);

            // Act
            var createRoleResponse = await _authController.CreateRolenAsync(newRole);
            var actualResponse = createRoleResponse as OkObjectResult;
            var actualStatusCode = actualResponse?.StatusCode;
            var actualValue = actualResponse?.Value as UserManagerResponse;

            // Assert
            Assert.Equal(expectedStatusCode, actualStatusCode);
            Assert.Equal(userResponse.Message, actualValue?.Message);
            Assert.True(actualValue?.IsSuccess);
        }

        [Fact]
        public async Task CreateRoleAsync_WithUnmatchinNames_ReturnsUnSuccessfullUserResponse()
        {
            // Arrange
            var userResponse = new UserManagerResponse()
            {
                Message = "Role did not create",
                IsSuccess = false,
            };
            var newRole = new CreateRoleViewModel()
            {
                Name = "Admin",
                NormalizedName = "NOT ADMIN",
            };
            var expectedStatusCode = 400;
            _userService.Setup(r => r.CreateRoleAsync(newRole)).ReturnsAsync(userResponse);
            _authController = new AuthController(_userService.Object);

            // Act
            var createRoleResponse = await _authController.CreateRolenAsync(newRole);
            var actualResponse = createRoleResponse as BadRequestObjectResult;
            var actualStatusCode = actualResponse?.StatusCode;
            var actualValue = actualResponse?.Value as UserManagerResponse;

            // Assert
            Assert.Equal(expectedStatusCode, actualStatusCode);
            Assert.Equal(userResponse.Message, actualValue?.Message);
            Assert.False(actualValue?.IsSuccess);
        }

        [Fact]
        public async Task CreateRoleAsync_InvalidRoleData_ReturnsBadRequestErrorMessage()
        {
            // Arrange
            var userResponse = "Some properties are not valid";
            var expectedStatusCode = 400;
            var newRole = new CreateRoleViewModel();
            _authController = new AuthController(_userService.Object);

            // Act
            _authController.ModelState.AddModelError("Empty Properties", "error");
            var registerResponse = await _authController.CreateRolenAsync(newRole);
            var actualResponse = registerResponse as BadRequestObjectResult;
            var actualStatusCode = actualResponse?.StatusCode;
            var actualValue = actualResponse?.Value;

            // Assert
            Assert.Equal(expectedStatusCode, actualStatusCode);
            Assert.Equal(userResponse, actualValue);
        }


        // CREATE USER-ROLE
        [Fact]
        public async Task CreateUserRoleAsync_WithValidData_ReturnsSuccessfullUserResponse()
        {
            // Arrange
            var userResponse = new UserManagerResponse()
            {
                Message = "Role assigned",
                IsSuccess = true,
            };
            var newUserRole = new CreateUserRoleViewModel()
            {
                UserId = "secure-user-id",
                RoleId = "secure-role-id",
            };
            var expectedStatusCode = 200;
            _userService.Setup(r => r.CreateUserRoleAsync(newUserRole)).ReturnsAsync(userResponse);
            _authController = new AuthController(_userService.Object);

            // Act
            var createRoleResponse = await _authController.CreateUserRolenAsync(newUserRole);
            var actualResponse = createRoleResponse as OkObjectResult;
            var actualStatusCode = actualResponse?.StatusCode;
            var actualValue = actualResponse?.Value as UserManagerResponse;

            // Assert
            Assert.Equal(expectedStatusCode, actualStatusCode);
            Assert.Equal(userResponse.Message, actualValue?.Message);
            Assert.True(actualValue?.IsSuccess);
        }
        
        [Theory]
        [InlineData("user has role already", false, "secure-user-id", "duplicated-role-id")]
        [InlineData("user doesn't exist", false, "unknown-user-id", "good-role-id")]
        [InlineData("role doesn't exist", false, "secure-user-id", "unknown-role-id")]
        public async Task CreateUserRoleAsync_WithIncorrectIds_ReturnsUnSuccessfullUserResponse(string message, bool isSuccess, string userId, string roleId)
        {
            // Arrange
            var userResponse = new UserManagerResponse()
            {
                Message = message,
                IsSuccess = isSuccess,
            };
            var newUserRole = new CreateUserRoleViewModel()
            {
                UserId = userId,
                RoleId = roleId,
            };
            var expectedStatusCode = 400;
            _userService.Setup(r => r.CreateUserRoleAsync(newUserRole)).ReturnsAsync(userResponse);
            _authController = new AuthController(_userService.Object);

            // Act
            var createRoleResponse = await _authController.CreateUserRolenAsync(newUserRole);
            var actualResponse = createRoleResponse as BadRequestObjectResult;
            var actualStatusCode = actualResponse?.StatusCode;
            var actualValue = actualResponse?.Value as UserManagerResponse;

            // Assert
            Assert.Equal(expectedStatusCode, actualStatusCode);
            Assert.Equal(userResponse.Message, actualValue?.Message);
            Assert.False(actualValue?.IsSuccess);
        }
        
        [Fact]
        public async Task CreateUserRoleAsync_InvalidUserRoleData_ReturnsBadRequestErrorMessage()
        {
            // Arrange
            var userResponse = "Some properties are not valid";
            var expectedStatusCode = 400;
            var newUserRole = new CreateUserRoleViewModel();
            _authController = new AuthController(_userService.Object);

            // Act
            _authController.ModelState.AddModelError("Empty Properties", "error");
            var registerResponse = await _authController.CreateUserRolenAsync(newUserRole);
            var actualResponse = registerResponse as BadRequestObjectResult;
            var actualStatusCode = actualResponse?.StatusCode;
            var actualValue = actualResponse?.Value;

            // Assert
            Assert.Equal(expectedStatusCode, actualStatusCode);
            Assert.Equal(userResponse, actualValue);
        }



    }
}
