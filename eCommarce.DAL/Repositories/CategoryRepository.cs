using System;
using eCommarce.DAL.Data;
using eCommarce.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommarce.DAL.Repositories
{
	public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext context;

        public CategoryRepository(ApplicationDbContext context)
		{
            this.context = context;
        }

        public int Add(Category category)
        {
            context.categories.Add(category);
            return context.SaveChanges();


        }

        public IEnumerable<Category> GetAll(bool WithTraking = false)
        {
            if( WithTraking)
            {
                return context.categories.ToList();
            }

            return context.categories.AsNoTracking().ToList();


        }

        public Category ? GetById(int id)
        {
            return context.categories.Find(id);
        }

        public int Remove(Category category)
        {
            context.categories.Remove(category);
            return context.SaveChanges();
        }

        public int Update(Category category)
        {
            context.categories.Update(category);
            return context.SaveChanges();
        }
    }
}

