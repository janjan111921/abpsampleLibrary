using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using library.Authorization;

namespace library
{
    [DependsOn(
        typeof(libraryCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class libraryApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<libraryAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(libraryApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
