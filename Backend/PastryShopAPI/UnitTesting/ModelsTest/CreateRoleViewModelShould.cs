using PastryShopAPI.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.ModelsTest
{
    public class CreateRoleViewModelShould
    {
        CreateRoleViewModel _createRoleModel;
        public CreateRoleViewModelShould()
        {
            _createRoleModel = new CreateRoleViewModel();
        }

        [Fact]
        public void SetName_WithValidData_ReturnsValidName()
        {
            // Arrange
            string name = "Name";

            // Act
            _createRoleModel.Name = name;

            // Assert
            Assert.Equal(name, _createRoleModel.Name);
        }
        
    }
}
