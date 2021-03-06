﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ELearningAPI.Data.Models
{
	public partial class Training
	{
		[Required]
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int TrainingId { get; set; }
		[Required]
		public int TrainingTypeId { get; set; }
		public TrainingType TrainigType { get; set; }

		public ICollection<Subscription> Subscriptions { get; set; }
	}
}
