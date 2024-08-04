using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApi.Data;
using MyApi.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace MyApi.Controllers.Mobile
{
    [Route("api/mobile/[controller]")]
    [ApiController]
    public class MobileShopsController : ControllerBase
    {
        private readonly MyApiContext _context;

        public MobileShopsController(MyApiContext context)
        {
            _context = context;
        }

        // POST: api/mobile/Shops
        [HttpPost]
        //public async Task<ActionResult<Shop>> PostShop(Shop shop)
        //{
        //    try
        //    {
        //        _context.Shops.Add(shop);
        //        await _context.SaveChangesAsync();
        //        return CreatedAtAction(nameof(GetShop), new { id = shop.Id }, shop);
        //    }
        //    catch (DbUpdateException ex)
        //    {
        //        Console.WriteLine(ex.InnerException?.Message);
        //        return StatusCode(500, "An error occurred while saving the entity changes. See the inner exception for details.");
        //    }
        //}

        public async Task<ActionResult<Shop>> PostShop(Shop shop)
        {
            try
            {
                _context.Shops.Add(shop);
                await _context.SaveChangesAsync();

                // Construct the URI for the created resource
                var uri = Url.Action(nameof(GetShop), new { id = shop.Id });

                return Created(uri, shop);
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                return StatusCode(500, "An error occurred while saving the entity changes. See the inner exception for details.");
            }
        }

        // GET: api/mobile/Shops
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shop>>> GetShops()
        {
            return await _context.Shops.ToListAsync();
        }

        // GET: api/mobile/Shops/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shop>> GetShop(int id)
        {
            var shop = await _context.Shops.FindAsync(id);
            if (shop == null)
            {
                return NotFound();
            }

            return shop;

        }

        //PUT: api/mobile/Shops/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutShop(int id, Shop shop)
        {
            if (id != shop.Id)
            {
                return BadRequest();
            }
            _context.Entry(shop).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return StatusCode(202, "successfully");
           
        }

        // DELETE: api/mobile/Shops/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShop(int id)
        {
            var shop = await _context.Shops.FindAsync(id);
            if (shop == null)
            {
                return NotFound();
            }
            _context.Shops.Remove(shop);
            await _context.SaveChangesAsync();
            return StatusCode(200, "Delete Succesfully");
        }
    }
}
