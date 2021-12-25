using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace library.Controllers
{
    public abstract class libraryControllerBase: AbpController
    {
        protected libraryControllerBase()
        {
            LocalizationSourceName = libraryConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
