﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ELearningAPI.Data.Models
{
	public class Role
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int RoleId { get; set; }
		public string Name { get; set; }

		public ICollection<UserRole> UserRoles { get; set; }
	}
}
