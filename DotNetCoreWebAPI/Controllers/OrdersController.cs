using DotNetCoreWebAPI.Data;
using DotNetCoreWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWebAPI.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class OrdersController : ControllerBase {
		private readonly WebAppDbContext _context;

		public OrdersController(WebAppDbContext context) {
			_context = context;
		}


		// PUT: api/Orders/Edit/5
		// 
		[HttpPut("edit/{id}")] 
		public async Task<IActionResult> SetStatusToEdit(int id) {
			var order = await _context.Orders.FindAsync(id);
			if (order==null) {
				return NotFound();
			}
			order.Status = "Edit";
			return await PutOrder(order.Id, order);
		}

		// PUT: api/Orders/Proposed/5
		// 
		[HttpPut("proposed/{id}")]
		public async Task<IActionResult> SetStatusToProposed(int id) {
			var order = await _context.Orders.FindAsync(id);
			if (order == null) {
				return NotFound();
			}
			order.Status = (order.Total > 100 && order.Total != 0)?"Proposed":"Final";
			return await PutOrder(order.Id, order);
		}

		// PUT: api/Orders/Final/5
		// 
		[HttpPut("final/{id}")]
		public async Task<IActionResult> SetStatusToFinal(int id) {
			var order = await _context.Orders.FindAsync(id);
			if (order == null) {
				return NotFound();
			}
			order.Status = "Final";
			return await PutOrder(order.Id, order);
		}


		// GET: api/Orders/proposed
		[HttpGet("proposed")]
		public async Task<ActionResult<IEnumerable<Order>>> GetProposed() {
			return await _context.Orders
														.Where(o => o.Status=="Proposed")
														.Include(c => c.Customer) // include is used to join customer to order
														.Include(s => s.Salesperson) // include is used to join salesperson to order
														.ToListAsync();
		}


		// GET: api/Orders
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Order>>> GetOrders() {
			return await _context.Orders
													 .Include(c => c.Customer) // include is used to join customer to order
													 .Include(s => s.Salesperson) // include is used to join salesperson to order
													 .ToListAsync();
		}

		// GET: api/Orders/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Order>> GetOrder(int id) {


			var order = await _context.Orders
																.Include(c => c.Customer) // include is used to join customer to order
																.Include(s => s.Salesperson) // include is used to join salesperson to order
																.Include(ol => ol.Orderlines) // links the orderline to order
																.ThenInclude(i => i.Item) // ThenInclude joins the item to the orderline, which is linked to the order 
																.SingleOrDefaultAsync(o => o.Id == id);



			if (order == null) {
				return NotFound();
			}

			return order;
		}

		// PUT: api/Orders/5
		// To protect from overposting attacks, enable the specific properties you want to bind to, for
		// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
		[HttpPut("{id}")]
		public async Task<IActionResult> PutOrder(int id, Order order) {
			if (id != order.Id) {
				return BadRequest();
			}

			_context.Entry(order).State = EntityState.Modified;

			try {
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException) {
				if (!OrderExists(id)) {
					return NotFound();
				}
				else {
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/Orders
		// To protect from overposting attacks, enable the specific properties you want to bind to, for
		// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
		[HttpPost]
		public async Task<ActionResult<Order>> PostOrder(Order order) {
			_context.Orders.Add(order);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetOrder", new { id = order.Id }, order);
		}

		// DELETE: api/Orders/5
		[HttpDelete("{id}")]
		public async Task<ActionResult<Order>> DeleteOrder(int id) {
			var order = await _context.Orders.FindAsync(id);
			if (order == null) {
				return NotFound();
			}

			_context.Orders.Remove(order);
			await _context.SaveChangesAsync();

			return order;
		}

		private bool OrderExists(int id) {
			return _context.Orders.Any(e => e.Id == id);
		}
	}
}
