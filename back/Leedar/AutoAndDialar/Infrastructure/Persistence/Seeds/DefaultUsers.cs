namespace Persistence.Seeds
{
    using Microsoft.AspNetCore.Identity;
    using Domain.Entities.Identity;
    using Shared.Struct;
    using System.Linq;
    using System.Threading.Tasks;
    //using Application.Common.Interfaces;
    using System;
    public static class DefaultUsers
    {
        public static async Task SeedAsync(UserManager<User> userManager, RoleManager<Role> roleManager, Infrastructure.Interfaces.IApplicationDbContext context)
        {
            try
            {
                if (userManager.Users.All(u => u.Id != StaticUser.DefultSupperAdmin))
                {
                    Domain.Entities.Application.PersonalInfo personalInfo = new()
                    {
                        Id = StaticUser.DefultSupperAdmin,
                       
                       
                        PhoneNumber = "0",
                        Email = "SystemAdmin@System.com",
                        FullNameAr = "مسؤول النظام",
                       
                        CreatedByUserId = StaticUser.System,

                    };
                    context.PersonalInfo.Add(personalInfo);
                    await context.SaveChangesAsync(default);


                    var user = new User(personalInfo.Id, "superAdmin","0", personalInfo.Email, StaticUser.System,null, true);
                    var creationResult = await userManager.CreateAsync(user, "N28Ecl84@P@ssw0rd@123");
                    if (!creationResult.Succeeded)
                    {
                        context.PersonalInfo.Remove(personalInfo);
                        throw new Exception("خطأ في تسجيل الحساب الجديد");
                    }
                    var roleObj = await roleManager.FindByIdAsync(Roles.SuperAdmin.ToString());

                    await userManager.AddToRoleAsync(user, roleObj.Name);
                }

                if (userManager.Users.All(u => u.Id != StaticUser.DefultAdmin))
                {
                    Domain.Entities.Application.PersonalInfo personalInfo = new()
                    {
                        Id = StaticUser.DefultAdmin,
                       
                        PhoneNumber = "0",
                        Email = "Admin@System.com",
                        FullNameAr = "المسؤول",
                      
                        CreatedByUserId = StaticUser.System,
                    };
                    context.PersonalInfo.Add(personalInfo);
                    await context.SaveChangesAsync(default);


                    var user = new User(personalInfo.Id, "Admin", "0", personalInfo.Email, StaticUser.System,null);
                    var creationResult = await userManager.CreateAsync(user, "N$P@ssw0rd@123");
                    if (!creationResult.Succeeded)
                    {
                        context.PersonalInfo.Remove(personalInfo);
                        throw new Exception("خطأ في تسجيل الحساب الجديد");
                    }
                    var roleObj = await roleManager.FindByIdAsync(Roles.Admin.ToString());
                    await userManager.AddToRoleAsync(user, roleObj.Name);
                }
                if (userManager.Users.All(u => u.Id != StaticUser.DefultAdmin1))
                {
                    Domain.Entities.Application.PersonalInfo personalInfo = new()
                    {
                        Id = StaticUser.DefultAdmin1,

                        PhoneNumber = "0",
                        Email = "Admin1@System.com",
                        FullNameAr = "مشرف 1",

                        CreatedByUserId = StaticUser.System,
                    };
                    context.PersonalInfo.Add(personalInfo);
                    await context.SaveChangesAsync(default);


                    var user = new User(personalInfo.Id, "Admin1", "0", personalInfo.Email, StaticUser.System, null);
                    var creationResult = await userManager.CreateAsync(user, "N$@P@ss$ad1&66");
                    if (!creationResult.Succeeded)
                    {
                        context.PersonalInfo.Remove(personalInfo);
                        throw new Exception("خطأ في تسجيل الحساب الجديد");
                    }
                    var roleObj = await roleManager.FindByIdAsync(Roles.Supervisor.ToString());
                    await userManager.AddToRoleAsync(user, roleObj.Name);
                }
                if (userManager.Users.All(u => u.Id != StaticUser.DefultAdmin2))
                {
                    Domain.Entities.Application.PersonalInfo personalInfo = new()
                    {
                        Id = StaticUser.DefultAdmin2,

                        PhoneNumber = "0",
                        Email = "Admin2@System.com",
                        FullNameAr = "مشرف 2",

                        CreatedByUserId = StaticUser.System,
                    };
                    context.PersonalInfo.Add(personalInfo);
                    await context.SaveChangesAsync(default);


                    var user = new User(personalInfo.Id, "Admin2", "0", personalInfo.Email, StaticUser.System, null);
                    var creationResult = await userManager.CreateAsync(user, "N$P@ss$$ad&22");
                    if (!creationResult.Succeeded)
                    {
                        context.PersonalInfo.Remove(personalInfo);
                        throw new Exception("خطأ في تسجيل الحساب الجديد");
                    }
                    var roleObj = await roleManager.FindByIdAsync(Roles.Supervisor.ToString());
                    await userManager.AddToRoleAsync(user, roleObj.Name);
                }
                if (userManager.Users.All(u => u.Id != StaticUser.DefultEmployee))
                {
                    Domain.Entities.Application.PersonalInfo personalInfo = new()
                    {
                        Id = StaticUser.DefultEmployee,
                       
                        PhoneNumber = "0",
                        Email = "Employee@System.com",
                        FullNameAr = "موظف",
                        
                        CreatedByUserId = StaticUser.System,
                    };
                    context.PersonalInfo.Add(personalInfo);
                    await context.SaveChangesAsync(default);


                    var user = new User(personalInfo.Id, "Employee",  "0", personalInfo.Email, StaticUser.System, null );
                    var creationResult = await userManager.CreateAsync(user, "Ee$@P@ssw0rd@123");
                    if (!creationResult.Succeeded)
                    {
                        context.PersonalInfo.Remove(personalInfo);
                        throw new Exception("خطأ في تسجيل الحساب الجديد");
                    }
                    var roleObj = await roleManager.FindByIdAsync(Roles.Employee.ToString());
                    await userManager.AddToRoleAsync(user, roleObj.Name);
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}