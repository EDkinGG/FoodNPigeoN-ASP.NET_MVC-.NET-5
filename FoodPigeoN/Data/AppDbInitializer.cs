using FoodPigeoN.Data.Enums;
using FoodPigeoN.Data.StaticRole;
using FoodPigeoN.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodPigeoN.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using ( var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                //City
                if(!context.Cities.Any() )
                {
                    context.Cities.AddRange(new List<City>()
                    {
                        new City()
                        {
                            CityName = "Dhaka",
                            CityPicture = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new City()
                        {
                            CityName = "Chittagong",
                            CityPicture = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new City()
                        {
                            CityName = "Sylhet",
                            CityPicture = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new City()
                        {
                            CityName = "Khulna",
                            CityPicture = "http://dotnethow.net/images/cinemas/cinema-4.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new City()
                        {
                            CityName = "Rajshahi",
                            CityPicture = "http://dotnethow.net/images/cinemas/cinema-5.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                    });
                    context.SaveChanges();
                }
                //Type
                if (!context.Types.Any())
                {
                    context.Types.AddRange(new List<Typee>()
                    {
                        new Typee()
                        {
                            TypeName = "Actor 1",
                            Description = "This is the Bio of the first actor",
                            TypePicture = "http://dotnethow.net/images/actors/actor-1.jpeg"

                        },
                        new Typee()
                        {
                            TypeName = "Actor 2",
                            Description = "This is the Bio of the second actor",
                            TypePicture = "http://dotnethow.net/images/actors/actor-2.jpeg"
                        },
                        new Typee()
                        {
                            TypeName = "Actor 3",
                            Description = "This is the Bio of the second actor",
                            TypePicture = "http://dotnethow.net/images/actors/actor-3.jpeg"
                        },
                        new Typee()
                        {
                            TypeName = "Actor 4",
                            Description = "This is the Bio of the second actor",
                            TypePicture = "http://dotnethow.net/images/actors/actor-4.jpeg"
                        },
                        new Typee()
                        {
                            TypeName = "Actor 5",
                            Description = "This is the Bio of the second actor",
                            TypePicture = "http://dotnethow.net/images/actors/actor-5.jpeg"
                        }
                    });
                    context.SaveChanges();

                }
                //Tag
                if (!context.Tags.Any())
                {
                    context.Tags.AddRange(new List<Tag>()
                    {
                        new Tag()
                        {
                            TagName = "Actor 1",
                            Description = "This is the Bio of the first actor",
                            TagPicture = "http://dotnethow.net/images/actors/actor-1.jpeg"

                        },
                        new Tag()
                        {
                            TagName = "Actor 2",
                            Description = "This is the Bio of the second actor",
                            TagPicture = "http://dotnethow.net/images/actors/actor-2.jpeg"
                        },
                        new Tag()
                        {
                            TagName = "Actor 3",
                            Description = "This is the Bio of the second actor",
                            TagPicture = "http://dotnethow.net/images/actors/actor-3.jpeg"
                        },
                        new Tag()
                        {
                            TagName = "Actor 4",
                            Description = "This is the Bio of the second actor",
                            TagPicture = "http://dotnethow.net/images/actors/actor-4.jpeg"
                        },
                        new Tag()
                        {
                            TagName = "Actor 5",
                            Description = "This is the Bio of the second actor",
                            TagPicture = "http://dotnethow.net/images/actors/actor-5.jpeg"
                        }
                    });
                    context.SaveChanges();

                }
                //Food
                if (!context.Foods.Any())
                {
                    context.Foods.AddRange(new List<Food>()
                    {
                        new Food()
                        {
                            FoodName = "Haleem",
                            FoodPicture = "http://dotnethow.net/images/actors/actor-1.jpeg",
                            Price = 60.00,
                            Description = "This is Haleem",
                            CityId = 1,
                            TypeId = 1,
                            TagId = 1,
                            FoodCategory = FoodCategory.Asian

                        },
                        new Food()
                        {
                            FoodName = "Pizza",
                            FoodPicture = "http://dotnethow.net/images/actors/actor-2.jpeg",
                            Price = 260.00,
                            Description = "This is Pizza",
                            CityId = 2,
                            TypeId = 2,
                            TagId = 2,
                            FoodCategory = FoodCategory.Italian
                        },
                        new Food()
                        {
                           FoodName = "Burger",
                            FoodPicture = "http://dotnethow.net/images/actors/actor-3.jpeg",
                            Price = 160.00,
                            Description = "This is Burger",
                            CityId = 3,
                            TypeId = 3,
                            TagId = 3,
                            FoodCategory = FoodCategory.American
                        },
                        new Food()
                        {
                           FoodName = "Shusi",
                            FoodPicture = "http://dotnethow.net/images/actors/actor-4.jpeg",
                            Price = 860.00,
                            Description = "This is Shusi",
                            CityId = 4,
                            TypeId = 4,
                            TagId = 4,
                            FoodCategory = FoodCategory.Japanese
                        },
                        new Food()
                        {
                           FoodName = "BBQ Chicken",
                            FoodPicture = "http://dotnethow.net/images/actors/actor-5.jpeg",
                            Price = 660.00,
                            Description = "This is BBQ Chicken",
                            CityId = 5,
                            TypeId = 5,
                            TagId = 5,
                            FoodCategory = FoodCategory.Korean
                        }
                    });
                    context.SaveChanges();

                }

            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                string adminEmail = "admin@food.com";

                var AdminAcc = await userManager.FindByEmailAsync(adminEmail);
                if (AdminAcc == null)
                {
                    var newAdminAcc = new AppUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-rashed",
                        Email = adminEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminAcc, "Admin1234?");
                    await userManager.AddToRoleAsync(newAdminAcc, UserRoles.Admin);
                }


                string DemoUserEmail = "user1@gmail.com";

                var DemoAcc = await userManager.FindByEmailAsync(DemoUserEmail);
                if (DemoAcc == null)
                {
                    var newDemoAcc = new AppUser()
                    {
                        FullName = "Rashed Ghani",
                        UserName = "Rashed",
                        Address = "California,US",
                        PhoneNumber = "1234567890",
                        Email = DemoUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newDemoAcc, "User1234?");
                    await userManager.AddToRoleAsync(newDemoAcc, UserRoles.User);
                }
            }
        }
    }
}
