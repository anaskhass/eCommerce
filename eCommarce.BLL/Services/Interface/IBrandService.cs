using System;
using eCommarce.DAL.DTO.Requests;
using eCommarce.DAL.DTO.Responses;
using eCommarce.DAL.Models;

namespace eCommarce.BLL.Services.Interface
{
	public interface IBrandService : IGenericServic<BrandRequest, BrandResponse, Brand>
    {
	}
}

