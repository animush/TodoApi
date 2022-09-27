using ToDo.Services;
using TodoApi.Models;
using TodoApi.Services;

namespace Todo.Services.Tests
{
    [TestClass]
    public class ModelValidationsTests
    {
        private ModelValidations ModelValidations { get; set; }

        [TestMethod]
        public void ValidateSuccess()
        {
            // Arrange
            ModelValidations = new ModelValidations();

            TodoItem model = new TodoItem { Name = "Test" };

            // Act
            var result = ModelValidations.Validate(model);
            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Validate_NameIsNull()
        {
            // Arrange
            ModelValidations = new ModelValidations();

            TodoItem model = new TodoItem { Name = null };

            // Act
            var result = ModelValidations.Validate(model);
            // Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void Validate_NameIsEmpty()
        {
            // Arrange
            ModelValidations = new ModelValidations();

            TodoItem model = new TodoItem { Name = String.Empty };

            // Act
            var result = ModelValidations.Validate(model);
            // Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void Validate_NameIsWhitespace()
        {
            // Arrange
            ModelValidations = new ModelValidations();

            TodoItem model = new TodoItem { Name = "  " };

            // Act
            var result = ModelValidations.Validate(model);
            // Assert
            Assert.IsFalse(result);
        }
    }
}