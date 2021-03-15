using System.Threading;
using System.Threading.Tasks;

namespace DAL.EF
{
    public interface IAppDbContext
    {
        void Dispose();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
