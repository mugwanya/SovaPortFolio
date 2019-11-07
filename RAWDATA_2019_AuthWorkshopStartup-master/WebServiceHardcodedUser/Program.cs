using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace WebServiceHardcodedUser
{
    public class Program
    {
        public static int CurrentUserId = 1234;
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
