using PastryShopAPI.Models.Security;

namespace UnitTesting.ModelsTest.AuthTest
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

        [Fact]
        public void SetRoleId_WithValidData_ReturnsValidRoleId()
        {
            // Arrange
            string roleId = "LongSecureRoleId";

            // Act
            _createUserRoleModel.RoleId = roleId;

            // Assert
            Assert.Equal(roleId, _createUserRoleModel.RoleId);
        }
    }
}
