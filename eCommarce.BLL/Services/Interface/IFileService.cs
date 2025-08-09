using System;
using Microsoft.AspNetCore.Http;

namespace eCommarce.BLL.Services.Interface
{
	public interface IFileService
	{

		Task<string> UploadAsync(IFormFile file);
	}
}

