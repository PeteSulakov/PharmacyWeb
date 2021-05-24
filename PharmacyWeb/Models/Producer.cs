using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PharmacyWeb.Models
{
	public class Producer
	{
		[Key]
		public int Id { get; set; }
		[Required(ErrorMessage = "Название производителя является обязательным полем.")]
		[StringLength(200)]
		public string Name { get; set; }
		[Required(ErrorMessage = "Страна производителя является обязательным полем.")]
		[StringLength(100, ErrorMessage = "Название страны производителя не должно превышать 100 символов.")]
		public string Country { get; set; }
		public ICollection<Medicine> Medicines { get; set; }
	}
}
