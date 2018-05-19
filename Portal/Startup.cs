using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using Portal.Data;
using Portal.Models;

[assembly: OwinStartupAttribute(typeof(Portal.Startup))]
namespace Portal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();
        }

        private void CreateRolesAndUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                var adminUser = new ApplicationUser();
                adminUser.UserName = "Bob";
                adminUser.Email = "admin@portal.com";
                string adminPassword = "P@ssword1";

                var checkAdminUserCreation = userManager.Create(adminUser, adminPassword);

                if (checkAdminUserCreation.Succeeded)
                {
                    var result1 = userManager.AddToRole(adminUser.Id, "Admin");
                }
            }

            if (!roleManager.RoleExists("Manager"))
            {
                var role = new IdentityRole();
                role.Name = "Manager";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Employee"))
            {
                var role = new IdentityRole();
                role.Name = "Employee";
                roleManager.Create(role);
            }
        }
    }
}
