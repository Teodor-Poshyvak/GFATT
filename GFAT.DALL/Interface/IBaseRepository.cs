﻿using GFAT.Domain.Models;

namespace GFAT.DALL.Interface;

public interface IBaseRepository<T>
{
    Task Create(T entity);

    IQueryable<T> GetAll();

    Task Delete(T entity);

    Task<T> Update(T entity);
}