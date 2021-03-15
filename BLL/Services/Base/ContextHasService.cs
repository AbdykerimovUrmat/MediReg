using System;
using System.Threading.Tasks;
using DAL.EF;

namespace BLL.Services.Base
{
    public abstract class ContextHasService : IDisposable
    {
        protected IAppDbContext Context { get; set; }
        public ContextHasService(IAppDbContext context) 
        {
            Context = context;
        }

        public async Task SaveChanges()
        {
            await Context?.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
