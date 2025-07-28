using System;
using eCommarce.DAL.Data;
using eCommarce.DAL.Models;
using eCommarce.DAL.Repositories.Class;
using Microsoft.EntityFrameworkCore;

namespace eCommarce.DAL.Repositories
{
	public class CategoryRepository : GenericRepository<Category>,ICategoryRepository
    {

        public CategoryRepository(ApplicationDbContext context):base (context)
		{

            
        }

    }
}

