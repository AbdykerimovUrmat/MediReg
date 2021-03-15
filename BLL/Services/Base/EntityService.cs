using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Extensions;
using Common.Interfaces;
using DAL.EF;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services.Base
{
    public abstract class EntityService<TEntity, TKey> : ContextHasService
        where TEntity : class, IIdHas<TKey>
        where TKey : IEquatable<TKey>
    {
        protected DbSet<TEntity> Entities { get; set; }
        protected EntityService(IAppDbContext context, DbSet<TEntity> entities) : base(context)
        {
            Entities = entities;
        }

        public virtual async Task<TEntity> Add<T> (T model)
        {
            var entity = model.Adapt<TEntity>();
            await Check(entity);
            await BeforeAdd(entity);
            await Entities.AddAsync(entity);

            return entity;
        }

        protected virtual Task BeforeAdd (TEntity model)
        {
            return Task.CompletedTask;
        }

        protected virtual Task Check(TEntity model)
        {
            return Task.CompletedTask;
        }

        public virtual async Task<IEnumerable<T>> List<T>()
        {
            return await Entities
                .AsNoTracking()
                .ProjectToType<T>()
                .ToListAsync();
        }

        public virtual async Task Edit<T>(T model) where T : IIdHas<TKey>
        {
            var entity = await Entities.ById<TEntity, TKey>(model.Id);
            model.Adapt(entity);

            await SaveChanges();
        }

        public virtual async Task Delete<T>(T model) where T : IIdHas<TKey>
        {
            Entities.Remove(await Entities.ById<TEntity, TKey>(model.Id));

            await SaveChanges();
        }
    }
}
