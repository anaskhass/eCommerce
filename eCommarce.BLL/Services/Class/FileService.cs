//using System;
//using eCommarce.BLL.Services.Interface;
//using Microsoft.AspNetCore.Http;

//namespace eCommarce.BLL.Services.Class
//{
//    public class FileService : IFileService
//    {
//        public async Task<string> UploadAsync(IFormFile file)
//        {

//            if(file !=null && file.Length > 0)
//            {

//               var FileName= Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
//                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Images", FileName);


//                using(var stream = File.Create(filePath))
//                {

//                    await file.CopyToAsync(stream);

//                }


//                return FileName;

//            }
//            throw new Exception("error ");
//        }
//    }
//}

using eCommarce.BLL.Services.Interface;
using Microsoft.AspNetCore.Http;

public class FileService : IFileService
{
    public async Task<string> UploadAsync(IFormFile file)
    {
        if (file != null && file.Length > 0)
        {
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            // Save inside wwwroot/Images
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images");

            // Make sure folder exists
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var filePath = Path.Combine(folderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return fileName;
        }

        throw new Exception("No file provided");
    }
}
