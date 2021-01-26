using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using NET5.JWT.CustomUser;
using NET5.JWT.CustomUser.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Net5.JWT.XUnitTest
{
    public class Net5TestFakePolicy : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public Net5TestFakePolicy(WebApplicationFactory<Startup> factory)
        {
            _client = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddSingleton<IPolicyEvaluator, FakePolicyEvaluator>();
                });
            }).CreateClient();
        }

        [Fact]
        public async Task Weatherforecast()
        {
            var response = (await _client.GetAsync("/weatherforecast")).EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<WeatherForecast[]>(stringResponse);

            Assert.Equal(5, result.Length);
        }

        [Fact]
        public async Task UserAuthenticated()
        {
            var response = (await _client.GetAsync("/authenticated")).EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();

            Assert.Equal("Authenticated - paolo.franzini@3p-ictsoftware.it", stringResponse);
        }
    }
}
