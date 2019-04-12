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
    //[EnableCors("AllowMyOrigin")]
    //[Route("api/[controller]")]
    //[ApiController]
    //public class OrderProductController : ControllerBase
    //{
    //    ApplicationDbContext context = new ApplicationDbContext();
    //    [HttpGet]
    //    public async Task<ActionResult<IEnumerable<OrderProduct>>> Get()
    //    {
    //        return await context.OrderProducts.ToListAsync();
    //    }
    //    [HttpGet("{id}/{id}")]
    //    public async Task<ActionResult<OrderProduct>> Get(int id, int id1)
    //    {
    //        var OrderProducts = context.OrderProducts.Where(x => x.OrderId == id).ToList();
    //        OrderProduct op = new OrderProduct();
    //        foreach (var item in OrderProducts)
    //        {
    //            op = context.OrderProducts.Where(x => x.ProductId == id1).SingleOrDefault();
    //        }
    //        if (op == null)
    //        {
    //            return NoContent();
    //        }
    //        return op;
    //    }
    //    [HttpDelete("{id}/{id}")]
    //    public async Task<ActionResult<OrderProduct>> Delete(int id, int id1)
    //    {
    //        var OrderProducts = context.OrderProducts.Where(x => x.OrderId == id).ToList();
    //        OrderProduct op = new OrderProduct();
    //        foreach (var item in OrderProducts)
    //        {
    //            op = context.OrderProducts.Where(x => x.ProductId == id1).SingleOrDefault();
    //        }
    //        if (op == null)
    //        {
    //            return NotFound();
    //        }
    //        context.OrderProducts.Remove(op);
    //        await context.SaveChangesAsync();
    //        return NoContent();
    //    }
        //[HttpPost]
        //public async Task<ActionResult<OrderProduct>> Post([FromBody]OrderProduct op)
        //{
        //    context.OrderProducts.Add(op);
        //    await context.SaveChangesAsync();
        //    return CreatedAtAction(nameof(Get), new { id = op.OrderId }, new { id1 = op.Productid },op);
        //}
        //[HttpPut("{id}/{id}")]
        //public async Task<ActionResult<Brand>> Put(int id, int id1, [FromBody]OrderProduct b1)
        //{
        //    if (id != b1.OrderId && id1 != b1.ProductId)
        //    {
        //        return BadRequest();
        //    }
        //    context.Entry(b1).State = EntityState.Modified;
        //    await context.SaveChangesAsync();
        //    return NoContent();
        //}
    //}                                                                 
}