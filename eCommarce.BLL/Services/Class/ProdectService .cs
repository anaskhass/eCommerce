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
    public class ProdectService : GenericService<ProdectRequest, ProdectResponse, Prodect>, IProdectService
    {
        private readonly IProdectRepository repository;
        private readonly IFileService fileService;

        public ProdectService(IProdectRepository repository,IFileService fileService) : base(repository)
        {
            this.repository = repository;
            this.fileService = fileService;
        }

        public async Task<int> CreateFile(ProdectRequest request)
        {
            var entity = request.Adapt<Prodect>();

            entity.CreatedAt = DateTime.UtcNow;

            if (request.MainImage != null)
            {
                var imagePath= await fileService.UploadAsync(request.MainImage);
                entity.MainImage = imagePath;
            }

            return repository.Add(entity);
        }
    }
}

