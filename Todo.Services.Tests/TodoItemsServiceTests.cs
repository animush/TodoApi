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
        private TodoItemsService TodoItemsService;
        private Mock<ITodoItemsRepository> _todoItemsRepoMock;
        private Mock<IModelValidations> _modelValidationMock;
        private Mock<IUserRepository> _userRepositoryMock;
        private Mock<UserContext> _userContextMock;
        [TestInitialize]
        public void ClassInit()
        {
            _todoItemsRepoMock = new Mock<ITodoItemsRepository>();
            _modelValidationMock = new Mock<IModelValidations>();
            _userRepositoryMock = new Mock<IUserRepository>();
            _userContextMock = new Mock<UserContext>();

            TodoItemsService = new TodoItemsService(_todoItemsRepoMock.Object, _modelValidationMock.Object, _userRepositoryMock.Object, _userContextMock.Object);
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
        public async Task WhenValidateReturnTrue()
        {
            // Arrange
            TodoItem model = new TodoItem();
            _modelValidationMock.Setup(x => x.Validate(model)).ReturnsAsync(true); 

            // Act
            var result = TodoItemsService.Create(model);
            // Assert
            _todoItemsRepoMock.Verify(x => x.Create(model), Times.Once());
        }

        [TestMethod]
        public async Task WhenValidateReturnFalse()
        {
            // Arrange
            TodoItem model = new TodoItem();
            _modelValidationMock.Setup(x => x.Validate(model)).ReturnsAsync(false);

            // Act
            // Assert
            await Assert.ThrowsExceptionAsync <Exception>(() => TodoItemsService.Create(model));
        }
    }
}