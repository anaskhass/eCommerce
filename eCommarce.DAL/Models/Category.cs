using System;
namespace eCommarce.DAL.Models
{
	public class Category : BaseModel
    {
		public string Name { get; set; }

		public List<Prodect> prodects { get; set; } = new List<Prodect>();

    }
}

