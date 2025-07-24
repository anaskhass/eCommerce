using System;
using eCommarce.DAL.Models;

namespace eCommarce.DAL.Repositories
{
	public interface ICategoryRepository
	{
		int Add(Category category);
		IEnumerable<Category> GetAll(bool WithTraking = false);
		Category ? GetById(int id);
		int Remove(Category category);
        int Update(Category category);

    }
}

