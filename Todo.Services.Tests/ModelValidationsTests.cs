using ToDo.Services;
using TodoApi.Models;

namespace Todo.Services.Tests
{
    [TestClass]
    public class ModelValidationsTests
    {
        private ModelValidations ModelValidations { get; set; }

        [TestMethod]
        public async Task ValidateSuccess()
        {
            // Arrange
            ModelValidations = new ModelValidations();

            TodoItem model = new TodoItem { Name = "Test" };

            // Act
            var result = await ModelValidations.Validate(model);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task Validate_NameIsNull()
        {
            // Arrange
            ModelValidations = new ModelValidations();

            TodoItem model = new TodoItem { Name = null };

            // Act
            var result = await ModelValidations.Validate(model);

            // Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public async Task Validate_NameIsEmpty()
        {
            // Arrange
            ModelValidations = new ModelValidations();

            TodoItem model = new TodoItem { Name = String.Empty };

            // Act
            var result = await ModelValidations.Validate(model);

            // Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public async Task Validate_NameIsWhitespace()
        {
            // Arrange
            ModelValidations = new ModelValidations();

            TodoItem model = new TodoItem { Name = "  " };

            // Act
            var result = await ModelValidations.Validate(model);

            // Assert
            Assert.IsFalse(result);
        }
    }
}