using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ToDo.Repositories.Abstract;
using ToDo.Services;
using TodoApi.Models;
using TodoApi.Services;

namespace Todo.Services.Tests
{
    [TestClass]
    public class TodoItemsServiceTests
    {
        private TodoItemsService TodoItemsService { get; set; }
        private Mock<ITodoItemsRepository> _todoItemsRepoMock;
        private Mock<IModelValidations> _modelValidationMock;

        [TestInitialize]
        public void ClassInit()
        {
            _todoItemsRepoMock = new Mock<ITodoItemsRepository>();
            _modelValidationMock = new Mock<IModelValidations>();
            TodoItemsService = new TodoItemsService(_todoItemsRepoMock.Object, _modelValidationMock.Object);
        }

        [TestMethod]
        public async Task GetShouldReturnItemFromRepo()
        {
            // Arrange
            var itemId = 5;
            

            var todoItem = new TodoItem
            {
                Id = 7,
                Name = "Test",
                IsComplete = true,
            };
            _todoItemsRepoMock.Setup(x => x.Get(itemId)).ReturnsAsync(todoItem);

            // Act
            var item = await TodoItemsService.Get(itemId);
            // Assert
            Assert.AreEqual(todoItem.Id, item.Id);
            Assert.AreEqual(todoItem.Name, item.Name);
            Assert.AreEqual(todoItem.IsComplete, item.IsComplete);

        }

        [TestMethod]
        public async Task GetShouldCallRepoMethod()
        {
            // Arrange
            var itemId = 5;

            _todoItemsRepoMock.Setup(x => x.Get(itemId)).ReturnsAsync(new TodoItem());

            // Act
            var item = await TodoItemsService.Get(itemId);
            // Assert
            _todoItemsRepoMock.Verify(x => x.Get(itemId), Times.Once());
        }

        [TestMethod]
        public void WhenValidateReturnTrue()
        {
            // Arrange
            TodoItem model = new TodoItem();
            _modelValidationMock.Setup(x => x.Validate(model)).Returns(true); 

            // Act
            var result = TodoItemsService.Create(model);
            // Assert
            _todoItemsRepoMock.Verify(x => x.Create(model), Times.Once());
        }

        [TestMethod]
        public void WhenValidateReturnFalse()
        {
            // Arrange
            TodoItem model = new TodoItem();
            _modelValidationMock.Setup(x => x.Validate(model)).Returns(false);

            // Act
            
            // Assert
            Assert.ThrowsException<Exception>(() => TodoItemsService.Create(model));
            
        }
    }
}