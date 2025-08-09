using System;
using Azure;
using Azure.Core;
using eCommarce.BLL.Services.Interface;
using eCommarce.DAL.DTO.Responses;
using eCommarce.DAL.Models;
using eCommarce.DAL.Repositories;
using eCommarce.DAL.Repositories.Class;
using eCommarce.DAL.Repositories.Interface;
using Mapster;

namespace eCommarce.BLL.Services.Class
{
    public class GenericService<TRequest, TResponse, TEntity> : IGenericServic<TRequest, TResponse, TEntity> where TEntity : BaseModel
    {
        private readonly IGenericRepository<TEntity> _repository;

        public GenericService(IGenericRepository<TEntity> genericRepository)
        {
            _repository = genericRepository;
        }


        public int Create(TRequest request)
        {


            var entity = request.Adapt<TEntity>();

            return _repository.Add(entity);


        }

        public int Delete(int id)
        {

            var entity = _repository.GetById(id);
            if (entity is null) return 0;
            return _repository.Remove(entity);


        }

        public IEnumerable<TResponse> GetAll(bool onlyActive=false)
        {

            var entity = _repository.GetAll();


            if (onlyActive)
            {
                entity = entity.Where(e => e.statues == Statues.Active);
            }
            return entity.Adapt<IEnumerable<TResponse>>();



        }

        public TResponse? GetById(int id)
        {

            var entity = _repository.GetById(id);
            if (entity is null)
            {
                return default;
            }
            return entity.Adapt<TResponse>();


        }

        public bool ToggleStatues(int id)
        {

            var entity = _repository.GetById(id);
            if (entity is null)
            {
                return false;
            }

            entity.statues = entity.statues == Statues.Active ? Statues.InActive : Statues.Active;
            _repository.Update(entity);
            return true;


        }

        public int Update(int id, TRequest request)
        {

            var entity = _repository.GetById(id);
            if (entity is null)
            {
                return 0;
            }
            var updatedEntity = request.Adapt(entity);

            return _repository.Update(updatedEntity);


        }
    }
}

