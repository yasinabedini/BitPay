﻿using AIPFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AIPFramework.Repository
{
    public interface IRepository<TEntity> where TEntity : AggregateRoot
    {
        TEntity GetById(long id);
        void Add(TEntity entity);
        List<TEntity> GetList();
        void Update(TEntity entity);
        void Delete(long id);
        void Save();
    }
}
