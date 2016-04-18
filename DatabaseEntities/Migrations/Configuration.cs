namespace DatabaseEntities.Migrations
{
    using DatabaseModel;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DatabaseEntities.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        private void SeedRoles(ref DataContext context)
        {
            // Jei nera nei vienos roles
            if (!context.Roles.Any())
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                roleManager.Create(new IdentityRole("SystemAdmin"));
                roleManager.Create(new IdentityRole("PrivateUser"));
                roleManager.Create(new IdentityRole("BusinessUser"));
                roleManager.Create(new IdentityRole("Courier"));
            }
        }


        private void CreateNewUser(ref DataContext context, string email, string password, string roleToAdd)
        {
            // Jei dar nera userio su tokiu email'u
            if (!context.Users.Any(u => u.Email == email))
            {
                UserManager<ApplicationAccount> userManager = new UserManager<ApplicationAccount>(new UserStore<ApplicationAccount>(context));
                var date = DateTime.Now;
                ApplicationAccount user = new ApplicationAccount() { Email = email, UserName = email, RegisteredDate = date };
                userManager.Create(user, password);
                userManager.AddToRole(user.Id, roleToAdd);
            }
        }

        protected override void Seed(DataContext context)
        {
            SeedRoles(ref context);
            CreateNewUser(ref context, "admin@redex.com", "123456", "SystemAdmin");
            CreateNewUser(ref context, "samplePrivateUser@redex.com", "123456", "PrivateUser");
            CreateNewUser(ref context, "sampleCourier@redex.com", "123456", "Courier");
            CreateNewUser(ref context, "sampleBusinessUser@redex.com", "123456", "BusinessUser");
        }
    }
}
