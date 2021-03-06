﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ELearningAPI.Data.Models
{
	public partial class Class
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ClassId { get; set; }
		[Required]
		public int TrainingId { get; private set; }
		public Training Training { get; set; }
	}
}
