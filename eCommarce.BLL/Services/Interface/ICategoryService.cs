using System;
using eCommarce.BLL.Services.Interface;
using eCommarce.DAL.DTO.Requests;
using eCommarce.DAL.DTO.Responses;
using eCommarce.DAL.Models;
using eCommarce.DAL.Repositories;

namespace eCommarce.BLL.Services
{
	public interface ICategoryService : IGenericServic<CategoryRequest, Categoryresponse, Category>
    {
	

    }
}

