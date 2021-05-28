using Common.Enums;
using Common.Exceptions;
using DAL.Entities;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services.Tables
{
    public class UserService
    {
        private UserManager<User> Users { get; }

        public UserService(UserManager<User> users)
        {
            Users = users;
        }

        public async Task<string> RegisterAsync(UserModel.Add model)
        {
            if ((await Users.FindByNameAsync(model.UserName)) != null)
            {
                throw new InnerException("10000.Already exists");
            }

            var result = await Users.CreateAsync(model.Adapt<User>(), model.Password);

            if(!result.Succeeded)
            {
                throw new InnerException("10001.Invalid login or password");
            }

            var user = await Users.FindByNameAsync(model.UserName);

            var roleAddResult = await Users.AddToRolesAsync(user, new List<string> { RoleType.User.ToString() });

            if(!roleAddResult.Succeeded)
            {
                throw new InnerException("10002.Error adding roles to user");
            }

            return user.Id;
        }

        public async Task Edit<T>(string id, T model)
        {
            var user = await Users.FindByIdAsync(id);
            user = model.Adapt(user);
            await Users.UpdateAsync(user);
        }

        public async Task<T> GetById<T>(string id)
        {
            var user = await Users.FindByIdAsync(id);
            return user.Adapt<T>();
        }

        public async Task<IEnumerable<T>> List<T> ()
        {
            var lst = await Users.Users
                .AsNoTracking()
                .ProjectToType<T>()
                .ToListAsync();

            return lst;
        }
    }
}
