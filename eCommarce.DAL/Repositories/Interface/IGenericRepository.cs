using System;
using eCommarce.DAL.Models;

namespace eCommarce.DAL.Repositories.Interface
{
	public interface IGenericRepository<T> where T :  BaseModel
    {
        int Add(T entity);
        IEnumerable<T> GetAll(bool WithTraking = false);
        T? GetById(int id);
        int Remove(T entity);
        int Update(T entity);

    }
}

