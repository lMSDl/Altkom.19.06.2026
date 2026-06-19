using Microsoft.AspNetCore.Mvc;
using Models;
using Moq;
using WebApp.Controllers;
using WebApp.Services;

namespace WebApp.UnitTests.Controllers;

[TestClass]
public class UsersControllerTests
{
    [TestMethod]
    public void Constructor_WithValidService_AssignsService()
    {
        // Arrange
        var mockService = new Mock<ICrudService<User>>();

        // Act
        var controller = new UsersController(mockService.Object);

        // Assert
        Assert.IsNotNull(controller);
    }

    [TestMethod]
    public void GetAll_ReturnsOkResultWithAllUsers()
    {
        // Arrange
        var users = new List<User>
        {
            new User { Id = Guid.NewGuid(), Name = "User1", Email = "user1@test.com" },
            new User { Id = Guid.NewGuid(), Name = "User2", Email = "user2@test.com" }
        };
        var mockService = new Mock<ICrudService<User>>();
        mockService.Setup(s => s.GetAll()).Returns(users);
        var controller = new UsersController(mockService.Object);

        // Act
        var result = controller.GetAll();

        // Assert
        var okResult = result.Result as OkObjectResult;
        Assert.IsNotNull(okResult);
        Assert.AreEqual(200, okResult.StatusCode);
        Assert.AreEqual(users, okResult.Value);
    }

    [TestMethod]
    public void GetAll_CallsServiceGetAll()
    {
        // Arrange
        var mockService = new Mock<ICrudService<User>>();
        mockService.Setup(s => s.GetAll()).Returns(new List<User>());
        var controller = new UsersController(mockService.Object);

        // Act
        controller.GetAll();

        // Assert
        mockService.Verify(s => s.GetAll(), Times.Once);
    }

    [TestMethod]
    public void GetById_WhenUserExists_ReturnsOkResultWithUser()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var user = new User { Id = userId, Name = "Test User", Email = "test@test.com" };
        var mockService = new Mock<ICrudService<User>>();
        mockService.Setup(s => s.GetById(userId)).Returns(user);
        var controller = new UsersController(mockService.Object);

        // Act
        var result = controller.GetById(userId);

        // Assert
        var okResult = result.Result as OkObjectResult;
        Assert.IsNotNull(okResult);
        Assert.AreEqual(200, okResult.StatusCode);
        Assert.AreEqual(user, okResult.Value);
    }

    [TestMethod]
    public void GetById_WhenUserDoesNotExist_ReturnsNotFound()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var mockService = new Mock<ICrudService<User>>();
        mockService.Setup(s => s.GetById(userId)).Returns((User?)null);
        var controller = new UsersController(mockService.Object);

        // Act
        var result = controller.GetById(userId);

        // Assert
        var notFoundResult = result.Result as NotFoundResult;
        Assert.IsNotNull(notFoundResult);
        Assert.AreEqual(404, notFoundResult.StatusCode);
    }

    [TestMethod]
    public void GetById_CallsServiceGetById()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var mockService = new Mock<ICrudService<User>>();
        mockService.Setup(s => s.GetById(userId)).Returns((User?)null);
        var controller = new UsersController(mockService.Object);

        // Act
        controller.GetById(userId);

        // Assert
        mockService.Verify(s => s.GetById(userId), Times.Once);
    }

    [TestMethod]
    public void Create_SetsCreatedAtAndReturnsCreatedAtAction()
    {
        // Arrange
        var user = new User { Name = "New User", Email = "new@test.com" };
        var createdUser = new User { Id = Guid.NewGuid(), Name = "New User", Email = "new@test.com" };
        var mockService = new Mock<ICrudService<User>>();
        mockService.Setup(s => s.Create(It.IsAny<User>())).Returns(createdUser);
        var controller = new UsersController(mockService.Object);

        // Act
        var result = controller.Create(user);

        // Assert
        var createdAtActionResult = result.Result as CreatedAtActionResult;
        Assert.IsNotNull(createdAtActionResult);
        Assert.AreEqual(nameof(UsersController.GetById), createdAtActionResult.ActionName);
        Assert.IsNotNull(createdAtActionResult.RouteValues);
        Assert.AreEqual(createdUser.Id, createdAtActionResult.RouteValues["id"]);
        Assert.AreEqual(createdUser, createdAtActionResult.Value);
    }

    [TestMethod]
    public void Create_SetsCreatedAtToUtcNow()
    {
        // Arrange
        var user = new User { Name = "New User", Email = "new@test.com", CreatedAt = DateTime.MinValue };
        var createdUser = new User { Id = Guid.NewGuid(), Name = "New User", Email = "new@test.com" };
        var mockService = new Mock<ICrudService<User>>();
        mockService.Setup(s => s.Create(It.IsAny<User>())).Returns(createdUser);
        var controller = new UsersController(mockService.Object);
        var beforeCreate = DateTime.UtcNow;

        // Act
        controller.Create(user);
        var afterCreate = DateTime.UtcNow;

        // Assert
        Assert.IsTrue(user.CreatedAt >= beforeCreate && user.CreatedAt <= afterCreate);
    }

    [TestMethod]
    public void Create_CallsServiceCreate()
    {
        // Arrange
        var user = new User { Name = "New User", Email = "new@test.com" };
        var createdUser = new User { Id = Guid.NewGuid(), Name = "New User", Email = "new@test.com" };
        var mockService = new Mock<ICrudService<User>>();
        mockService.Setup(s => s.Create(It.IsAny<User>())).Returns(createdUser);
        var controller = new UsersController(mockService.Object);

        // Act
        controller.Create(user);

        // Assert
        mockService.Verify(s => s.Create(user), Times.Once);
    }

    [TestMethod]
    public void Update_WhenUserDoesNotExist_ReturnsNotFound()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var user = new User { Id = userId, Name = "Updated User", Email = "updated@test.com" };
        var mockService = new Mock<ICrudService<User>>();
        mockService.Setup(s => s.GetById(userId)).Returns((User?)null);
        var controller = new UsersController(mockService.Object);

        // Act
        var result = controller.Update(userId, user);

        // Assert
        var notFoundResult = result as NotFoundResult;
        Assert.IsNotNull(notFoundResult);
        Assert.AreEqual(404, notFoundResult.StatusCode);
    }

    [TestMethod]
    public void Update_WhenUserDoesNotExist_DoesNotCallServiceUpdate()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var user = new User { Id = userId, Name = "Updated User", Email = "updated@test.com" };
        var mockService = new Mock<ICrudService<User>>();
        mockService.Setup(s => s.GetById(userId)).Returns((User?)null);
        var controller = new UsersController(mockService.Object);

        // Act
        controller.Update(userId, user);

        // Assert
        mockService.Verify(s => s.Update(It.IsAny<Guid>(), It.IsAny<User>()), Times.Never);
    }

    [TestMethod]
    public void Update_WhenUserExistsAndUpdateSucceeds_ReturnsNoContent()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var existingUser = new User { Id = userId, Name = "Existing User", Email = "existing@test.com", CreatedAt = DateTime.UtcNow.AddDays(-5) };
        var updatedUser = new User { Id = userId, Name = "Updated User", Email = "updated@test.com" };
        var mockService = new Mock<ICrudService<User>>();
        mockService.Setup(s => s.GetById(userId)).Returns(existingUser);
        mockService.Setup(s => s.Update(userId, updatedUser)).Returns(true);
        var controller = new UsersController(mockService.Object);

        // Act
        var result = controller.Update(userId, updatedUser);

        // Assert
        var noContentResult = result as NoContentResult;
        Assert.IsNotNull(noContentResult);
        Assert.AreEqual(204, noContentResult.StatusCode);
    }

    [TestMethod]
    public void Update_WhenUserExistsAndUpdateFails_ReturnsNotFound()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var existingUser = new User { Id = userId, Name = "Existing User", Email = "existing@test.com", CreatedAt = DateTime.UtcNow.AddDays(-5) };
        var updatedUser = new User { Id = userId, Name = "Updated User", Email = "updated@test.com" };
        var mockService = new Mock<ICrudService<User>>();
        mockService.Setup(s => s.GetById(userId)).Returns(existingUser);
        mockService.Setup(s => s.Update(userId, updatedUser)).Returns(false);
        var controller = new UsersController(mockService.Object);

        // Act
        var result = controller.Update(userId, updatedUser);

        // Assert
        var notFoundResult = result as NotFoundResult;
        Assert.IsNotNull(notFoundResult);
        Assert.AreEqual(404, notFoundResult.StatusCode);
    }

    [TestMethod]
    public void Update_PreservesCreatedAtFromExistingUser()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var originalCreatedAt = DateTime.UtcNow.AddDays(-10);
        var existingUser = new User { Id = userId, Name = "Existing User", Email = "existing@test.com", CreatedAt = originalCreatedAt };
        var updatedUser = new User { Id = userId, Name = "Updated User", Email = "updated@test.com", CreatedAt = DateTime.UtcNow };
        var mockService = new Mock<ICrudService<User>>();
        mockService.Setup(s => s.GetById(userId)).Returns(existingUser);
        mockService.Setup(s => s.Update(userId, updatedUser)).Returns(true);
        var controller = new UsersController(mockService.Object);

        // Act
        controller.Update(userId, updatedUser);

        // Assert
        Assert.AreEqual(originalCreatedAt, updatedUser.CreatedAt);
    }

    [TestMethod]
    public void Update_CallsServiceUpdate()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var existingUser = new User { Id = userId, Name = "Existing User", Email = "existing@test.com", CreatedAt = DateTime.UtcNow.AddDays(-5) };
        var updatedUser = new User { Id = userId, Name = "Updated User", Email = "updated@test.com" };
        var mockService = new Mock<ICrudService<User>>();
        mockService.Setup(s => s.GetById(userId)).Returns(existingUser);
        mockService.Setup(s => s.Update(userId, updatedUser)).Returns(true);
        var controller = new UsersController(mockService.Object);

        // Act
        controller.Update(userId, updatedUser);

        // Assert
        mockService.Verify(s => s.Update(userId, updatedUser), Times.Once);
    }

    [TestMethod]
    public void Delete_WhenDeleteSucceeds_ReturnsNoContent()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var mockService = new Mock<ICrudService<User>>();
        mockService.Setup(s => s.Delete(userId)).Returns(true);
        var controller = new UsersController(mockService.Object);

        // Act
        var result = controller.Delete(userId);

        // Assert
        var noContentResult = result as NoContentResult;
        Assert.IsNotNull(noContentResult);
        Assert.AreEqual(204, noContentResult.StatusCode);
    }

    [TestMethod]
    public void Delete_WhenDeleteFails_ReturnsNotFound()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var mockService = new Mock<ICrudService<User>>();
        mockService.Setup(s => s.Delete(userId)).Returns(false);
        var controller = new UsersController(mockService.Object);

        // Act
        var result = controller.Delete(userId);

        // Assert
        var notFoundResult = result as NotFoundResult;
        Assert.IsNotNull(notFoundResult);
        Assert.AreEqual(404, notFoundResult.StatusCode);
    }

    [TestMethod]
    public void Delete_CallsServiceDelete()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var mockService = new Mock<ICrudService<User>>();
        mockService.Setup(s => s.Delete(userId)).Returns(true);
        var controller = new UsersController(mockService.Object);

        // Act
        controller.Delete(userId);

        // Assert
        mockService.Verify(s => s.Delete(userId), Times.Once);
    }
}
