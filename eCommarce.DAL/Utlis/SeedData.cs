using System;
using eCommarce.DAL.Data;

using eCommarce.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace eCommarce.DAL.Utlis
{
    public class SeedData : ISeedData
    {
        private readonly ApplicationDbContext context;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public SeedData(

            ApplicationDbContext context,
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager


            )
        {
            this.context = context;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public async Task DataSeedingAsync()
        {
            if ((await context.Database.GetPendingMigrationsAsync()).Any())
            {

                await context.Database.MigrateAsync();
            }
            if (!await context.categories.AnyAsync())
            {
                await context.categories.AddRangeAsync(

                    new Category { Name="cloth" },
                    new Category { Name = "mobiles" }

                    ) ;

            }

            if (!await context.Brands.AnyAsync())
            {
               await context.Brands.AddRangeAsync(

                    new Brand { Name = "Samsung" },
                    new Brand { Name = "Apple" },
                    new Brand { Name = "MacBook" }
                    );


            }
            await context.SaveChangesAsync();
        }

        //public async Task IdentityDataSeedingAsync()
        //{
        //    if(! await roleManager.Roles.AnyAsync())
        //    {
        //       await roleManager.CreateAsync(new IdentityRole("Admin"));
        //        await roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
        //        await roleManager.CreateAsync(new IdentityRole("Customer"));


        //    }
        //    if (!await userManager.Users.AnyAsync())
        //    {
        //        var user1=new ApplicationUser(){

        //            Email="AnasKhassawneh@gmail.com",
        //            FullName ="Anas Khassawneh",
        //            PhoneNumber="0796685724",
        //            UserName="AnasKhassawneh"
        //        };
        //        var user2 = new ApplicationUser()
        //        {

        //            Email = "AnasKhassawneh@yahoo.com",
        //            FullName = "Anas mazen Khasawneh",
        //            PhoneNumber = "0000000",
        //            UserName = "Anas2"
        //        };
        //        var user3 = new ApplicationUser()
        //        {

        //            Email = "Anas@gmail.com",
        //            FullName = "Anas Mazen abdel",
        //            PhoneNumber = "079999999",
        //            UserName = "AnasKhassawneh3"
        //        };

        //        await userManager.CreateAsync(user1,"Password@123");

        //        await userManager.CreateAsync(user2, "Password@1234");

        //        await userManager.CreateAsync(user3, "Password@12356");


        //        await userManager.AddToRoleAsync(user1, "Admin");

        //        await userManager.AddToRoleAsync(user2, "SuperAdmin");

        //        await userManager.AddToRoleAsync(user3, "Customer");
        //    }

        //    await context.SaveChangesAsync();
        //}



        public async Task IdentityDataSeedingAsync()
        {
            try
            {
                // Create roles if they don't exist
                if (!await roleManager.RoleExistsAsync("Admin"))
                    await roleManager.CreateAsync(new IdentityRole("Admin"));
                if (!await roleManager.RoleExistsAsync("SuperAdmin"))
                    await roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
                if (!await roleManager.RoleExistsAsync("Customer"))
                    await roleManager.CreateAsync(new IdentityRole("Customer"));

                // Create users if they don't exist
                var users = new List<ApplicationUser>
        {
            new ApplicationUser
            {
                Email = "AnasKhassawneh@gmail.com",
                FullName = "Anas Khassawneh",
                PhoneNumber = "0796685724",
                City="amman",
                Street="amman",
                UserName = "AnasKhassawneh",
                EmailConfirmed=true
            },
            new ApplicationUser
            {
                Email = "AnasKhassawneh@yahoo.com",
                FullName = "Anas mazen Khasawneh",
                PhoneNumber = "0000000",
                 City="amman",
                Street="amman",
                UserName = "Anas2",
                EmailConfirmed=true
            },
            new ApplicationUser
            {
                Email = "Anas@gmail.com",
                FullName = "Anas Mazen abdel",
                PhoneNumber = "079999999",
                 City="amman",
                Street="amman",
                UserName = "AnasKhassawneh3",
                EmailConfirmed=true
            }
        };

                var passwords = new[] { "Password@123", "Password@1234", "Password@12356" };
                var roles = new[] { "Admin", "SuperAdmin", "Customer" };

                for (int i = 0; i < users.Count; i++)
                {
                    var existingUser = await userManager.FindByEmailAsync(users[i].Email);
                    if (existingUser == null)
                    {
                        var createResult = await userManager.CreateAsync(users[i], passwords[i]);
                        if (createResult.Succeeded)
                        {
                            await userManager.AddToRoleAsync(users[i], roles[i]);
                        }
                        else
                        {
                            foreach (var error in createResult.Errors)
                                Console.WriteLine($"User creation failed: {error.Description}");
                        }
                    }
                }

                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error saving identity data: " + ex.Message);
                if (ex.InnerException != null)
                    Console.WriteLine("👉 Inner exception: " + ex.InnerException.Message);
            }
        }


    }
}

