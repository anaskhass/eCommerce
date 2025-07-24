using System;
using eCommarce.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommarce.DAL.Data
{
	public class ApplicationDbContext :DbContext
	{
		public DbSet<Category> categories { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		
		}
	
    }
}

