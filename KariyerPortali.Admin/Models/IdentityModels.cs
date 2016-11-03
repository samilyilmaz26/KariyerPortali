using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace KariyerPortali.Admin.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationRole:IdentityRole
    {
        public string Description { get; set; }
        public ApplicationRole()
        {

        }
        public ApplicationRole(string roleName,string description):base(roleName)
        {
            this.Description = description;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    //    // Rol tanımlama
    //    KariyerPortaliEntities db = new KariyerPortaliEntities();
    //    RoleStore<ApplicationRole> roleStore = new RoleStore<ApplicationRole>(db);
    //    RoleManager<ApplicationRole> roleManager = new RoleManager<ApplicationRole>(roleStore);

    //        if(!roleManager.RoleExists("Admin"))
    //        {
    //            ApplicationRole adminRole = new ApplicationRole("Admin", "Sistem Yöneticisi");
    //    roleManager.Create(adminRole);
    //        }
    //        if(!roleManager.RoleExists("User"))
    //        {
    //            ApplicationRole userRole = new ApplicationRole("User", "Sistem kullanıcısı");
    //roleManager.Create(userRole);
    //        }
    //        // Rol tanımlama
    }
}