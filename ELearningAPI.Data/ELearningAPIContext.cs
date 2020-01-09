using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ELearningAPI.Data.Models;

namespace ELearningAPI.Data
{
	public class ELearningAPIContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<UserRole> UserRoles { get; set; }
		public DbSet<Training> Trainings { get; set; }
		public DbSet<TrainingType> TrainingTypes { get; set; }
		public DbSet<Class> Classes { get; set; }
		public DbSet<Subscription> Subscriptions { get; set; }

		public ELearningAPIContext(DbContextOptions<ELearningAPIContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//
			// Many-to-many relashionship have to be explicited
			//

			modelBuilder.Entity<UserRole>()
				.HasKey(ur => new { ur.UserId, ur.RoleId });
			modelBuilder.Entity<UserRole>()
				.HasOne(ur => ur.User)
				.WithMany(u => u.UserRoles)
				.HasForeignKey(ur => ur.UserId);
			modelBuilder.Entity<UserRole>()
				.HasOne(ur => ur.Role)
				.WithMany(r => r.UserRoles)
				.HasForeignKey(ur => ur.RoleId);

			modelBuilder.Entity<Subscription>()
				.HasKey(s => new { s.UserId, s.TrainingId });
			modelBuilder.Entity<Subscription>()
				.HasOne(s => s.User)
				.WithMany(u => u.Subscriptions)
				.HasForeignKey(s => s.UserId);
			modelBuilder.Entity<Subscription>()
				.HasOne(s => s.Training)
				.WithMany(t => t.Subscriptions)
				.HasForeignKey(s => s.TrainingId);

			// Data seed

			/*modelBuilder.Entity<Contact>()
				.HasData(
					new Contact
					{
						ContactId = 1,
						FirstName = "Jeshua",
						LastName = "Park",
						Address = "Chemin de la Prairie 36, 1007 Lausanne",
						Email = "jp@jeshua.ch",
						MobilePhoneNumber = "07544412213"
					},
					new Contact
					{
						ContactId = 2,
						FirstName = "Fatima",
						LastName = "Diallo",
						Address = "Rue de Marterey 4",
						Email = "fatou@gmail.com",
						MobilePhoneNumber = "0758954545"
					},
					new Contact
					{
						ContactId = 3,
						FirstName = "Modahmed-Ali",
						LastName = "Kurai",
						Address = "Avenu du Mauborget 13",
						Email = "m.a.k@hotmail.ch",
						MobilePhoneNumber = "0751111122"
					}
			);

			modelBuilder.Entity<ExpertizeLevel>()
				.HasData(
					new ExpertizeLevel
					{
						ExpertizeLevelId = 1,
						Name = "Beginner",
						NumericValue = 0
					},
					new ExpertizeLevel
					{
						ExpertizeLevelId = 2,
						Name = "Intermediate",
						NumericValue = 1
					},
					new ExpertizeLevel
					{
						ExpertizeLevelId = 3,
						Name = "Expert",
						NumericValue = 2
					}
			);

			modelBuilder.Entity<Skill>()
				.HasData(
					new Skill
					{
						SkillId = 1,
						Name = "C# Programming"
					},
					new Skill
					{
						SkillId = 2,
						Name = "SOLID Principles"
					},
					new Skill
					{
						SkillId = 3,
						Name = "Obect Oriented Programming"
					}
			);

			modelBuilder.Entity<ContactSkill>()
				.HasData(
					new ContactSkill
					{
						SkillId = 1,
						ContactId = 2,
						ExpertizeLevelId = 1
					},
					new ContactSkill
					{
						SkillId = 3,
						ContactId = 1,
						ExpertizeLevelId = 3
					},
					new ContactSkill
					{
						SkillId = 3,
						ContactId = 2,
						ExpertizeLevelId = 2
					}
				);*/
		}
	}
}
