using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MvcIdentityLab.Models
{
    public class AppDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var administratorRole = new IdentityRole { Name = "Administrator" };
            var employerRole = new IdentityRole { Name = "Employer" };
            var guestRole = new IdentityRole { Name = "Guest" };

            var admin = new ApplicationUser { Email = "admin@belstu.by", UserName = "admin@belstu.by" };
            var employer = new ApplicationUser { Email = "emp@belstu.by", UserName = "emp@belstu.by" };
            var guest = new ApplicationUser { Email = "guest@belstu.by", UserName = "guest@belstu.by" };
            var super = new ApplicationUser { Email = "super@belstu.by", UserName = "super@belstu.by" };

            var isAdministratorRoleCreated = roleManager.Create(administratorRole).Succeeded;
            var isEmployerRoleCreated = roleManager.Create(employerRole).Succeeded;
            var isGuestRoleCreated = roleManager.Create(guestRole).Succeeded;

            userManager.Create(guest, "111111");
            var isAdministratorUserCreated = userManager.Create(admin, "111111").Succeeded;
            var isEmployerUserCreated = userManager.Create(employer, "111111").Succeeded;
            var isSuperUserCreated = userManager.Create(super, "111111").Succeeded;

            if (isAdministratorRoleCreated && isAdministratorUserCreated) userManager.AddToRole(admin.Id, administratorRole.Name); 
            if (isEmployerRoleCreated && isEmployerUserCreated) userManager.AddToRole(employer.Id, employerRole.Name);
            if (isAdministratorRoleCreated && isEmployerUserCreated && isGuestRoleCreated && isSuperUserCreated)
                userManager.AddToRoles(super.Id, administratorRole.Name, employerRole.Name, guestRole.Name);
        }
    }
}