using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;

namespace RomanConverterWebApi.IntegrationTest
{
    public sealed class StartupWebApplicationFactory<TStartup, TController> : WebApplicationFactory<TStartup>
        where TStartup : class
        //Just want to make sure Controller containing assembly is loaded while testing
        where TController : ControllerBase
    {
        private readonly string _environment = EnvironmentName.Development;

        public StartupWebApplicationFactory()
            : this(new ClaimsPrincipal(new ClaimsIdentity(
                new[]
                {
                    new Claim("http://schemas.microsoft.com/ws/2008/06/identity/claims/groupsid",
                        IntegrationTestConstants.Sid),
                    new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name",
                        IntegrationTestConstants.UserName),
                    new Claim("http://schemas.microsoft.com/ws/2008/06/identity/claims/primarysid",
                        IntegrationTestConstants.Sid)
                }, "TestAuthenticationSchemeHandler")))
        {
        }

        public StartupWebApplicationFactory(string environment)
            : this()
        {
            _environment = environment;
        }

        public StartupWebApplicationFactory(ClaimsPrincipal user)
        {
            ClientOptions.BaseAddress = new Uri("https://localhost/");
        }
    }

    public static class IntegrationTestConstants
    {
        public const string UserName = "username";
        public const string IpAddress = "0.0.0.1";
        public const string Sid = "S-1-5-32-544";
        public const string HostAddress = "http://localhost:5000/api/";
        public const string ApiPathPrefix = "odata/";
    }

}

