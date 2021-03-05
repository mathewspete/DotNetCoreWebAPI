using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWebAPI.Models {
	public class Item {

		public int Id { get; set; }
		[StringLength(30),Required]
		public string Name { get; set; }
		[Column(TypeName ="decimal(9,2)"),Required]
		public decimal Price { get; set; }

	}
}
