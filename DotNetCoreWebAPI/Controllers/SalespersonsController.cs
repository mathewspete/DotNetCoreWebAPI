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
	public class SalespersonsController : ControllerBase {
		private readonly WebAppDbContext _context;

		public SalespersonsController(WebAppDbContext context) {
			_context = context;
		}

		// GET: api/Salespersons
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Salesperson>>> GetSalesperson() {
			return await _context.Salesperson.ToListAsync();
		}

		// GET: api/Salespersons/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Salesperson>> GetSalesperson(int id) {
			var salesperson = await _context.Salesperson.FindAsync(id);

			if (salesperson == null) {
				return NotFound();
			}

			return salesperson;
		}

		// PUT: api/Salespersons/5
		// To protect from overposting attacks, enable the specific properties you want to bind to, for
		// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
		[HttpPut("{id}")]
		public async Task<IActionResult> PutSalesperson(int id, Salesperson salesperson) {
			if (id != salesperson.Id) {
				return BadRequest();
			}

			_context.Entry(salesperson).State = EntityState.Modified;

			try {
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException) {
				if (!SalespersonExists(id)) {
					return NotFound();
				}
				else {
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/Salespersons
		// To protect from overposting attacks, enable the specific properties you want to bind to, for
		// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
		[HttpPost]
		public async Task<ActionResult<Salesperson>> PostSalesperson(Salesperson salesperson) {
			_context.Salesperson.Add(salesperson);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetSalesperson", new { id = salesperson.Id }, salesperson);
		}

		// DELETE: api/Salespersons/5
		[HttpDelete("{id}")]
		public async Task<ActionResult<Salesperson>> DeleteSalesperson(int id) {
			var salesperson = await _context.Salesperson.FindAsync(id);
			if (salesperson == null) {
				return NotFound();
			}

			_context.Salesperson.Remove(salesperson);
			await _context.SaveChangesAsync();

			return salesperson;
		}

		private bool SalespersonExists(int id) {
			return _context.Salesperson.Any(e => e.Id == id);
		}
	}
}
