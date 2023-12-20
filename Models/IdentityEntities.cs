using Microsoft.AspNetCore.Identity;

namespace EdChannel.Models
{
    public partial class ApplicationUserLogin : IdentityUserLogin<long>
    {
    }
    public partial class ApplicationUserRole : IdentityUserRole<long>
    {
    }
    public partial class ApplicationUserClaim : IdentityUserClaim<long>
    {
    }
    public partial class ApplicationRole : IdentityRole<long>
    {
        public ApplicationRole() : base()
        {
        }

        public ApplicationRole(string roleName)
        {
            Name = roleName;
        }
    }
    public partial class ApplicationRoleClaim : IdentityRoleClaim<long>
    {
    }
    public partial class ApplicationUserToken : IdentityUserToken<long>
    {
    }
}
