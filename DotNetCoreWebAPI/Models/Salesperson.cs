using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWebAPI.Models {
	public class Salesperson {

		public int Id { get; set; } // Primary Key

		
		[StringLength(25), Required]
		public string Name { get; set; }

		
		[StringLength(2), Required] // code max length 2, and make it required
		public string StateCode { get; set; } // Must be unique
		
		[Column(TypeName = "decimal(11,2)")]
		public decimal Sales { get; set; }

	}
}
