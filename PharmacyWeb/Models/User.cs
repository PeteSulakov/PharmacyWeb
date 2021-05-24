using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PharmacyWeb.Models
{
	public class User : IdentityUser
	{
		[Display(Name = "ФИО")]
		public string FIO { get; set; }
	}
}
