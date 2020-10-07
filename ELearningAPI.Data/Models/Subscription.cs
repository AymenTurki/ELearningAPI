using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ELearningAPI.Data.Models
{
	public partial class Subscription
	{
		[Required]
		[Key]
		public int UserId { get; private set; }
		public User User { get; set; }
		[Required]
		[Key]
		public int TrainingId { get; set; }
		public Training Training { get; set; }
	}
}
