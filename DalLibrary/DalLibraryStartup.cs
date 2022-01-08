using DalLibrary.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DalLibrary
{
    public class DalLibraryStartup
    {
        public static void InitializeDalLibrary(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AutoMarketContext>();
        }
    }
}
