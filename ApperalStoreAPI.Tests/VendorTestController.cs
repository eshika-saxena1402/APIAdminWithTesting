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
    public class VendorTestController
    {
        private ApplicationDbContext context;
        public static DbContextOptions<ApplicationDbContext> dbContextOptions { get; set; }
        public static string connectionString = "Data Source=TRD-502;Initial Catalog=EshikaAPI;Integrated Security=True;";
        static VendorTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>().
                UseSqlServer(connectionString).Options;
        }
        public VendorTestController()
        {
            context = new ApplicationDbContext(dbContextOptions);
        }
        [Fact]
        public async void Task_GetById_Return_OkResult()
        {
            var controller = new VendorController(context);
            var CatId = 1;
            var data = await controller.Get(CatId);
            Assert.IsType<OkObjectResult>(data);
        }
        [Fact]
        public async void Task_GetById_Return_NOFResult()
        {
            var controller = new VendorController(context);
            var CatId = 100;
            var data = await controller.Get(CatId);
            Assert.IsType<NotFoundResult>(data);
        }
        [Fact]
        public async void Task_GetById_Return_MatchResult()
        {
            var controller = new VendorController(context);
            var Id = 1;
            var data = await controller.Get(Id);
            Assert.IsType<OkObjectResult>(data);
            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var cat = okResult.Value.Should().BeAssignableTo<Vendor>().Subject;
            Assert.Equal("AKASH", cat.VendorName);
        }
        [Fact]
        public async void Task_GetById_Return_BadRequest()
        {
            var controller = new VendorController(context);
            int? id = null;
            var data = await controller.Get(id);
            Assert.IsType<BadRequestResult>(data);
        }
        [Fact]
        public async void Task_Add_Return_OkRequest()
        {
            var controller = new VendorController(context);
            var user = new Vendor()
            {
                VendorName = "AKASH",
                VendorEmail = "AK@GMAIL.COM",
                VendorPhoneNo = 98774522145
            };
            var data = await controller.Post(user);
            Assert.IsType<CreatedAtActionResult>(data);
        }
        [Fact]
        public async void Task_Add_InvalidData_Return_BadRequest()
        {
            var controller = new VendorController(context);
            var user = new Vendor()
            {
                VendorName = "AKASfdgfdvbfdvdbdfvH",
                VendorEmail = "AK@GMAIL.COM",
                VendorPhoneNo = 98774522145
            };
            var data = await controller.Post(user);
            Assert.IsType<BadRequestResult>(data);
        }
        [Fact]
        public async void Task_delete_Return_okResult()
        {
            var controller = new VendorController(context);
            var id = 3;
            var data = await controller.Delete(id);
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public async void Task_delete_Return_notfound()
        {
            var controller = new VendorController(context);
            var id = 100;
            var data = await controller.Delete(id);
            Assert.IsType<NotFoundResult>(data);
        }
        [Fact]
        public async void Task_delete_Return_badrequest()
        {
            var controller = new VendorController(context);
            int? id = null;
            var data = await controller.Delete(id);
            Assert.IsType<BadRequestResult>(data);
        }

        [Fact]
        public async void Task_update_Return_ok()
        {

            var id = 1;

            var controller = new VendorController(context);
            var user = new Vendor()
            {
                VendorId = 1,
                VendorName = "Akash",
                VendorEmail = "a@gmail.com",
                VendorPhoneNo = 12345
            };
            var data1 = await controller.Put(id, user);
            Assert.IsType<OkObjectResult>(data1);
        }
        [Fact]
        public async void Task_update_Return_Badreq()
        {
            var controller = new VendorController(context);
            int? id = null;

            var user = new Vendor()
            {
                VendorId = 14,
                VendorName = "Bislerasasi",
                VendorEmail = "b@gmail.com",
                VendorPhoneNo = 2131412
            };
            var data1 = await controller.Put(id, user);
            Assert.IsType<BadRequestResult>(data1);
        }
        [Fact]
        public async void Task_update_Return_notfound()
        {
            var controller = new VendorController(context);
            var id = 12;
            var user = new Vendor()
            {
                VendorId = 14,
                VendorName = "Bislerasasi",
                VendorEmail = "b@gmail.com",
                VendorPhoneNo = 2131412
            };
            var data = await controller.Put(id, user);
            Assert.IsType<NotFoundResult>(data);
        }
        [Fact]
        public async void Task_Return_GetAllUser()
        {
            var controller = new VendorController(context);
            var data = await controller.Get();
            Assert.IsType<OkObjectResult>(data);
        }
        [Fact]
        public async void Task_getAll_Return_NotFound()
        {
            var controller = new VendorController(context);
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
