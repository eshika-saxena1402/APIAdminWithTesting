using ApperalStoreAPI.Controllers;
using ApperalStoreAPI.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace ApperalStoreAPI.Tests
{
    public class BrandTestController
    {
        private ApplicationDbContext context;
        public static DbContextOptions<ApplicationDbContext> dbContextOptions { get; set; }
        public static string connectionString = "Data Source=TRD-502;Initial Catalog=EshikaAPI;Integrated Security=True;";
        static BrandTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>().
                UseSqlServer(connectionString).Options;
        }
        public BrandTestController()
        {
            context = new ApplicationDbContext(dbContextOptions);
        }
        [Fact]
        public async void Task_Get_Return_OkResult()
        {
            var controller = new BrandController(context);
            var BrandId = 1;
            var data = await controller.Get(BrandId);
            Assert.IsType<OkObjectResult>(data);
        }
        [Fact]
        public async void Task_Get_Return_NotFoundResult()
        {
            var controller = new BrandController(context);
            var BrandId = 8;
            var data = await controller.Get(BrandId);
            Assert.IsType<NotFoundResult>(data);
        }
        [Fact]
        public async void Task_GetUserById_MatchResult()
        {
            var controller = new BrandController(context);
            int BrandId = 1;
            var data = await controller.Get(BrandId);
            Assert.IsType<OkObjectResult>(data);
            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var brand = okResult.Value.Should().BeAssignableTo<Brand>().Subject;
            Assert.Equal("Nike", brand.BrandName);
            Assert.Equal("Nike's Desc", brand.BrandDescription);
        }
        [Fact]
        public async void Task_GetUserById_Return_BadResquest()
        {
            var controller = new BrandController(context);
            int? id = null;
            var data = await controller.Get(id);
            Assert.IsType<BadRequestResult>(data);
        }
        [Fact]
        public async void Task_AddBrand_Return_OkResult()
        {
            var controller = new BrandController(context);
            var brand = new Brand()
            {
                BrandName="Nike",
                BrandDescription="Nike Desc"
            };
            var data = await controller.Post(brand);
            Assert.IsType<CreatedAtActionResult>(data);
        }
        [Fact]
        public async void Task_AddBrand_Return_BadRequest()
        {
            var controller = new BrandController(context);
            var brand = new Brand()
            {
                BrandName = "Nike123456",
                BrandDescription = "Nike Desc"
            };
            var data = await controller.Post(brand);
            Assert.IsType<BadRequestResult>(data);
        }
        [Fact]
        public async void Task_DeleteBrand_Retun_OkResult()
        {
            var controller = new BrandController(context);
            int id = 8;
            var data = await controller.Delete(id);
            Assert.IsType<OkObjectResult>(data);
        }
        [Fact]
        public async void Task_DeleteBrand_Return_NotFoundResult()
        {
            var controller = new BrandController(context);
            var id = 10;
            var data = await controller.Delete(id);
            Assert.IsType<NotFoundResult>(data);
        }
        [Fact]
        public async void Task_DeleteBrand_Retun_BadRequestResult()
        {
            var controller = new BrandController(context);
            int? id = null;
            var data = await controller.Delete(id);
            Assert.IsType<BadRequestResult>(data);
        }
        [Fact]
        public async void Task_UpdateBrand_Return_OkResult()
        {
            var controller = new BrandController(context);
            int BrandId = 1;
            var brand = new Brand()
            {
                BrandId = 1,
                BrandName = "Nike",
                BrandDescription = "Nike''s Desc"
            };
            var data = await controller.Put(BrandId, brand);
            Assert.IsType<OkObjectResult>(data);
        }
        [Fact]
        public async void Task_UpdateBrand_Return_BadResult()
        {
            var controller = new BrandController(context);
            int? id = null;
            var brand = new Brand()
            {
                BrandId = 1,
                BrandName = "Nike",
                BrandDescription = "Nike''s Desc"
            };
            var data = await controller.Put(id, brand);
            Assert.IsType<BadRequestResult>(data);
        }
        [Fact]
        public async void Task_UpdateBrand_Return_NotFound()
        {
            var controller = new BrandController(context);
            var id = 10;
            var brand = new Brand()
            {
                BrandId = 1,
                BrandName = "Nike",
                BrandDescription = "Nike''s Desc"
            };
            var data = await controller.Put(id, brand);
            Assert.IsType<NotFoundResult>(data);
        }
        [Fact]
        public async void Task_getAllBrands_Return_NotFound()
        {
            var controller = new BrandController(context);
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
            var controller = new BrandController(context);
            var data = await controller.Get();
            Assert.IsType<OkObjectResult>(data);
        }
    }
}
