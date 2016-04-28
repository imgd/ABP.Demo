using System.Net.Http;
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace MultipleDbContextDemo.AppServiceTest.Controller
{
    public class InspectorTest
    {
        [Fact]
        public async Task GetToken()
        {
            var response = new HttpClient().GetAsync("http://localhost:131/aouth/gettoken/yrV5ECWgSwStlIY6OznF2PLRmeW6VdWyySymx33uYvTD2NfWTDtcGWMHjSwJ1E");
            var msg = await response.Result.Content.ReadAsStringAsync();
            msg.ShouldNotBeEmpty();
        }
    }
}
