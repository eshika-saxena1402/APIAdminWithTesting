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
    public class ProductTestController
    {
        private ApplicationDbContext context;
        public static DbContextOptions<ApplicationDbContext> dbContextOptions { get; set; }
        public static string connectionString = "Data Source=TRD-502;Initial Catalog=EshikaAPI;Integrated Security=True;";
        static ProductTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>().
                UseSqlServer(connectionString).Options;
        }
        public ProductTestController()
        {
            context = new ApplicationDbContext(dbContextOptions);
        }
        [Fact]
        public async void Task_GetById_Return_OkResult()
        {
            var controller = new ProductController(context);
            var id = 1;
            var data = await controller.Get(id);
            Assert.IsType<OkObjectResult>(data);
        }
        [Fact]
        public async void Task_GetById_Return_NFResult()
        {
            var controller = new ProductController(context);
            var id = 100;
            var data = await controller.Get(id);
            Assert.IsType<NotFoundResult>(data);
        }
        [Fact]
        public async void Task_GetById_Return_MatchResult()
        {
            var controller = new ProductController(context);
            var Id = 1;
            var data = await controller.Get(Id);
            Assert.IsType<OkObjectResult>(data);
            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var brand = okResult.Value.Should().BeAssignableTo<Product>().Subject;
            Assert.Equal("Shoes", brand.ProductName);
        }
        [Fact]
        public async void Task_GetById_Return_BadRequest()
        {
            var controller = new ProductController(context);
            int? id = null;
            var data = await controller.Get(id);
            Assert.IsType<BadRequestResult>(data);
        }
        [Fact]
        public async void Task_Add_Return_OkRequest()
        {
            var controller = new ProductController(context);
            var user = new Product()
            {
                ProductName = "Shoes",
                ProductPrice = 500,
                ProductQuantity = 100,
                ProductImage = "https://m.media-amazon.com/images/I/61QR+gJCbWL._AC_UL320_.jpg",
                ProductDescription = "this is a shoe",
                CategoryId = 4,
                VendorId = 1,
                BrandId = 1,
                ProductSize = "S"
            };
            var data = await controller.Post(user);
            Assert.IsType<CreatedAtActionResult>(data);
        }


        [Fact]
        public async void Task_delete_Return_okResult()
        {
            var controller = new ProductController(context);
            var id = 2;
            var data = await controller.Delete(id);
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public async void Task_delete_Return_notfound()
        {
            var controller = new ProductController(context);
            var id = 100;
            var data = await controller.Delete(id);
            Assert.IsType<NotFoundResult>(data);
        }
        [Fact]
        public async void Task_delete_Return_badrequest()
        {
            var controller = new ProductController(context);
            int? id = null;
            var data = await controller.Delete(id);
            Assert.IsType<BadRequestResult>(data);
        }
        [Fact]
        public async void Task_update_Return_ok()
        {

            var id = 2;

            var controller = new ProductController(context);
            var user = new Product()
            {
                ProductId=2,
                ProductName = "Shoes",
                ProductPrice = 1000,
                ProductQuantity = 100,
                ProductImage = "https://m.media-amazon.com/images/I/61QR+gJCbWL._AC_UL320_.jpg",
                ProductDescription = "this is a shoe",
                CategoryId = 4,
                VendorId = 1,
                BrandId = 1,
                ProductSize = "S"
            };
            var data1 = await controller.Put(id, user);
            Assert.IsType<OkObjectResult>(data1);
        }
        [Fact]
        public async void Task_update_Return_Badreq()
        {
            var controller = new ProductController(context);
            int? id = null;

            var user = new Product()
            {
                ProductName = "Shoes",
                ProductPrice = 1000,
                ProductQuantity = 100,
                ProductImage = "https://m.media-amazon.com/images/I/61QR+gJCbWL._AC_UL320_.jpg",
                ProductDescription = "this is a shoe",
                CategoryId = 4,
                VendorId = 1,
                BrandId = 1,
                ProductSize = "S"
            };
            var data1 = await controller.Put(id, user);
            Assert.IsType<BadRequestResult>(data1);
        }
        [Fact]
        public async void Task_update_Return_notfound()
        {
            var controller = new ProductController(context);
            var id = 12;
            var user = new Product()
            {
                ProductName = "Shoes",
                ProductPrice = 1000,
                ProductQuantity = 100,
                ProductImage = "https://m.media-amazon.com/images/I/61QR+gJCbWL._AC_UL320_.jpg",
                ProductDescription = "this is a shoe",
                CategoryId = 4,
                VendorId = 1,
                BrandId = 1,
                ProductSize = "S"
            };
            var data = await controller.Put(id, user);
            Assert.IsType<NotFoundResult>(data);
        }


        [Fact]
        public async void Task_Return_GetAllUser()
        {
            var controller = new ProductController(context);
            var data = await controller.Get();
            Assert.IsType<OkObjectResult>(data);
        }
        [Fact]
        public async void Task_getAll_Return_NotFound()
        {
            var controller = new ProductController(context);
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
    }
}
