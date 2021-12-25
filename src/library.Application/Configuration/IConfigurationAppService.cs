using System.Threading.Tasks;
using library.Configuration.Dto;

namespace library.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
