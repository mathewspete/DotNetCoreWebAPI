using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DotNetCoreWebAPI.Models {
	public class Orderline {

		public int Id { get; set; }
		[Required]
		public int OrderId { get; set; }
		[JsonIgnore] // required to use the (ThenInclue for item in order controller
		public virtual Order Order { get; set; } // Virtual = not in DB only in class
		[Required]
		public int ItemId { get; set; }
		public virtual Item Item { get; set; }
		[Required] // required for any required field that doesn't have default
		public int Quantity { get; set; }

	}
}
