using System;
using eCommarce.DAL.Data;
using eCommarce.DAL.Models;
using eCommarce.DAL.Repositories.Interface;

namespace eCommarce.DAL.Repositories.Class
{
	public class ProdectRepository :  GenericRepository<Prodect>, IProdectRepository
    {

        public ProdectRepository(ApplicationDbContext context) : base(context)
        {


        }


    }
}

