using System;
using eCommarce.DAL.DTO.Requests;
using eCommarce.DAL.DTO.Responses;
using eCommarce.DAL.Repositories;

namespace eCommarce.BLL.Services
{
	public interface ICategoryService
	{
		int CreateCategory(CategoryRequest request);
		IEnumerable<Categoryresponse> GetAllCategories();
		Categoryresponse? GetCategoryById(int id);
		int UpdateCategory(int id, CategoryRequest request);
		int DeleteCategory(int id);
		public bool ToggleStatues(int id);

    }
}

