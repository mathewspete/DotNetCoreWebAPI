using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWebAPI.Models {
	public class Orderline {

		public int Id { get; set; }
		[Required]
		public int OrderId { get; set; }
		public virtual Order Order { get; set; }
		[Required]
		public int ItemId { get; set; }
		public virtual Item Item { get; set; }
		[Required]
		public int Quantity { get; set; }

	}
}
