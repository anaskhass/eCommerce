using System;
using eCommarce.DAL.Data;
using eCommarce.DAL.Models;
using eCommarce.DAL.Repositories.Interface;

namespace eCommarce.DAL.Repositories.Class
{
	public class BrandRepository :  GenericRepository<Brand>, IBrandRepository
    {

        public BrandRepository(ApplicationDbContext context) : base(context)
        {


        }


    }
}

