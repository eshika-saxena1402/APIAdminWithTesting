using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApperalStoreAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApperalStoreAPI.Controllers
{
    [EnableCors("AllowMyOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public ManagerController(ApplicationDbContext _context)
        {
            context = _context;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            List<Manager> b = await context.Managers.ToListAsync();
            if (b != null)
            {
                return Ok(b);
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
            try
            {
                var brand = context.Managers.Find(id);
                if (brand == null)
                {
                    return NotFound();
                }
                return Ok(brand);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            var brand = context.Managers.Find(id);
            if (brand == null)
            {
                return BadRequest();
            }
            context.Managers.Remove(brand);
            await context.SaveChangesAsync();
            return Ok(brand);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Manager brand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                try
                {
                    context.Managers.Add(brand);
                    await context.SaveChangesAsync();
                    return CreatedAtAction(nameof(Get), new { id = brand.ManagerId }, brand);
                }
                catch
                {
                    return BadRequest();
                }
            }


        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int? id, [FromBody]Manager b1)
        {
            if (id == null)
            {
                return BadRequest();
            }
            if (id != b1.ManagerId)
            {
                return NotFound();
            }
            context.Entry(b1).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(b1);
        }
    }
}