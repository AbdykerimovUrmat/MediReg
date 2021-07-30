using System;
using System.Collections.Generic;
using System.Linq;
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

        public virtual async Task<TKey> AddAsync<T> (T model)
        {
            var entity = model.Adapt<TEntity>();
            await Check(entity);
            await BeforeAdd(entity);
            await Entities.AddAsync(entity);
            await SaveChanges();

            return entity.Id;
        }

        protected virtual Task BeforeAdd (TEntity model)
        {
            return Task.CompletedTask;
        }

        protected virtual Task Check(TEntity model)
        {
            return Task.CompletedTask;
        }

        public virtual async Task<IEnumerable<T>> ListAsync<T>()
        {
            return await Entities
                .AsNoTracking()
                .ProjectToType<T>()
                .ToListAsync();
        }

        public virtual async Task EditAsync<T>(T model) where T : IIdHas<TKey>
        {
            var entity = await Entities.ById<TEntity, TKey>(model.Id);
            model.Adapt(entity);

            await SaveChanges();
        }

        public virtual async Task DeleteAsync<T>(T model) where T : IIdHas<TKey>
        {
            Entities.Remove(await Entities.ById(model.Id));

            await SaveChanges();
        }

        public virtual async Task<T> ByIdAsync<T>(TKey id)
        {
            var entity = await Entities.ById<TEntity, TKey>(id);
            var model = entity.Adapt<T>();
            return model;
        }

        public async Task<(IEnumerable<T> page, int totalPages)> PageAsync<T>(int pageNumber, int pageSize)
        {
            return (await Entities.AsQueryable()
                .Page(pageNumber, pageSize)
                .ProjectToType<T>()
                .ToListAsync(), await Total(Entities, pageSize));
        }

        protected async Task<int> Total(IQueryable<TEntity> query, int size)
        {
            var count = await query
                .CountAsync();
            return count == 0
                ? 1
                : count / size + (count % size > 0 ? 1 : 0);
        }
    }
}
