using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELearningAPI.Data.Models
{
	public class User
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int UserId { get; set; }
		[Required]
		[ConcurrencyCheck]
		public string FirstName { get; set; }
		[Required]
		[ConcurrencyCheck]
		public string LastName { get; set; }
		[Required]
		[ConcurrencyCheck]
		public string Email { get; set; }
		[Required]
		[ConcurrencyCheck]
		public string Password { get; set; }

		public ICollection<UserRole> UserRoles { get; set; }
		public ICollection<Subscription> Subscriptions { get; set; }
	}
}
