using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyWeb.Models
{
	public class Order
	{
        public int Id { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите ваше имя")]
        [Display(Name = "Имя")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите вашу фамилию")]
        [Display(Name = "Фамилия")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите ваш адрес")]
        [StringLength(100)]
        [Display(Name = "Адрес 1")]
        public string AddressLine1 { get; set; }

        [Display(Name = "Адрес2")]
        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите ваш почтовый индекс")]
        [Display(Name = "Почтовый индекс")]
        [StringLength(10, MinimumLength = 4)]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите ваш город")]
        [StringLength(50)]
        [Display(Name = "Город")]
        public string City { get; set; }

        [StringLength(10)]
        public string State { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите вашу страну")]
        [StringLength(50)]
        [Display(Name = "Страна")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Пожалуйста введите ваш номер телефона")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Телефонный номер")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Почта")]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
            ErrorMessage = "Адрес электронной почты введен в неправильном формате")]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        [DisplayName("Весь заказ")]
        public decimal OrderTotal { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        [DisplayName("Дата заказа")]
        public DateTime OrderPlaced { get; set; }
        [Display(Name = "Пользователь")]
        public string UserId { get; set; }

        public User User { get; set; }
        public ICollection<OrderDetail> OrderLines { get; set; }

    }
}
