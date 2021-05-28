using System.Threading.Tasks;
using BLL.Services.Base;
using Common.Extensions;
using DAL.EF;
using DAL.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services.Tables
{
    public class CardService : EntityService<Card, int>
    {
        public CardService(IAppDbContext context) : base(context, context.Cards) { }

        public override async Task<T> ById<T>(int id)
        {
            var entity = await Context.Cards
                .Include(x => x.User)
                .ById(id);
            var model = entity.Adapt<T>();
            return model;
        }
    }
}
