using System;
using eCommarce.BLL.Services.Class;
using eCommarce.DAL.DTO.Requests;
using eCommarce.DAL.DTO.Responses;
using eCommarce.DAL.Models;
using eCommarce.DAL.Repositories;
using Mapster;

namespace eCommarce.BLL.Services
{
    public class CategoryService : GenericService<CategoryRequest, Categoryresponse, Category>, ICategoryService
    {
     
        public CategoryService(ICategoryRepository repository) : base(repository) { }

    }
}

