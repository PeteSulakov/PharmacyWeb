using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PharmacyWeb.Models
{
	public class Category
	{
		[Key]
		public int Id { get; set; }
		[Required(ErrorMessage = "Название категории является обязательным полем.")]
		[StringLength(100, ErrorMessage = "Название категории не должно превышать 100 символов.")]
		public string Name { get; set; }
		public ICollection<Medicine> Medicines { get; set; }
	}
}
