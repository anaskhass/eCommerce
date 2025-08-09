using System;
namespace eCommarce.DAL.Utlis
{
	public interface ISeedData
	{
		  Task DataSeedingAsync();
		  Task IdentityDataSeedingAsync();
	}
}

