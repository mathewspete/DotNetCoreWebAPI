using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWebAPI.Models {
	public class Order {
		public int Id { get; set; }
		
		
		[StringLength(200), Required]
		public string Description { get; set; }
		
		
		[StringLength(12), Required]
		public string Status { get; set; }
		
		
		[Column(TypeName = "decimal(9,2)")]
		public decimal Total { get; set; }
		
		
		public int CustomerId { get; set; }
		
		public virtual Customer Customer { get; set; } // Set customer as foreign key // Virtual = not in DB only in class


		public int SalespersonId { get; set; } // ? = null allowed

		public virtual Salesperson Salesperson { get; set; } // Set customer as foreign key // Virtual = not in DB only in class



		[Required]
		public virtual IEnumerable<Orderline> Orderlines { get; set; } // Virtual = not in DB only in class. and to link the OrderController back to the orderline?


		public Order() {}
	}


}

