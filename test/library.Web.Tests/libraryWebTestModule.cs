using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using library.EntityFrameworkCore;
using library.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace library.Web.Tests
{
    [DependsOn(
        typeof(libraryWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class libraryWebTestModule : AbpModule
    {
        public libraryWebTestModule(libraryEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(libraryWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(libraryWebMvcModule).Assembly);
        }
    }
}