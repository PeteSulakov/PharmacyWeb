using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PharmacyWeb.Models
{
	public class ActiveSubstance
	{
		[Key]
		public int Id { get; set; }
		[Required(ErrorMessage = "Название активного вещества является обязательным полем.")]
		[StringLength(200, ErrorMessage = "Название активного вещества не должно превышать 200 символов.")]
		public string Name { get; set; }
		public ICollection<Medicine> Medicines { get; set; }
	}
}
