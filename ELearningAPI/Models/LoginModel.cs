﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ELearningAPI.Models
{
	public class LoginModel
	{
		[Required]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
		[Required]
		public string Password { get; set; }
	}
}
