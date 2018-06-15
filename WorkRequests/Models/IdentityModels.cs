using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WorkRequests.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            userIdentity.AddClaim(new Claim("FirstName", this.FirstName.ToString()));
            userIdentity.AddClaim(new Claim("LastName", this.LastName.ToString()));

            return userIdentity;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }

    public class AppUsersDbContext  : IdentityDbContext<ApplicationUser>
    {
        public AppUsersDbContext()
            : base("DougDB", throwIfV1Schema: false)
        {
        }

        public static AppUsersDbContext Create()
        {
            return new AppUsersDbContext();
        }

        public System.Data.Entity.DbSet<WorkRequests.Models.WorkRequestViewModel> WorkRequestViewModels { get; set; }

        public System.Data.Entity.DbSet<WorkRequests.BO.WorkRequest> WorkRequests { get; set; }

        public System.Data.Entity.DbSet<WorkRequests.Models.Receipt> Receipts { get; set; }
    }
}