﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Library.Services
{
    public interface IRepositoryBase<T>
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T,bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delelte(T entity);
        Task<bool> SaveAsync();

    }
}
