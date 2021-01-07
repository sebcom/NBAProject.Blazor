using System.IO;
using Microsoft.Extensions.Configuration;
using NBAProject.Blazor;
using NBAProject.Models.MySportsFeeds.ApiResponses;
using NBAProject.Services.MySportsFeeds;

namespace NBAProject.Tests.TestHelpers
{
    public class ApiFixture<T> where T : ApiResponse
    {
        public ApiFixture()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json")
                .AddUserSecrets<Startup>()
                .Build();

            var apiSettings = config.GetSection("ApiSettings");
            var baseUrl = apiSettings.GetSection("BaseUrl").Value;
            var username = apiSettings.GetSection("Username").Value;
            var password = apiSettings.GetSection("Password").Value;

            ApiSettings = new ApiSettings
            {
                BaseUrl = baseUrl,
                Username = username,
                Password = password
            };

            ApiService = new ApiService<T>(ApiSettings);
        }

        public IApiSettings ApiSettings { get; }
        public IApiService<T> ApiService { get; }
    }
}