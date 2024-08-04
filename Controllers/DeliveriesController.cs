using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApi.Data;
using MyApi.Models;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveriesController : ControllerBase
    {
        private readonly MyApiContext _context;

        public DeliveriesController(MyApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Delivery>>> GetDeliveries()
        {
            return await _context.Deliveries.ToListAsync();
        }

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

        [HttpPost]
        public async Task<ActionResult<Delivery>> PostDelivery(Delivery delivery)
        {
            _context.Deliveries.Add(delivery);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDelivery", new { id = delivery.Id }, delivery);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDelivery(int id, Delivery delivery)
        {
            if (id != delivery.Id)
            {
                return BadRequest();
            }

            _context.Entry(delivery).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDelivery(int id)
        {
            var delivery = await _context.Deliveries.FindAsync(id);
            if (delivery == null)
            {
                return NotFound();
            }

            _context.Deliveries.Remove(delivery);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
