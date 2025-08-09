using System;
using eCommarce.DAL.DTO.Requests;
using eCommarce.DAL.DTO.Responses;

namespace eCommarce.BLL.Services.Interface
{
	public interface IGenericServic<TRequest,TResponse,TEntity>
	{
        int Create(TRequest request);
        IEnumerable<TResponse> GetAll(bool onlyActive = false);
        TResponse? GetById(int id);
        int Update(int id, TRequest request);
        int Delete(int id);
        public bool ToggleStatues(int id);
    }
}

