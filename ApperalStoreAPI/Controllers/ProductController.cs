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
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public ProductController(ApplicationDbContext _context)
        {
            context = _context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var a = await context.Products.ToListAsync();
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
                var product = context.Products.Find(id);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
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
            var product = context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            context.Products.Remove(product);
            await context.SaveChangesAsync();
            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                try
                {
                    context.Products.Add(product);
                    await context.SaveChangesAsync();
                    return CreatedAtAction("Get", new { id = product.ProductId }, product);
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int? id, [FromBody]Product p1)
        {
            if (id == null)
            {
                return BadRequest();
            }
           
                if (id != p1.ProductId)
                {
                    return NotFound();
                }             
                context.Entry(p1).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(p1);
            
        }

    }
}