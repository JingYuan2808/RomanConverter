using RomanConvertWebApi.Utilities;
using Microsoft.Extensions.DependencyInjection;

namespace RomanConvertWebApi.Controllers
{
    public static class RomanConverterControllerExtensions
    {
        public static void AddRomanConverterImpl(this IServiceCollection services)
        {
            services.AddScoped<IRomanConverterService, RomanConverterService>();
            services.AddScoped<IRomanDigitalConverter, RomanDigitalConverter>();
        }
    }
}