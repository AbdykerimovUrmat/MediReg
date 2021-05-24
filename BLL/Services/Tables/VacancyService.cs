using BLL.Services.Base;
using DAL.EF;

namespace BLL.Services.Tables
{
    public class VacancyService : EntityService
    {
        public VacancyService(IAppDbContext context, ) : base(context, )
        {

        }
    }
}
