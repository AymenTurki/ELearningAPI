﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELearningAPI.Data.Models
{
	public partial class User
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int UserId { get; set; }

		public ICollection<UserRole> UserRoles { get; set; }
		public ICollection<Subscription> Subscriptions { get; set; }
	}
}
