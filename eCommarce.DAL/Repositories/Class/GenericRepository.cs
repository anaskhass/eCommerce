using System;
using eCommarce.DAL.Data;
using eCommarce.DAL.Models;
using eCommarce.DAL.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace eCommarce.DAL.Repositories.Class
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {
        private readonly ApplicationDbContext context;

        public GenericRepository(ApplicationDbContext context)
        {
            this.context = context;
        }


        public int Add(T entity)
        {
            context.Set<T>().Add(entity);
            return context.SaveChanges();
        }

        public IEnumerable<T> GetAll(bool WithTraking = false)
        {

            if (WithTraking)
            {
                return context.Set<T>().ToList();
            }

            return context.Set<T>().AsNoTracking().ToList();
        }

        public T? GetById(int id)=>  context.Set<T>().Find(id);
        

        public int Remove(T entity)
        {

            context.Set<T>().Remove(entity);
            return context.SaveChanges();
        }

        public int Update(T entity)
        {
            context.Set<T>().Update(entity);
            return context.SaveChanges();
        }
    }
}

