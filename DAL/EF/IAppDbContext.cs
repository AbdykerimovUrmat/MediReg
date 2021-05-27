using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.EF
{
    public interface IAppDbContext
    {
        void Dispose();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        #region DbSets
        public DbSet<Card> Cards { get; set; }

        public DbSet<Topic> Topics { get; set; }
        #endregion
    }
}
