using Xunit;
using MyExpenditure.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace MyExpenditure.Tests
{
    public class ItemControllerTests
    {
        [Fact]
        public void GetAll_ReturnsAllItems()
        {
            // Arrange
            var controller = new ItemController();

            // Act
            var result = controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var items = Assert.IsAssignableFrom<IEnumerable<Item>>(okResult.Value);
        }

        [Fact]
        public void GetById_ReturnsItem_WhenItemExists()
        {
            // Arrange
            var controller = new ItemController();
            var created = controller.Create(new Item { Name = "Test", Price = 10 }).Value;

            // Act
            var result = controller.GetById(created.Id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var item = Assert.IsType<Item>(okResult.Value);
            Assert.Equal("Test", item.Name);
        }

        [Fact]
        public void GetById_ReturnsNotFound_WhenItemDoesNotExist()
        {
            var controller = new ItemController();
            var result = controller.GetById(999);

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void Create_AddsItem()
        {
            var controller = new ItemController();
            var item = new Item { Name = "New", Price = 5 };

            var result = controller.Create(item);

            var createdAt = Assert.IsType<CreatedAtActionResult>(result.Result);
            var createdItem = Assert.IsType<Item>(createdAt.Value);
            Assert.Equal("New", createdItem.Name);
        }

        [Fact]
        public void Update_UpdatesExistingItem()
        {
            var controller = new ItemController();
            var created = controller.Create(new Item { Name = "Old", Price = 1 }).Value;

            var updateResult = controller.Update(created.Id, new Item { Name = "Updated", Price = 2 });

            Assert.IsType<NoContentResult>(updateResult);

            var getResult = controller.GetById(created.Id);
            var okResult = Assert.IsType<OkObjectResult>(getResult.Result);
            var updatedItem = Assert.IsType<Item>(okResult.Value);
            Assert.Equal("Updated", updatedItem.Name);
        }

        [Fact]
        public void Update_ReturnsNotFound_WhenItemDoesNotExist()
        {
            var controller = new ItemController();
            var result = controller.Update(999, new Item { Name = "X", Price = 1 });

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Delete_RemovesItem()
        {
            var controller = new ItemController();
            var created = controller.Create(new Item { Name = "ToDelete", Price = 3 }).Value;

            var deleteResult = controller.Delete(created.Id);

            Assert.IsType<NoContentResult>(deleteResult);

            var getResult = controller.GetById(created.Id);
            Assert.IsType<NotFoundResult>(getResult.Result);
        }

        [Fact]
        public void Delete_ReturnsNotFound_WhenItemDoesNotExist()
        {
            var controller = new ItemController();
            var result = controller.Delete(999);

            Assert.IsType<NotFoundResult>(result);
        }
    }
}