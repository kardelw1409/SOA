﻿using CurriculumService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CurriculumService.Interfaces
{
    public interface IEntityCrudService<TEntity> : IDisposable
        where TEntity : Entity
    {
        void Create(TEntity item);
        TEntity FindById(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        void Remove(TEntity item);
        void Update(TEntity item);
    }
}   