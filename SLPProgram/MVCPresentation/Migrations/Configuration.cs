namespace MVCPresentation.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MVCPresentation.Models;
    using Microsoft.AspNet.Identity;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCPresentation.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MVCPresentation.Models.ApplicationDbContext";
        }

        protected override void Seed(MVCPresentation.Models.ApplicationDbContext context)
        {
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            const string manager = "manager@gmail.com";
            const string managerPassword = "Password";

            context.Roles.AddOrUpdate(role => role.Name,
                new IdentityRole() { Name = "Manager" });
            context.Roles.AddOrUpdate(role => role.Name,
                new IdentityRole() { Name = "SLP" });
            context.Roles.AddOrUpdate(role => role.Name,
                new IdentityRole() { Name = "Teacher" });


            if (!context.Users.Any(user => user.UserName == manager))
            {
                var user = new ApplicationUser()
                {
                    UserName = manager,
                    Email = manager,
                    FirstName = "Manager",
                    LastName = "Company"
                };

                IdentityResult result = userManager.Create(user, managerPassword);
                context.SaveChanges(); // updates the database

                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Manager");
                    context.SaveChanges();
                }

            }
        }
    }
}
