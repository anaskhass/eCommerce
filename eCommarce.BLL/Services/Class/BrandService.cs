using System;
using eCommarce.BLL.Services.Interface;
using eCommarce.DAL.DTO.Requests;
using eCommarce.DAL.DTO.Responses;
using eCommarce.DAL.Models;
using eCommarce.DAL.Repositories;
using eCommarce.DAL.Repositories.Interface;
using Mapster;

namespace eCommarce.BLL.Services.Class
{
    public class BrandService : GenericService<BrandRequest, BrandResponse, Brand>, IBrandService
    {
        private readonly IBrandRepository repository;
        private readonly IFileService fileService;

        public BrandService(IBrandRepository repository, IFileService fileService) : base(repository)
        {
            this.repository = repository;
            this.fileService = fileService;
        }
        public async Task<int> CreateFile(BrandRequest request)
        {
            var entity = request.Adapt<Brand>();

            entity.CreatedAt = DateTime.UtcNow;

            if (request.MainImage != null)
            {
                var imagePath = await fileService.UploadAsync(request.MainImage);
                entity.MainImage = imagePath;
            }

            return repository.Add(entity);
        }
    }
}

