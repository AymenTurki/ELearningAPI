using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ELearningAPI.Data.Models
{
	public class UserRole
	{
		[Key]
		[Required]
		public int UserId { get; set; }
		public User User { get; set; }
		[Key]
		[Required]
		public int RoleId { get; set; }
		public Role Role { get; set; }
	}
}
