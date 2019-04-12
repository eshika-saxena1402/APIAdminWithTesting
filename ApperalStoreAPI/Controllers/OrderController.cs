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
    public class OrderController : ControllerBase
    {

        private readonly ApplicationDbContext context;
        public OrderController(ApplicationDbContext _context)
        {
            context = _context;
        }
        [HttpGet]
            public async Task<IActionResult> Get()
            {
            var a = await context.Orders.ToListAsync();
            return Ok(a);
           
            }
            [HttpGet("{id}")]
            public async Task<IActionResult> Get(int? id)
            {
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                var order = context.Orders.Find(id);
                if (order == null)
                {
                    return NotFound();
                }
                return Ok(order);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int? id)
            {
            if (id == null)
            {
                return BadRequest();
            }
            var order = context.Orders.Find(id);
                if (order == null)
                {
                    return NotFound();
                }
                context.Orders.Remove(order);
                await context.SaveChangesAsync();
                return Ok(order);
            }
            [HttpPost]
            public async Task<IActionResult> Post([FromBody]Order order)
            {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                try
                {
                    context.Orders.Add(order);
                    await context.SaveChangesAsync();
                    return CreatedAtAction(nameof(Get), new { id = order.OrderId }, order);
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
           
            }
            [HttpPut("{id}")]
            public async Task<IActionResult> Put(int? id, [FromBody]Order o1)
            {
            if (id == null)
            {
                return BadRequest();
            }
            if (id != o1.OrderId)
                {
                    return NotFound();
                }
                context.Entry(o1).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(o1);
            }
        }
}