using Common.Enums;
using DAL.EF;
using DAL.Entities;
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

        private IAppDbContext Context { get; }

        public UserService(UserManager<User> users, IAppDbContext context)
        {
            Users = users;
            Context = context;
        }

        public async Task<string> RegisterAsync(UserModel model)
        {
            var foundUser = await Users.FindByNameAsync(model.UserName);
            if (foundUser != null)
            {
                throw new Exception("Already exists");
            }

            var result = await Users.CreateAsync(new User
            {
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Gender = model.Gender,
                BirthDate = model.BirthDate
            }, model.Password);

            if(!result.Succeeded)
            {
                throw new Exception("Invalid login or password");
            }

            var user = await Users.FindByNameAsync(model.UserName);

            var roleAddResult = await Users.AddToRolesAsync(user, new List<string> { RoleType.User.ToString() });

            if(!roleAddResult.Succeeded)
            {
                throw new Exception("Уккщк");
            }

            return user.Id;
        }
    }
}
