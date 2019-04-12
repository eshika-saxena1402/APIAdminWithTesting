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
    public class FeedBackController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public FeedBackController(ApplicationDbContext _context)
        {
            context = _context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<FeedBack> feedBacks= await context.FeedBacks.ToListAsync();
            return Ok(feedBacks);
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
                var feedback = context.FeedBacks.Find(id);
                if (feedback == null)
                {
                    return NotFound();
                }
                return Ok(feedback);
            }
            catch
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
            var feedback = context.FeedBacks.Find(id);
            if (feedback == null)
            {
                return NotFound();
            }
            context.FeedBacks.Remove(feedback);
            await context.SaveChangesAsync();
            return Ok(feedback);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]FeedBack feedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                try
                {
                    context.FeedBacks.Add(feedback);
                    await context.SaveChangesAsync();
                    return CreatedAtAction(nameof(Get), new { id = feedback.FeedBackId }, feedback);
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }           
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int? id, [FromBody]FeedBack b1)
        {
            if (id == null)
            {
                return BadRequest();
            }
            if (id != b1.FeedBackId)
            {
                return NotFound();
            }
            context.Entry(b1).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(b1);
        }
    }
}