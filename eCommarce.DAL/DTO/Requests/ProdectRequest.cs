using System;
using eCommarce.DAL.Models;
using Microsoft.AspNetCore.Http;

namespace eCommarce.DAL.DTO.Requests
{
	public class ProdectRequest
	{
        public string Name { get; set; }

        public string Price { get; set; }

        public string Description { get; set; }

        public decimal discount { get; set; }

        public int Quentity { get; set; }

        public IFormFile MainImage { get; set; }
        public double Rate { get; set; }


        public int CategoryId { get; set; }
 

        public int? BrandId { get; set; }
     }
}

