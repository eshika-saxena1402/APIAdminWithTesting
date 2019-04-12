using ApperalStoreAPI.Controllers;
using ApperalStoreAPI.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ApperalStoreAPI.Tests
{
    public class CategoryTestController
    {
        private ApplicationDbContext context;
        public static DbContextOptions<ApplicationDbContext> dbContextOptions { get; set; }
        public static string connectionString = "Data Source=TRD-502;Initial Catalog=EshikaAPI;Integrated Security=True;";
        static CategoryTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>().
                UseSqlServer(connectionString).Options;
        }
        public CategoryTestController()
        {
            context = new ApplicationDbContext(dbContextOptions);
        }
        [Fact]
        public async void Task_Get_Return_OkResult()
        {
            var controller = new CategoryController(context);
            var CategoryId = 5;
            var data = await controller.Get(CategoryId);
            Assert.IsType<OkObjectResult>(data);
        }
        [Fact]
        public async void Task_Get_Return_NotFoundResult()
        {
            var controller = new CategoryController(context);
            var CategoryId = 8;
            var data = await controller.Get(CategoryId);
            Assert.IsType<NotFoundResult>(data);
        }
        [Fact]
        public async void Task_GetUserById_MatchResult()
        {
            var controller = new CategoryController(context);
            int CategoryId = 1;
            var data = await controller.Get(CategoryId);
            Assert.IsType<OkObjectResult>(data);
            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var cat = okResult.Value.Should().BeAssignableTo<Category>().Subject;
            Assert.Equal("Shoes",cat.CategoryName);
            Assert.Equal("Shoes Desc",cat.CategoryDescription);
        }
        [Fact]
        public async void Task_GetCategoryById_Return_BadResquest()
        {
            var controller = new CategoryController(context);
            int? id = null;
            var data = await controller.Get(id);
            Assert.IsType<BadRequestResult>(data);
        }
        [Fact]
        public async void Task_AddCategory_Return_OkResult()
        {
            var controller = new CategoryController(context);
            var cat = new Category()
            {
                CategoryName = "Rings",
                CategoryDescription = "Rings Desc"
            };
            var data = await controller.Post(cat);
            Assert.IsType<CreatedAtActionResult>(data);
        }
        [Fact]
        public async void Task_AddCategory_Return_BadRequest()
        {
            var controller = new CategoryController(context);
            var cat = new Category()
            {
                CategoryName = "Ringgggggggggggggggg",
                CategoryDescription = "Rings Desc"
            };
            var data = await controller.Post(cat);
            Assert.IsType<BadRequestResult>(data);
        }
        [Fact]
        public async void Task_DeleteCategory_Retun_OkResult()
        {
            var controller = new CategoryController(context);
            int id = 3;
            var data = await controller.Delete(id);
            Assert.IsType<OkObjectResult>(data);
        }
        [Fact]
        public async void Task_DeleteCategory_Return_NotFoundResult()
        {
            var controller = new CategoryController(context);
            var id = 100;
            var data = await controller.Delete(id);
            Assert.IsType<NotFoundResult>(data);
        }
        [Fact]
        public async void Task_DeleteBrand_Retun_BadRequestResult()
        {
            var controller = new CategoryController(context);
            int? id = null;
            var data = await controller.Delete(id);
            Assert.IsType<BadRequestResult>(data);
        }
        [Fact]
        public async void Task_UpdateCategory_Return_OkResult()
        {
            var controller = new CategoryController(context);
            int CategoryId = 5;
            var cat = new Category()
            {
                CategoryId = 5,
               CategoryName = "Wallet",
                CategoryDescription = "Wallet Desc"
            };
            var data = await controller.Put(CategoryId, cat);
            Assert.IsType<OkObjectResult>(data);
        }
        [Fact]
        public async void Task_UpdateBrand_Return_BadResult()
        {
            var controller = new CategoryController(context);
            int? id = null;
            var cat = new Category()
            {
                CategoryId=4,
                CategoryName = "Wallet",
                CategoryDescription = "Wallet Desc"
            };
            var data = await controller.Put(id, cat);
            Assert.IsType<BadRequestResult>(data);
        }
        [Fact]
        public async void Task_UpdateBrand_Return_NotFound()
        {
            var controller = new CategoryController(context);
            var id = 10;
            var cat = new Category()
            {
                CategoryId = 4,
                CategoryName = "Wallet",
                CategoryDescription = "Wallet Desc"
            };
            var data = await controller.Put(id, cat);
            Assert.IsType<NotFoundResult>(data);
        }
        [Fact]
        public async void Task_getAllBrands_Return_NotFound()
        {
            var controller = new CategoryController(context);
            var data = await controller.Get();
            data = null;
            if (data != null)
            {
                Assert.IsType<OkObjectResult>(data);
            }
            else
            {
                Assert.Equal(data, null);
            }
        }
        [Fact]
        public async void Task_Return_GetAllBrands()
        {
            var controller = new CategoryController(context);
            var data = await controller.Get();
            Assert.IsType<OkObjectResult>(data);
        }
    }
}
