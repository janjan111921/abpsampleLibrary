using Abp.Authorization;
using library.Authorization.Roles;
using library.Authorization.Users;

namespace library.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
