using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ELearningAPI.Models
{
	public class NewUserModel
	{
		[Required]
		[RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "No digits or special characters are allowed.")]
		public string FirstName { get; set; }
		[Required]
		[RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "No digits or special characters are allowed.")]
		public string LastName { get; set; }
		[Required]
		[EmailAddress]
		public string Email { get; set; }
		[Required]
		[DataType(DataType.Password)]
		[RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Password must be at least 8 characters and contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
		public string Password { get; set; }
		[Required]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "The passwords do not match.")]
		public string PasswordConfirmation { get; set; }
	}
}
