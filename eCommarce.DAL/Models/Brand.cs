using System;
namespace eCommarce.DAL.Models
{
	public class Brand :BaseModel
	{
        public string Name { get; set; }

        public List<Prodect> prodects { get; set; } = new List<Prodect>();

        public string MainImage { get; set; }
    }
}

