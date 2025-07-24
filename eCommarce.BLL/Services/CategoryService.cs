using System;
using eCommarce.DAL.DTO.Requests;
using eCommarce.DAL.DTO.Responses;
using eCommarce.DAL.Models;
using eCommarce.DAL.Repositories;
using Mapster;

namespace eCommarce.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository CategoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            CategoryRepository = categoryRepository;
        }
        public int CreateCategory(CategoryRequest request)
        {
            var category = request.Adapt<Category>();

            return CategoryRepository.Add(category);


        }

        public int DeleteCategory(int id)
        {
            var category = CategoryRepository.GetById(id);
            if (category is null) return 0;
            return CategoryRepository.Remove(category);


        }

        public IEnumerable<Categoryresponse> GetAllCategories()
        {
            var category = CategoryRepository.GetAll();
            return category.Adapt<IEnumerable<Categoryresponse>>();

        }

        public Categoryresponse ? GetCategoryById(int id)
        {

            var category = CategoryRepository.GetById(id);
            if(category is null)
            {
                return null;
            }
            return category.Adapt<Categoryresponse>();
        }

        public int UpdateCategory(int id, CategoryRequest request)
        {
            var category = CategoryRepository.GetById(id);
            if (category is null)
            {
                return 0;
            }

            category.Name = request.Name;
            return CategoryRepository.Update(category);

        }

        public bool ToggleStatues(int id)
        {
            var category = CategoryRepository.GetById(id);
            if (category is null)
            {
                return false;
            }

            category.statues = category.statues == Statues.Active ? Statues.InActive : Statues.Active;
             CategoryRepository.Update(category);
            return true;
        }
    }
}

