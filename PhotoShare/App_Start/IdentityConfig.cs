﻿using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using PhotoShare.DataAccess.DataContext;
using PhotoShare.DataAccess.Entities;

namespace PhotoShare.App_Start
{
    public class ApplicationUserManager : UserManager<User>
    {
        public ApplicationUserManager(IUserStore<User> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var manager = new ApplicationUserManager(new UserStore<User>(context.Get<PhotoShareDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<User>(manager)
            {
                AllowOnlyAlphanumericUserNames = true,
                RequireUniqueEmail = true
            };
            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 8,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(3);
            manager.UserLockoutEnabledByDefault = true;
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<User>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }
}