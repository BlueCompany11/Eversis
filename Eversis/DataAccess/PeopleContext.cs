using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eversis.Models;
using Microsoft.EntityFrameworkCore;

namespace Eversis.DataAccess
{
	public class PeopleContext : DbContext
	{
		public DbSet<Person> People { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlite("Data Source=Database.db");
			}
		}
	}
}
