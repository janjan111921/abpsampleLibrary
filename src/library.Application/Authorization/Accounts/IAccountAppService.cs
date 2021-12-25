using System.Threading.Tasks;
using Abp.Application.Services;
using library.Authorization.Accounts.Dto;

namespace library.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
