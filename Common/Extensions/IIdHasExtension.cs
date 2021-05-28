using System;
using System.Linq;
using System.Threading.Tasks;
using Common.Exceptions;
using Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Common.Extensions
{
    public static class IIdHasExtension
    {
        public static async Task<T> ById<T, TKey>(this IQueryable<T> entities, TKey id)
            where T : IIdHas<TKey>
            where TKey : IEquatable<TKey>
        {
            return await entities.FirstOrDefaultAsync(x => id.Equals(x.Id))
                ?? throw new InnerException($"10003. No such element with that Id.");
        }
    }
}
