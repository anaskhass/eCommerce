using System;
namespace eCommarce.DAL.Models
{
	public class Prodect :BaseModel
	{
		public string Name { get; set; }

        public string Price  { get; set; }

        public string Description { get; set; }

        public decimal discount { get; set; }

        public int Quentity { get; set; }

        public string MainImage { get; set; }
        public double Rate { get; set; }


        public int CategoryId { get; set; }
        public Category Category { get; set; }


        public int? BrandId { get; set; }
        public Brand? Brand { get; set; }

    }
}

