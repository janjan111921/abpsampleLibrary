using System.Threading.Tasks;
using library.Models.TokenAuth;
using library.Web.Controllers;
using Shouldly;
using Xunit;

namespace library.Web.Tests.Controllers
{
    public class HomeController_Tests: libraryWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}