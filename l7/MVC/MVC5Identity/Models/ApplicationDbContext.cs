using Microsoft.AspNet.Identity.EntityFramework;

namespace MvcIdentityLab.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(): base("DefaultConnection", false){}

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}