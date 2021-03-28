using System.Threading.Tasks;
using BLL.Services.Base;
using Common.Enums;
using DAL.EF;
using DAL.Entities;
using Mapster;
using Microsoft.AspNetCore.Identity;

namespace BLL.Services.Tables
{
    public class DoctorService : EntityService<Doctor, string>
    {
        UserManager<User> UserManager { get; }

        public DoctorService(IAppDbContext context, UserManager<User> userManager) : base(context, context.Doctors) 
        {
            UserManager = userManager;
        }

        public async Task<Doctor> Add<T> (T model, string password)
        {
            var entity = model.Adapt<Doctor>();
            await Check(entity);
            await BeforeAdd(entity);
            await UserManager.CreateAsync(entity, password);
            await UserManager.AddToRoleAsync(entity, RoleType.Doctor.ToString().Normalize());
            await SaveChanges();

            return entity;
        }
    }
}
