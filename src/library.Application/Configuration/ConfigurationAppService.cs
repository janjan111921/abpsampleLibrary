using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using library.Configuration.Dto;

namespace library.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : libraryAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
