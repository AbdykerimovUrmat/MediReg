using BLL.Services.Base;
using DAL.EF;
using DAL.Entities;

namespace BLL.Services.Tables
{
    public class TopicService : EntityService<Topic, int>
    {
        public TopicService(IAppDbContext context) : base(context, context.Topics) { }
    }
}
