using System;
using eCommarce.BLL.Services.Interface;
using eCommarce.DAL.DTO.Requests;
using eCommarce.DAL.DTO.Responses;
using eCommarce.DAL.Models;
using eCommarce.DAL.Repositories;
using eCommarce.DAL.Repositories.Interface;

namespace eCommarce.BLL.Services.Class
{
    public class BrandService : GenericService<BrandRequest, BrandResponse, Brand>, IBrandService
    {
        public BrandService(IBrandRepository repository) : base(repository) { }

    }
}

