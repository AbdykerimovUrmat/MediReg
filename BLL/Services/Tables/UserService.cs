using Common.Enums;
using DAL.EF;
using DAL.Entities;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Models.Tables;
using System;
using System.Collections.Generic;
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
                throw new Exception("Already exists");
            }

            var result = await Users.CreateAsync(model.Adapt<User>(), model.Password);

            if(!result.Succeeded)
            {
                throw new Exception("Invalid login or password");
            }

            var user = await Users.FindByNameAsync(model.UserName);

            var roleAddResult = await Users.AddToRolesAsync(user, new List<string> { RoleType.User.ToString() });

            if(!roleAddResult.Succeeded)
            {
                throw new Exception("Error adding roles to user");
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
    }
}
