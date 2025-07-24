using System;
namespace eCommarce.DAL.Models
{
    public enum Statues
    {
        Active=1,
        InActive

    }


	public class BaseModel
	{
		public int  Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Statues statues { get; set; }

    }
}

