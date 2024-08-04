using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApi.Data;
using MyApi.Models;

namespace MyApi.Controllers.Mobile
{
    [Route("api/mobile/[controller]")]
    [ApiController]
    public class MobileDeliveriesController : ControllerBase
    {
        private readonly MyApiContext _context;

        public MobileDeliveriesController(MyApiContext context)
        {
            _context = context;
        }


        // GET: api/mobile/Deliveries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Delivery>>> GetDeliveries()
        {
            return await _context.Deliveries.ToListAsync();
        }

        // GET: api/mobile/Deliveries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Delivery>> GetDelivery(int id)
        {
            var delivery = await _context.Deliveries.FindAsync(id);
            if (delivery == null)
            {
                return NotFound();
            }

            return delivery;
        }

        // POST: api/mobile/Deliveries
        [HttpPost]
        public async Task<ActionResult<Delivery>> PostDelivery(Delivery delivery)
        {
            try
            {
                _context.Deliveries.Add(delivery);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetDelivery), new { id = delivery.Id }, delivery);
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                return StatusCode(500, "An error occurred while saving the entity changes. See the inner exception for details.");
            }
        }

        // PUT: api/mobile/Deliveries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDelivery(int id, Delivery delivery)
        { 
            if(id != delivery.Id)
            {
                return BadRequest();
            }
            _context.Entry(delivery).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
        }

        // DELETE: api/mobile/Deliveries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDelivery(int id)
        {
            var delivery = await _context.Deliveries.FindAsync(id);
            if (delivery == null)
            {
                return NotFound("Don't have this user id.");
            }
            _context.Deliveries.Remove(delivery);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
