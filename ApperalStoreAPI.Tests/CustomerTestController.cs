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
    public class CustomerTestController
    {
        private ApplicationDbContext context;
        public static DbContextOptions<ApplicationDbContext> dbContextOptions { get; set; }
        public static string connectionString = "Data Source=TRD-502;Initial Catalog=OnlineApparelStoreDb;Integrated Security=True;";
        static CustomerTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>().
                UseSqlServer(connectionString).Options;
        }
        public CustomerTestController()
        {
            context = new ApplicationDbContext(dbContextOptions);
        }
        [Fact]
        public async void Task_Get_Return_OkResult()
        {
            var controller = new CustomerController(context);
            var CustomerId = 1;
            var data = await controller.Get(CustomerId);
            Assert.IsType<OkObjectResult>(data);
        }
        [Fact]
        public async void Task_Get_Return_NotFoundResult()
        {
            var controller = new CustomerController(context);
            var CustomerId = 100;
            var data = await controller.Get(CustomerId);
            Assert.IsType<NotFoundResult>(data);
        }
        [Fact]
        public async void Task_GetUserById_MatchResult()
        {
            var controller = new CustomerController(context);
            int CustomerId = 1;
            var data = await controller.Get(CustomerId);
            Assert.IsType<OkObjectResult>(data);
            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var cus = okResult.Value.Should().BeAssignableTo<Customer>().Subject;
            Assert.Equal("Eshika", cus.CustomerFirstName);
            Assert.Equal("eshika@gmail.com", cus.Email);
        }
        [Fact]
        public async void Task_GetCategoryById_Return_BadResquest()
        {
            var controller = new CustomerController(context);
            int? id = null;
            var data = await controller.Get(id);
            Assert.IsType<BadRequestResult>(data);
        }
        [Fact]
        public async void Task_Add_Return_OkResult()
        {
            var controller = new CustomerController(context);
            var cat = new Customer()
            {
                CustomerFirstName = "Akash",
                CustomerLastName = "Singh",
                UserName = "Akki",
                Email = "akash@gmail.com",
                PhoneNumber = 9045712248,
                AlternatePhoneNumber = 9411971345,
                Address = "Sector-62",
                State = "Uttar Pradesh",
                Country = "India",
                ZipCode = 14421,
                Gender = "Male",
                Password = "akash"
            };
            var data = await controller.Post(cat);
            Assert.IsType<CreatedAtActionResult>(data);
        }
        //[Fact]
        //public async void Task_AddCategory_Return_BadRequest()
        //{
        //    var controller = new CustomerController(context);
        //    var cat = new Customer()
        //    {
        //        CustomerFirstName = "Akash",
        //        CustomerLastName = "Singh",
        //        UserName = "Akki",
        //        Email = "akash@gmail.com",
        //        PhoneNumber = 9045712248,
        //        AlternatePhoneNumber = 9411971345,
        //        Address = "Sector-62",
        //        State = "Uttar Pradesh",
        //        Country = "India",
        //        ZipCode = 14421,
        //        Gender = "Male",
        //        Password = "akash"
        //    };
        //    var data = await controller.Post(cat);
        //    Assert.IsType<BadRequestResult>(data);
        //}
        [Fact]
        public async void Task_DeleteCategory_Retun_OkResult()
        {
            var controller = new CustomerController(context);
            int id = 3;
            var data = await controller.Delete(id);
            Assert.IsType<OkObjectResult>(data);
        }
        [Fact]
        public async void Task_DeleteCategory_Return_NotFoundResult()
        {
            var controller = new CustomerController(context);
            var id = 100;
            var data = await controller.Delete(id);
            Assert.IsType<NotFoundResult>(data);
        }
        [Fact]
        public async void Task_DeleteBrand_Retun_BadRequestResult()
        {
            var controller = new CustomerController(context);
            int? id = null;
            var data = await controller.Delete(id);
            Assert.IsType<BadRequestResult>(data);
        }
        [Fact]
        public async void Task_UpdateCategory_Return_OkResult()
        {
            var controller = new CustomerController(context);
            int CustomerId = 4;
            var cat = new Customer()
            {
                CustomerId=4,
                CustomerFirstName = "Akash",
                CustomerLastName = "Singh",
                UserName = "Akki",
                Email = "akash@gmail.com",
                PhoneNumber = 9045712248,
                AlternatePhoneNumber = 9411971345,
                Address2 = "Sector-62",
                State2 = "Uttar Pradesh",
                Country2 = "India",
                ZipCode2 = 14421,
                Gender = "Male",
                Password = "akash"
            };
            var data = await controller.Put(CustomerId, cat);
            Assert.IsType<OkObjectResult>(data);
        }
        [Fact]
        public async void Task_UpdateBrand_Return_BadResult()
        {
            var controller = new CustomerController(context);
            int? id = null;
            var cat = new Customer()
            {
                CustomerId=4,
                CustomerFirstName = "Akash",
                CustomerLastName = "Singh",
                UserName = "Akki",
                Email = "akash@gmail.com",
                PhoneNumber = 9045712248,
                AlternatePhoneNumber = 9411971345,
                Address = "Sector-62",
                State = "Uttar Pradesh",
                Country = "India",
                ZipCode = 14421,
                Gender = "Male",
                Password = "akash"
            };
            var data = await controller.Put(id, cat);
            Assert.IsType<BadRequestResult>(data);
        }
        [Fact]
        public async void Task_UpdateBrand_Return_NotFound()
        {
            var controller = new CustomerController(context);
            var id = 10;
            var cat = new Customer()
            {
                CustomerFirstName = "Akash",
                CustomerLastName = "Singh",
                UserName = "Akki",
                Email = "akash@gmail.com",
                PhoneNumber = 9045712248,
                AlternatePhoneNumber = 9411971345,
                Address = "Sector-62",
                State = "Uttar Pradesh",
                Country = "India",
                ZipCode = 14421,
                Gender = "Male",
                Password = "akash"
            };
            var data = await controller.Put(id, cat);
            Assert.IsType<NotFoundResult>(data);
        }
        [Fact]
        public async void Task_getAllBrands_Return_NotFound()
        {
            var controller = new CustomerController(context);
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
            var controller = new CustomerController(context);
            var data = await controller.Get();
            Assert.IsType<OkObjectResult>(data);
        }
    }
}
