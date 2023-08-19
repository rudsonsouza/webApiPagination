using System;
using Microsoft.EntityFrameworkCore;
using webPagination.Models;

namespace webPagination.Data
{
	public class AppDbContext : DbContext
	{
		public DbSet<Todo> Todos { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
			=> optionsBuilder.UseSqlite(connectionString: "DataSource=app.db;Cache=Shared");
    }
}

