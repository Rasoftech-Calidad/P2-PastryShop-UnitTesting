﻿using PastryShopAPI.Models.Security;

namespace UnitTesting.ModelsTest
{
    public class CreateUserRoleViewModelShould
    {
        CreateUserRoleViewModel _createUserRoleModel;
        public CreateUserRoleViewModelShould()
        {
            _createUserRoleModel = new CreateUserRoleViewModel();
        }

        [Fact]
        public void SetUserId_WithValidData_ReturnsValidUserId()
        {
            // Arrange
            string userId = "LongSecureUserId";

            // Act
            _createUserRoleModel.UserId = userId;

            // Assert
            Assert.Equal(userId, _createUserRoleModel.UserId);
        }

        
    }
}
