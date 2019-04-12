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
    public class VendorController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public VendorController(ApplicationDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var a = await context.Vendors.ToListAsync();
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
                var vendor = context.Vendors.Find(id);
                if (vendor == null)
                {
                    return NotFound();
                }
                return Ok(vendor);
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
            var vendor = context.Vendors.Find(id);
            if (vendor == null)
            {
                return NotFound();
            }
            context.Vendors.Remove(vendor);
            await context.SaveChangesAsync();
            return Ok(vendor);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Vendor vendor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();

            }
            else
            {
                try
                {
                    context.Vendors.Add(vendor);
                    await context.SaveChangesAsync();
                    return CreatedAtAction(nameof(Get), new { id = vendor.VendorId }, vendor);

                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int? id, [FromBody]Vendor v1)
        {
            if (id == null)
            {
                return BadRequest();
            }
            else
            {
                if (id != v1.VendorId)
                {
                    return NotFound();
                }
                context.Entry(v1).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(v1);
            }
        }
    }
}