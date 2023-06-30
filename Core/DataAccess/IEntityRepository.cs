using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Entities; 

namespace Core.DataAccess
{
    //Generic Constraint - kisitlama
    //class : referans tip olabilir
    //IEntity : IEntity olabilir veya IEntity implemente eden bir nesne olabilir
    //new() : new'lenebilir olmali 
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        //List<T> GetAllByCategory(int categoryId);
        List<T> GetAll(Expression<Func<T, bool>> filter = null); //Entity'e göre gelmesini istedigimiz icin expression veriyoruz
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}