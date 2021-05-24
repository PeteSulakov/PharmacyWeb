using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PharmacyWeb.Models
{
	public class Medicine
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Название лекарства является обязательным полем.")]
		[StringLength(200, ErrorMessage = "Название лекарства не должно превышать 200 символов.")]
		[Display(Name = "Название лекарства")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Количество лекарства является обязательным поле.")]
        [Display(Name = "Количества товара")]
		public int Amount { get; set; }

		[Required(ErrorMessage = "Цена лекарства является обязательным полем.")]
		[DataType(DataType.Currency)]
		[Column(TypeName = "decimal(18, 2)")]
		[Display(Name = "Цена")]
		public decimal Price { get; set; }

		[Display(Name = "Активное вещество")]
		public int ActiveSubstanceId { get; set; }
		public ActiveSubstance ActiveSubstance { get; set; }

		[Display(Name = "Категория")]
		public int CategoryId { get; set; }
		public Category Category { get; set; }

		[Required(ErrorMessage = "Кол-во в упаковке является обязательным полем.")]
		[Range(1,100, ErrorMessage = "Кол-во в упаковке должно быть от 1 до 100 единиц.")]
		[Display(Name = "Количество в упаковке")]
		public int AmountInPackage { get; set; }

		[Required(ErrorMessage = "Единица измерения является обязательным полем.")]
		[StringLength(10)]
		[Display(Name = "Единица измерения")]
		public string Unit { get; set; }

		[Display(Name = "Форма лекарства")]
		public int MedicineFormId { get; set; }
		public MedicineForm MedicineForm { get; set; }

		[Display(Name = "Производитель")]
		public int ProducerId { get; set; }
		public Producer Producer { get; set; }
		[StringLength(150)]
		public string ImagePath { get; set; }
	}
}
