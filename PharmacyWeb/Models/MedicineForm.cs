using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyWeb.Models
{
	public class MedicineForm
	{
		[Key]
		public int Id { get; set; }
		[Required(ErrorMessage = "Название формы лекарства является обязательным полем.")]
		[StringLength(100, ErrorMessage = "Название формы лекарства не должно превышать 100 символов.")]
		[Display(Name = "Название формы лекарства")]
		public string Name { get; set; }
	}
}
