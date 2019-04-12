using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApperalStoreAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApperalStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public CustomerController(ApplicationDbContext _context)
        {
            context = _context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Customer>c= await context.Customers.ToListAsync();
            if (c != null)
            {
                return Ok(c);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var customer = context.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            var customer = context.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }
           
            context.Customers.Remove(customer);
            await context.SaveChangesAsync();
            return Ok(customer);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                try
                {
                    context.Customers.Add(customer);
                    await context.SaveChangesAsync();
                    return CreatedAtAction(nameof(Get), new { id = customer.CustomerId }, customer);
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
           
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int? id, [FromBody]Customer c1)
        {
            if (id != c1.CustomerId)
            {
                return NotFound();
            }
            context.Entry(c1).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(c1);
        }
    }
}